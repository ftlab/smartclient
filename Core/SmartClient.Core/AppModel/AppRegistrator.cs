using SmartClient.Core.Forms;
using SmartClient.Core.Services;
using Microsoft.Practices.Unity;

namespace SmartClient.Core.AppModel
{
    public static class AppRegistrator
    {
        public static App RegistrateMainForm(this App app, IMainForm mainForm)
        {
            return (App) app.RegisterInstance(mainForm);
        }

        public static App RegistrateEnvModule(this App app, IEnvModule environment)
        {
            return (App) app.RegisterInstance(environment);
        }

        public static App RegistrateModuleRepository(this App app, IModuleRepository repository)
        {
            return (App) app.RegisterInstance(repository);
        }
    }
}