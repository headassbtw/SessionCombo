using SessionCombo.Configuration;
using SessionCombo.Managers;
using Zenject;

namespace SessionCombo.Installers
{
    internal class AppInstaller : Installer
    {
        private readonly PluginConfig _config;

        public AppInstaller(PluginConfig config)
        {
            _config = config;
        }

        public override void InstallBindings()
        {
            Container.BindInstance(_config);
        }
    }
}