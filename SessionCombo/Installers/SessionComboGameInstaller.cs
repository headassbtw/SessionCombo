using SessionCombo.Configuration;
using SessionCombo.Managers;
using Zenject;

namespace SessionCombo.Installers
{
    internal class GameInstaller : Installer
    {
        private PluginConfig _config;
        public GameInstaller(PluginConfig cfg)
        {
            _config = cfg;
        }

        public override void InstallBindings()
        {
            if(_config.Enabled)
                Container.Bind<SessionComboManager>().AsSingle();
        }
    }
}