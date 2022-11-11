using HarmonyLib;
using Verse;

namespace DTimeControl.Core_Patches;

[HarmonyPatch(typeof(ThingWithComps))]
[HarmonyPatch("Tick")]
internal class Patch_ThingWithCompsTick_Prefix
{
    public static bool Prefix(ThingWithComps __instance)
    {
        return !(TimeControlBase.partialTick < 1.0) || __instance is not Pawn; // force normal tick
    }
}