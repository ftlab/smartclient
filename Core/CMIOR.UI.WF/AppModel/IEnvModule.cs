using CMIOR.UI.WF.AppModel.Info;
using CMIOR.UI.WF.Forms;

namespace CMIOR.UI.WF.AppModel
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