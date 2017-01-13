using SmartClient.Core.AppModel.Info;
using SmartClient.Core.Forms;

namespace SmartClient.Core.AppModel
{
    /// <summary>
    ///     Главный модуль (модуль окружения)
    /// </summary>
    public interface IEnvModule : IModule
    {
        /// <summary>
        ///     Настройка главной формы
        /// </summary>
        /// <param name="form"></param>
        void CustomizeForm(IMainForm form);

        /// <summary>
        ///     Регистрация модуля
        /// </summary>
        /// <param name="module"></param>
        void RegisterModule(ModuleInfo module);
    }
}