using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using SmartClient.Core.Config;

namespace SmartClient.Core.AppModel
{
    public class ModuleRepository : IModuleRepository
    {
        /// <summary>
        ///  Загрузочный путь к сборкам модулей
        /// </summary>
        const string ModulesFolder = @"Modules\";

        public ModuleRepository()
        {
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

            return null;
        }


        private IList<IModuleConfig> _config = null;

        /// <summary>
        ///  Получение конфигурации модулей
        /// </summary>
        /// <returns></returns>
        public IList<IModuleConfig> GetConfig()
        {
            if (_config == null)
            {
                _config = new List<IModuleConfig>(
                    ((ModulesSection)ConfigurationManager.GetSection("modules"))
                        .Modules.OfType<ModuleElement>());
            }
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