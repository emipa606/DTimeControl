using HarmonyLib;
using Verse;

namespace DTimeControl.Core_Patches;

[HarmonyPatch(typeof(Pawn_CarryTracker), nameof(Pawn_CarryTracker.CarryHandsTickInterval))]
internal class Pawn_CarryTracker_CarryHandsTickInterval
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