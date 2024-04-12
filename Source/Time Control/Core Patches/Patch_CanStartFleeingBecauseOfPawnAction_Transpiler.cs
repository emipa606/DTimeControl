using System.Collections.Generic;
using HarmonyLib;
using Verse.AI;

namespace DTimeControl.Core_Patches;

[HarmonyPatch(typeof(Pawn_MindState), nameof(Pawn_MindState.CanStartFleeingBecauseOfPawnAction))]
internal class Patch_CanStartFleeingBecauseOfPawnAction_Transpiler
{
    private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
    {
        return GenericTickReplacer.ReplaceTicks(instructions, "CanStartFleeingBecauseOfPawnAction");
    }
}