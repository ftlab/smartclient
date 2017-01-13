using System;
using CMIOR.UI.WF.AppModel.Info;
using DevExpress.XtraBars.Docking2010.Views.WindowsUI;

namespace CMIOR.UI.WF.AppModel
{
    public abstract class BaseModule : IModule
    {
        /// <summary>
        ///     Получение структуры модуля
        /// </summary>
        /// <returns></returns>
        public abstract ModuleInfo GetInfo();

        /// <summary>
        ///     Уведомление о начале инициализации модуля
        /// </summary>
        public virtual void OnBeforeInit()
        {
        }

        /// <summary>
        ///     Уведомление об окончании инициализации модуля
        /// </summary>
        public virtual void OnAfterInit()
        {
        }

        /// <summary>
        ///     Уведомление о выгрузке модуля
        /// </summary>
        public virtual void OnDeInit()
        {

        }

        /// <summary>
        ///     Уведомление о начале инициализации представления модуля
        /// </summary>
        /// <param name="view"></param>
        public virtual void OnBeforeInitModuleView(ViewInfo view)
        {
        }

        /// <summary>
        ///     Уведомление об окончании инициализации представления модуля
        /// </summary>
        /// <param name="view"></param>
        public virtual void OnAfterInitModuleView(ViewInfo view)
        {
        }

        /// <summary>
        ///     Уведомление о начале инициализации команды модуля
        /// </summary>
        /// <param name="command"></param>
        public virtual void OnBeforeInitModuleCommand(CommandInfo command)
        {
        }

        /// <summary>
        ///     Уведомление об окончании инициализации команды модуля
        /// </summary>
        /// <param name="command"></param>
        public virtual void OnAfterInitModuleCommand(CommandInfo command)
        {
        }

        /// <summary>
        ///     Уведомление о начале инициализации контейнера
        /// </summary>
        /// <param name="container"></param>
        public virtual void OnBeforeInitContainer(ContainerInfo container)
        {
        }

        /// <summary>
        ///     Уведомление об окончании инициализации контейнера
        /// </summary>
        /// <param name="container"></param>
        public virtual void OnAfterInitContainer(ContainerInfo container)
        {
        }

        /// <summary>
        ///     Изменение оторбражения команды
        /// </summary>
        /// <param name="command"></param>
        /// <param name="tile"></param>
        public virtual void CustomizeModuleCommand(CommandInfo command, Tile tile)
        {
        }

        /// <summary>
        ///     Изменение отображения представления-диалога
        /// </summary>
        /// <param name="view"></param>
        /// <param name="tile"></param>
        /// <param name="flyout"></param>
        public virtual void CustomizeModuleFlyoutView(ViewInfo view, Tile tile, Flyout flyout)
        {
        }

        /// <summary>
        ///     Изменение отображения представления
        /// </summary>
        /// <param name="view"></param>
        /// <param name="tile"></param>
        public virtual void CustomizeModulePageView(ViewInfo view, Tile tile, Page page)
        {
        }

        /// <summary>
        ///     Изменение отображения контейнера
        /// </summary>
        /// <param name="container"></param>
        /// <param name="tile"></param>
        /// <param name="group"></param>
        public virtual void CustomizeContainer(ContainerInfo container, Tile tile, DocumentGroup @group)
        {
        }

        /// <summary>
        /// Уведомление об автозапуске
        /// </summary>
        public virtual void OnAutoStart()
        {

        }
    }
}