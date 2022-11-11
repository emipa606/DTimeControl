using HarmonyLib;
using RimWorld;
using Verse;

namespace DTimeControl;

[HarmonyPatch(typeof(Pawn_RelationsTracker))]
[HarmonyPatch("Tick_CheckStartMarriageCeremony")]
internal class Patch_Tick_CheckStartMarriageCeremony_Prefix
{
    public static bool Prefix(ThingWithComps __instance)
    {
        return !(TimeControlBase.partialTick < 1.0);
    }
}