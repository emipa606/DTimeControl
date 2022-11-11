using System.Collections.Generic;
using HarmonyLib;
using Verse.AI;

namespace DTimeControl.Core_Patches.Pawn_Timer_Adjustments;

[HarmonyPatch(typeof(Pawn_PathFollower))]
[HarmonyPatch("PatherTick")]
internal class Patch_PatherTick_Transpiler
{
    private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
    {
        return GenericTickReplacer.ReplaceTicks(instructions, "PatherTick");
    }
}