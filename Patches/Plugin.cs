using BepInEx;
using System.ComponentModel;

namespace Rift.Patches
{
    [Description(Rift.PluginInfo.Description)]
    [BepInPlugin(Rift.PluginInfo.GUID, Rift.PluginInfo.Name, Rift.PluginInfo.Version)]
    public class HarmonyPatches : BaseUnityPlugin
    {
        private void OnEnable()
        {
            Menu.ApplyHarmonyPatches();
        }

        private void OnDisable()
        {
            Menu.RemoveHarmonyPatches();
        }
    }
}
