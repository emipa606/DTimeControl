using HarmonyLib;
using Verse;

namespace DTimeControl.Core_Patches;

[HarmonyPatch(typeof(Pawn_HealthTracker), nameof(Pawn_HealthTracker.HealthTick))]
internal class Patch_HealthTick_Prefix
{
    public static bool Prefix()
    {
        return (!(TimeControlBase.partialTick < 1.0) || !TimeControlSettings.scalePawns) &&
               (TimeControlSettings.scalePawns ||
                TimeControlBase.cycleLength <= 1 || Find.TickManager.TicksGame % TimeControlBase.cycleLength != 0);
    }
}