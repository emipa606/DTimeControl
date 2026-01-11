using System.Collections.Generic;
using HarmonyLib;
using RimWorld;

namespace DTimeControl.Core_Patches;

[HarmonyPatch(typeof(FleeUtility), nameof(FleeUtility.ShouldAnimalFleeDanger))]
internal class FleeUtility_ShouldAnimalFleeDanger
{
    private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
    {
        return GenericTickReplacer.ReplaceTicks(instructions, "ShouldAnimalFleeDanger");
    }
}