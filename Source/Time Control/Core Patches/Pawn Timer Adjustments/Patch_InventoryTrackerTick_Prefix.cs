using HarmonyLib;
using Verse;

namespace DTimeControl.Core_Patches;

[HarmonyPatch(typeof(Pawn_InventoryTracker))]
[HarmonyPatch("InventoryTrackerTick")]
internal class Patch_InventoryTrackerTick_Prefix
{
    public static bool Prefix()
    {
        return !(TimeControlBase.partialTick < 1.0);
    }
}