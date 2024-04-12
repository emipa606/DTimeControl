using HarmonyLib;
using Verse;

namespace DTimeControl.Core_Patches;

[HarmonyPatch(typeof(TimeSlower), nameof(TimeSlower.SignalForceNormalSpeed))]
internal class Patch_SignalForceNormalSpeed_Prefix
{
    public static bool Prefix(ref int ___forceNormalSpeedUntil)
    {
        var forceUntil = (int)(Find.TickManager.TicksGame + (800f / TimeControlSettings.speedMultiplier));
        ___forceNormalSpeedUntil = forceUntil;
        return false;
    }
}