using System.Linq;
using System.Reflection;
using HarmonyLib;
using IPA;
using IPA.Config;
using IPA.Config.Stores;
using SiraUtil.Zenject;
using SessionCombo.Configuration;
using SessionCombo.Installers;
using IPALogger = IPA.Logging.Logger;

namespace SessionCombo
{
    [Plugin(RuntimeOptions.DynamicInit),
     NoEnableDisable] // NoEnableDisable supresses the warnings of not having a OnEnable/OnStart
    // and OnDisable/OnExit methods
    public class Plugin
    {
        public static int Combo { get; internal set; }
        public static int PastLevelsCombo { get; internal set; }
        internal static Plugin Instance { get; private set; }
        internal static Harmony harmony { get; private set; }
        internal static IPALogger Log { get; private set; }
        internal PluginConfig _config;

        [Init]
        public void Init(Zenjector zenjector, IPALogger logger, Config config)
        {
            Instance = this;
            Log = logger;
            zenjector.UseLogger(logger);
            zenjector.UseMetadataBinder<Plugin>();
            harmony = new Harmony("com.headassbtw.sessioncombo");
            
            
            
            zenjector.Install<AppInstaller>(Location.App, config.Generated<PluginConfig>());
            zenjector.Install<InitInstaller>(Location.App);
            zenjector.Install<MenuInstaller>(Location.Menu);
            zenjector.Install<GameInstaller>(Location.Player);
        }
    }
}