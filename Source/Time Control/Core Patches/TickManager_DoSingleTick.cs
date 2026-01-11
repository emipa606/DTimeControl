using HarmonyLib;
using Verse;

namespace DTimeControl.Core_Patches;

[HarmonyPatch(typeof(TickManager), nameof(TickManager.DoSingleTick))]
internal class TickManager_DoSingleTick
{
    public static bool Prefix(TickManager __instance)
    {
        TimeControlBase.TickManagerTick(__instance);
        return false;
    }
}