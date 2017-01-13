using CMIOR.UI.WF.Services;
using CMIOR.WCF.Executors;
using Microsoft.Practices.Unity;

namespace CMIOR.UI.WF.Container
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

        public IServiceExecutor<TChannel> GetExecutor<TChannel>() where TChannel : class => this.Resolve<IServiceExecutor<TChannel>>();

        public ServiceContainer UseWcfExecutor<TChannel>(string endpointName = null)
            where TChannel : class
        {
            return (ServiceContainer)this.RegisterType<IServiceExecutor<TChannel>, ServiceExecutor<TChannel>>
               (new TransientLifetimeManager()
               , new InjectionConstructor(endpointName ?? typeof(TChannel).Name.Substring(1)));
        }

        public ServiceContainer UseWrapperExecutor<TChannel, TImpl>()
            where TChannel : class
            where TImpl : class, TChannel
        {
            return (ServiceContainer)this.RegisterType<IServiceExecutor<TChannel>, ServiceWrapperExecutor<TChannel>>
                (new TransientLifetimeManager(), new InjectionConstructor(typeof(TImpl)));
        }
    }
}
