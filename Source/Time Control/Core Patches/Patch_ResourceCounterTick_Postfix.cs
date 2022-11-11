using HarmonyLib;
using RimWorld;

namespace DTimeControl.Core_Patches;

[HarmonyPatch(typeof(ResourceCounter))]
[HarmonyPatch("ResourceCounterTick")]
internal class Patch_ResourceCounterTick_Postfix
{
    public static void Postfix(ResourceCounter __instance)
    {
        if (TickUtility.NoOverlapTickMod(204))
        {
            __instance.UpdateResourceCounts();
        }
    }
}