using SmartClient.Core.AppModel.Info;
using DevExpress.XtraBars.Docking2010.Views.WindowsUI;

namespace SmartClient.Core.AppModel
{
    /// <summary>
    ///     Интерфейс модуля
    /// </summary>
    public interface IModule
    {
        /// <summary>
        ///     Получение структуры модуля
        /// </summary>
        /// <returns></returns>
        ModuleInfo GetInfo();

        /// <summary>
        ///     Уведомление о начале инициализации модуля
        /// </summary>
        void OnBeforeInit();

        /// <summary>
        ///     Уведомление об окончании инициализации модуля
        /// </summary>
        void OnAfterInit();

        /// <summary>
        /// Уведомление Об автозапуске
        /// </summary>
        void OnAutoStart();

        /// <summary>
        ///     Уведомление о выгрузке модуля
        /// </summary>
        void OnDeInit();

        /// <summary>
        ///     Уведомление о начале инициализации представления модуля
        /// </summary>
        /// <param name="view"></param>
        void OnBeforeInitModuleView(ViewInfo view);

        /// <summary>
        ///     Уведомление об окончании инициализации представления модуля
        /// </summary>
        /// <param name="view"></param>
        void OnAfterInitModuleView(ViewInfo view);

        /// <summary>
        ///     Уведомление о начале инициализации команды модуля
        /// </summary>
        /// <param name="command"></param>
        void OnBeforeInitModuleCommand(CommandInfo command);

        /// <summary>
        ///     Уведомление об окончании инициализации команды модуля
        /// </summary>
        /// <param name="command"></param>
        void OnAfterInitModuleCommand(CommandInfo command);

        /// <summary>
        ///     Уведомление о начале инициализации контейнера
        /// </summary>
        /// <param name="container"></param>
        void OnBeforeInitContainer(ContainerInfo container);

        /// <summary>
        ///     Уведомление об окончании инициализации контейнера
        /// </summary>
        /// <param name="container"></param>
        void OnAfterInitContainer(ContainerInfo container);


        /// <summary>
        ///     Изменение оторбражения команды
        /// </summary>
        /// <param name="command"></param>
        /// <param name="tile"></param>
        void CustomizeModuleCommand(CommandInfo command, Tile tile);

        /// <summary>
        ///     Изменение отображения представления-диалога
        /// </summary>
        /// <param name="view"></param>
        /// <param name="tile"></param>
        /// <param name="flyout"></param>
        void CustomizeModuleFlyoutView(ViewInfo view, Tile tile, Flyout flyout);

        /// <summary>
        ///     Изменение отображения представления
        /// </summary>
        /// <param name="view"></param>
        /// <param name="tile"></param>
        void CustomizeModulePageView(ViewInfo view, Tile tile, Page page);

        /// <summary>
        ///     Изменение отображения контейнера
        /// </summary>
        /// <param name="container"></param>
        /// <param name="tile"></param>
        /// <param name="group"></param>
        void CustomizeContainer(ContainerInfo container, Tile tile, DocumentGroup group);
    }
}