using SessionCombo.Configuration;
using SessionCombo.Managers;
using Zenject;

namespace SessionCombo.Installers
{
    internal class MenuInstaller : Installer
    {

        public MenuInstaller()
        {
            
        }

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<UI.Settings.Controller>().AsSingle();
        }
    }
}