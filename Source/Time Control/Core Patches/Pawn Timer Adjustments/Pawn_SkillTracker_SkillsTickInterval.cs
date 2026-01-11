using HarmonyLib;
using RimWorld;

namespace DTimeControl.Core_Patches.Pawn_Timer_Adjustments;

[HarmonyPatch(typeof(Pawn_SkillTracker), nameof(Pawn_SkillTracker.SkillsTickInterval))]
internal class Pawn_SkillTracker_SkillsTickInterval
{
    public static bool Prefix(ref int delta)
    {
        if (!TimeControlSettings.scalePawns)
        {
            return true;
        }

        delta = (int)(TimeControlBase.partialTick * delta);
        return !(delta < 1.0);
    }
}