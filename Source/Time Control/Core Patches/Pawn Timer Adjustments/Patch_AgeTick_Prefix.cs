using HarmonyLib;
using Verse;

namespace DTimeControl.Core_Patches;

[HarmonyPatch(typeof(Pawn_AgeTracker))]
[HarmonyPatch("AgeTick")]
internal class Patch_AgeTick_Prefix
{
    public static bool Prefix()
    {
        return !(TimeControlBase.partialTick < 1.0) || !TimeControlSettings.scalePawns;
    }
}