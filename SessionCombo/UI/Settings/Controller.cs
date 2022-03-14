using System;
using System.ComponentModel;
using System.Linq;
using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.Settings;
using SessionCombo.Configuration;
using Zenject;

namespace SessionCombo.UI.Settings
{
    internal class Controller : IInitializable, IDisposable
    {
        private readonly PluginConfig _config;

        [UIValue("enabled")]
        private bool Enabled
        {
            get => _config.Enabled;
            set => _config.Enabled = value;
        }

        [UIAction("#apply")]
        private void OnApply()
        {
            
            if (Enabled && (Plugin.harmony.GetPatchedMethods().Any()))
                Plugin.harmony.PatchAll();
            else
                Plugin.harmony.UnpatchSelf();
        }
        
        public Controller(PluginConfig config)
        {
            _config = config;
        }

        public void Initialize()
        {
            BSMLSettings.instance.AddSettingsMenu("SessionCombo", "SessionCombo.UI.Settings.View.bsml", this);
        }

        public void Dispose()
        {
            if (BSMLSettings.instance != null) BSMLSettings.instance.RemoveSettingsMenu("SessionCombo");
        }
    }
}