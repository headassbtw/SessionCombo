using System;
using System.Reflection;
using SessionCombo.Configuration;
using Zenject;

namespace SessionCombo.Managers
{
    public class ModInitManager: IInitializable, IDisposable
    {
        private PluginConfig _config;
        ModInitManager(PluginConfig cfg)
        {
            _config = cfg;
        }

        public void Initialize()
        {
            if(_config.Enabled)
                Plugin.harmony.PatchAll(Assembly.GetExecutingAssembly());
        }
        public void Dispose()
        {}
    }
}