using HarmonyLib;
using RimWorld;

namespace DTimeControl;

[HarmonyPatch(typeof(PawnBreathMoteMaker), nameof(PawnBreathMoteMaker.ProcessPostTickVisuals))]
internal class Patch_BreathMoteMakerTick_Prefix
{
    public static bool Prefix()
    {
        return !(TimeControlBase.partialTick < 1.0);
    }
}