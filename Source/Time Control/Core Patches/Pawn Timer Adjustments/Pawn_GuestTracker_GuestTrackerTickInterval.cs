using HarmonyLib;
using RimWorld;

namespace DTimeControl.Core_Patches.Pawn_Timer_Adjustments;

[HarmonyPatch(typeof(Pawn_GuestTracker), nameof(Pawn_GuestTracker.GuestTrackerTickInterval))]
internal class Pawn_GuestTracker_GuestTrackerTickInterval
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