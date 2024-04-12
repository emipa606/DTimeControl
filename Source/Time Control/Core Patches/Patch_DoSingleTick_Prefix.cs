using HarmonyLib;
using Verse;

namespace DTimeControl.Core_Patches;

[HarmonyPatch(typeof(TickManager), nameof(TickManager.DoSingleTick))]
internal class Patch_DoSingleTick_Prefix
{
    public static bool Prefix(TickManager __instance)
    {
        TimeControlBase.TickManagerTick(__instance);
        return false;
    }
}