using SmartClient.Core.Services;
using SmartClient.Core.Services.Impl;
using Microsoft.Practices.Unity;

namespace SmartClient.Core.Container
{
    public static class ServiceContainerRegistrator
    {
        public static ServiceContainer UseDefaultDialogService(this ServiceContainer container)
        {
            container.RegisterInstance<IDialogService>(new DefaultDialogService(false));
            return container;
        }

        public static ServiceContainer UseDefaultMessageService(this ServiceContainer container)
        {
            container.RegisterInstance<IMessageService>(new DefaultMessageService(false));
            return container;
        }

        public static ServiceContainer UseDefaultWaitService(this ServiceContainer container)
        {
            container.RegisterInstance<IWaitService>(new DefaultWaitService());
            return container;
        }

        public static ServiceContainer UseDefaultNotificationService(this ServiceContainer container)
        {
            container.RegisterInstance<INotificationService>(new DefaultNotificationService());
            return container;
        }

        public static ServiceContainer UseDefaultHotkeyService(this ServiceContainer container)
        {
            container.RegisterInstance<IHotkeyService>(new DefaultHotkeyService());
            return container;
        }

        public static ServiceContainer UseDefaultUserSettingsService(this ServiceContainer container)
        {
            container.RegisterInstance<IUserSettingsService>(new DefaultUserSettingsService());
            return container;
        }
    }
}
