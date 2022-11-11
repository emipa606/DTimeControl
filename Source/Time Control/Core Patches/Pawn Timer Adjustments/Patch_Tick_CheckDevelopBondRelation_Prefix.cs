using HarmonyLib;
using RimWorld;
using Verse;

namespace DTimeControl.Core_Patches.Pawn_Timer_Adjustments;

[HarmonyPatch(typeof(Pawn_RelationsTracker))]
[HarmonyPatch("Tick_CheckDevelopBondRelation")]
internal class Patch_Tick_CheckDevelopBondRelation_Prefix
{
    public static bool Prefix(ThingWithComps __instance)
    {
        return !(TimeControlBase.partialTick < 1.0);
    }
}