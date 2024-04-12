using HarmonyLib;
using RimWorld;

namespace DTimeControl;

[HarmonyPatch(typeof(Pawn_RelationsTracker), nameof(Pawn_RelationsTracker.Tick_CheckStartMarriageCeremony))]
internal class Patch_Tick_CheckStartMarriageCeremony_Prefix
{
    public static bool Prefix()
    {
        return !(TimeControlBase.partialTick < 1.0);
    }
}