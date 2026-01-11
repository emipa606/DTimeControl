using HarmonyLib;
using Verse;

namespace DTimeControl.Core_Patches.Pawn_Timer_Adjustments;

[HarmonyPatch(typeof(Pawn), nameof(Pawn.TickRare))]
internal class Pawn_TickRare
{
    public static bool Prefix()
    {
        return !(TimeControlBase.partialTick < 1.0);
    }
}