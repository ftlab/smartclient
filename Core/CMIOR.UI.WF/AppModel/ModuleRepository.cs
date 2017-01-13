using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using CMIOR.CommonContracts.DataModel.Param;
using CMIOR.CommonContracts.ServiceContracts;
using CMIOR.UI.WF.Config;
using CMIOR.UI.WF.Container;
using CMIOR.WCF.Executors;
using Microsoft.Practices.Unity;

namespace CMIOR.UI.WF.AppModel
{
    public class ModuleRepository : IModuleRepository
    {
		/// <summary>
		///  Загрузочный путь к сборкам модулей
		/// </summary>
		const string ModulesFolder = @"Modules\";
	    public ModuleRepository()
	    {
            ServiceContainer.Default
                .RegisterType<IServiceExecutor<IArmConfigService>, ServiceExecutor<IArmConfigService>>
                (new TransientLifetimeManager(), new InjectionConstructor("ArmConfigService"));

		    AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
	    }


		/// <summary>
		///  Загрузка сборки по требованию
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="args">описание требуемой сборки</param>
		/// <returns></returns>
	    private Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
	    {
		    var path = $"{ModulesFolder}{args.Name}.dll";
			if (File.Exists(path))
                return Assembly.LoadFrom(path);

			path = $"{ModulesFolder}{args.Name}.exe";
			if (File.Exists(path))
		        return Assembly.LoadFrom(path);

#if FULL   //отладочная загрузка сервисных сборок в один домен с клиентскими
			const string servicesFolder = @"..\..\Server\Debug\Services\";

			path = $"{servicesFolder}{args.Name}.dll";
			if (File.Exists(path))
                return Assembly.LoadFrom(path);

			path = $"{servicesFolder}{args.Name}.exe";
			if (File.Exists(path))
		        return Assembly.LoadFrom(path);
#endif 

			return null;
	    }


        private IList<IArmModule> _config = null;

        /// <summary>
        ///  Получение конфигурации модулей
        /// </summary>
        /// <returns></returns>
        public IList<IArmModule> GetConfig()
        {
            if (_config == null)
            {

                bool way = bool.TryParse(ConfigurationManager.AppSettings["GetConfigFromDb"], out way) && way;
#if FULL
		        way = false;
#endif
                if (way)
                    using (var exec = ServiceContainer.Default.Resolve<IServiceExecutor<IArmConfigService>>())
                        _config = new List<IArmModule>(
                            exec.Execute(x => x.GetModules()));
                else
                    _config = new List<IArmModule>(
                        ((ModulesSection) ConfigurationManager.GetSection("modules"))
                            .Modules.OfType<ModuleElement>());
            }
            if (_config.Count == 0)
                throw new ArgumentException("Пустой набор модулей");
            return _config;
        }


        /// <summary>
		///  Получение модулей по конфигурации
		/// </summary>
		/// <returns></returns>
		public IEnumerable<IModule> GetModules()
        {
            foreach (var module in GetConfig())
            {
                IModule result = null;
                try
                {
                    var assembly = Assembly.LoadFrom($"{ModulesFolder}{module.AssemblyName}.dll");
                    var moduleTypes = assembly.GetTypes()
                        .Where(x => x.GetInterfaces().Contains(typeof(IModule)))
                        .ToArray();

                    if (moduleTypes.Length < 1)
                        throw new Exception("В сборке отсутствует модуль");

                    if (moduleTypes.Length > 1)
                        throw new Exception("В сборке присутствует более одного модуля");

                    result = (IModule)Activator.CreateInstance(moduleTypes[0]);
                }
                catch
                {
                    if (module.IgnoreLoadException == false)
                        throw;
                }
                yield return result;
            }
        }
    }
}