using HarmonyLib;
using Verse;

namespace DTimeControl.Core_Patches;

[HarmonyPatch(typeof(Pawn_AgeTracker), nameof(Pawn_AgeTracker.AgeTickInterval))]
internal class Pawn_AgeTracker_AgeTickInterval
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