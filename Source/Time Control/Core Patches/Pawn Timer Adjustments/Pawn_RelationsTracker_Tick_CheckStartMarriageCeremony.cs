using HarmonyLib;
using RimWorld;

namespace DTimeControl;

[HarmonyPatch(typeof(Pawn_RelationsTracker), nameof(Pawn_RelationsTracker.Tick_CheckStartMarriageCeremony))]
internal class Pawn_RelationsTracker_Tick_CheckStartMarriageCeremony
{
    public static bool Prefix()
    {
        return !(TimeControlBase.partialTick < 1.0);
    }
}