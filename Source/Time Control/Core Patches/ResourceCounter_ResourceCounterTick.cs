using HarmonyLib;
using RimWorld;

namespace DTimeControl.Core_Patches;

[HarmonyPatch(typeof(ResourceCounter), nameof(ResourceCounter.ResourceCounterTick))]
internal class ResourceCounter_ResourceCounterTick
{
    public static void Postfix(ResourceCounter __instance)
    {
        if (TickUtility.NoOverlapTickMod(204))
        {
            __instance.UpdateResourceCounts();
        }
    }
}