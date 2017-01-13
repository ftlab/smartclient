using SmartClient.Core.Services;
using Microsoft.Practices.Unity;

namespace SmartClient.Core.Container
{
    public partial class ServiceContainer : UnityContainer
    {
        public static readonly ServiceContainer Default;

        static ServiceContainer()
        {
            Default = new ServiceContainer();
        }

        public IDialogService DialogService => this.Resolve<IDialogService>();

        public IMessageService MessageService => this.Resolve<IMessageService>();

        public IWaitService WaitService => this.Resolve<IWaitService>();

        public INotificationService NotificationService => this.Resolve<INotificationService>();

        public IHotkeyService HotkeyService => this.Resolve<IHotkeyService>();

        public IUserSettingsService UserSettingsService => this.Resolve<IUserSettingsService>();

    }
}
