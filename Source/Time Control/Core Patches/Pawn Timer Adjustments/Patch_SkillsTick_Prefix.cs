using HarmonyLib;
using RimWorld;

namespace DTimeControl.Core_Patches.Pawn_Timer_Adjustments;

[HarmonyPatch(typeof(Pawn_SkillTracker))]
[HarmonyPatch("SkillsTick")]
internal class Patch_SkillsTick_Prefix
{
    public static bool Prefix()
    {
        return !(TimeControlBase.partialTick < 1.0) || !TimeControlSettings.scalePawns;
    }
}