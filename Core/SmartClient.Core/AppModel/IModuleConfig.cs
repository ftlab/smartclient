namespace SmartClient.Core.AppModel
{
    public interface IModuleConfig
    {
        string AssemblyName { get; }

        bool AutoStart { get; }

        bool IgnoreLoadException { get; }
    }
}
