using System;
using SessionCombo.Configuration;
using Zenject;

namespace SessionCombo.Managers
{
    internal class SessionComboManager : IInitializable, IDisposable
    {
        private IComboController _comboController;
        private PluginConfig _config;
        public SessionComboManager(IComboController comboController, PluginConfig cfg)
        {
            _config = cfg;
            _comboController = comboController;
            Plugin.Log.Notice("Game Manager ctor");
        }


        public void Initialize()
        {
            Plugin.Log.Notice("Game Manager Init");
            if (_config.Enabled)
            {
                _comboController.comboDidChangeEvent += ComboControllerOncomboDidChangeEvent;
                _comboController.comboBreakingEventHappenedEvent += ComboControllerOncomboBreakingEventHappenedEvent;
            }
        }

        private void ComboControllerOncomboBreakingEventHappenedEvent()
        {
            Plugin.PastLevelsCombo = 0;
            Plugin.Combo = 0;
        }

        private void ComboControllerOncomboDidChangeEvent(int obj)
        {
            Plugin.Combo = obj;
        }

        public void Dispose()
        {
            Plugin.Log.Notice("Game Manager Dispose");
            if (_config.Enabled)
            {
                _comboController.comboDidChangeEvent -= ComboControllerOncomboDidChangeEvent;
                _comboController.comboBreakingEventHappenedEvent -= ComboControllerOncomboBreakingEventHappenedEvent;
            }
        }
    }
}