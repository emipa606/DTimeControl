using HarmonyLib;
using RimWorld;

namespace DTimeControl.Core_Patches;

[HarmonyPatch(typeof(Pawn_PsychicEntropyTracker), nameof(Pawn_PsychicEntropyTracker.PsyfocusFallPerDay),
    MethodType.Getter)]
internal class Pawn_PsychicEntropyTracker_PsyfocusFallPerDay
{
    public static bool Prefix()
    {
        return !(TimeControlBase.partialTick < 1.0);
    }
}