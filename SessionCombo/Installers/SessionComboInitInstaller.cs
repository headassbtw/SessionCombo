using SessionCombo.Managers;
using Zenject;

namespace SessionCombo.Installers
{
    public class InitInstaller : Installer
    {
        
        InitInstaller()
        {
            
        }
        public override void InstallBindings()
        {
            Container.Bind<ModInitManager>().AsSingle();
        }
    }
}