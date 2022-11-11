using HarmonyLib;
using RimWorld;

namespace DTimeControl.Core_Patches;

[HarmonyPatch(typeof(Pawn_PsychicEntropyTracker))]
[HarmonyPatch("PsyfocusFallPerDay", MethodType.Getter)]
internal class Patch_PsyfocusFallPerDay_Prefix
{
    public static bool Prefix()
    {
        return !(TimeControlBase.partialTick < 1.0);
    }
}