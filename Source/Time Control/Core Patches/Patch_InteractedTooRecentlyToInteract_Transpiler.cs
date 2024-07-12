using System.Collections.Generic;
using System.Reflection.Emit;
using HarmonyLib;
using RimWorld;
using Verse;

namespace DTimeControl.Core_Patches;

[HarmonyPatch(typeof(Pawn_InteractionsTracker), nameof(Pawn_InteractionsTracker.InteractedTooRecentlyToInteract))]
internal class Patch_InteractedTooRecentlyToInteract_Transpiler
{
    public static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
    {
        var list = new List<CodeInstruction>(instructions);

        // Naive find for the "canary" bytecode
        for (var i = 0; i < list.Count; i++)
        {
            if (!list[i].Is(OpCodes.Ldc_I4_S, 120))
            {
                continue;
            }

            list.Insert(i + 1, CodeInstruction.LoadField(typeof(TimeControlSettings), "speedMultiplier"));
            list.Insert(i + 2, new CodeInstruction(OpCodes.Conv_I4));
            list.Insert(i + 3, new CodeInstruction(OpCodes.Div));
            return list;
        }

        Log.Warning("Time Control: Did not find bytecode to transpile for InteractedTooRecentlyToInteract");
        return list;
    }
}