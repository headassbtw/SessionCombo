using HarmonyLib;
using TMPro;

namespace SessionCombo.HarmonyPatches
{
    [HarmonyPatch(typeof(ComboUIController), "Start")]
    public class ComboUIStart
    {
        static void Postfix(ComboUIController __instance, TextMeshProUGUI ____comboText)
        {
            
            Plugin.Log.Info("ComboUIController Start()");
            ____comboText.text = Plugin.PastLevelsCombo.ToString();
        }
    }
    [HarmonyPatch(typeof(ComboUIController), "OnDisable")]
    public class ComboUIEnd
    {
        static void Postfix(ComboUIController __instance, TextMeshProUGUI ____comboText)
        {
            
            Plugin.Log.Info("ComboUIController OnDisable()");
            Plugin.PastLevelsCombo += Plugin.Combo;
        }
    }
    [HarmonyPatch(typeof(ComboUIController), "HandleComboDidChange")]
    public class ComboUIChange
    {
        static void Postfix(int combo, TextMeshProUGUI ____comboText)
        {
            
            
            ____comboText.text = (Plugin.PastLevelsCombo + combo).ToString();
        }
    }
}