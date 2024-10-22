using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using RoR2;
using TILER2;

namespace TILER2NoPoll
{
    [BepInPlugin(PluginGUID, PluginName, PluginVersion)]
    [BepInDependency(TILER2Plugin.ModGuid)]
    public class Main : BaseUnityPlugin
    {
        public const string PluginGUID = PluginAuthor + "." + PluginName;
        public const string PluginAuthor = "prodzpod";
        public const string PluginName = "TILER2NoPoll";
        public const string PluginVersion = "1.0.0";
        public static ManualLogSource Log;
        public static PluginInfo pluginInfo;
        public static Harmony Harmony;

        public void Awake()
        {
            pluginInfo = Info;
            Log = Logger;
            On.RoR2.RoR2Application.Update -= AutoConfigContainer.FilePollUpdateHook;
            Harmony = new(PluginGUID);
            Harmony.PatchAll(typeof(yo));
        }
    }
    [HarmonyPatch(typeof(AutoConfigContainer), nameof(AutoConfigContainer.FilePollUpdateHook))]
    public class yo
    {
        public static void Prefix()
        {
            Main.Log.LogInfo("AHHH (update is happening please let prod know)");
        }
    }
}
