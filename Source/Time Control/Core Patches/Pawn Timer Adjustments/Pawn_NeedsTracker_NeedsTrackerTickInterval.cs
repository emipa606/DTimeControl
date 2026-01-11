using HarmonyLib;
using RimWorld;

namespace DTimeControl.Core_Patches.Pawn_Timer_Adjustments;

[HarmonyPatch(typeof(Pawn_NeedsTracker), nameof(Pawn_NeedsTracker.NeedsTrackerTickInterval))]
internal class Pawn_NeedsTracker_NeedsTrackerTickInterval
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