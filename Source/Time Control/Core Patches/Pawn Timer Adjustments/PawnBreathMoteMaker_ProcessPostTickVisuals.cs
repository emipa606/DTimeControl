using HarmonyLib;
using RimWorld;

namespace DTimeControl;

[HarmonyPatch(typeof(PawnBreathMoteMaker), nameof(PawnBreathMoteMaker.ProcessPostTickVisuals))]
internal class PawnBreathMoteMaker_ProcessPostTickVisuals
{
    public static bool Prefix()
    {
        return !(TimeControlBase.partialTick < 1.0);
    }
}