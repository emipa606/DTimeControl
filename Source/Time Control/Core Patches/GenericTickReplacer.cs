using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using HarmonyLib;
using Verse;

namespace DTimeControl.Core_Patches;

public static class GenericTickReplacer
{
    public static IEnumerable<CodeInstruction> ReplaceTicks(IEnumerable<CodeInstruction> instructions, string name)
    {
        var codes = new List<CodeInstruction>(instructions);
        var indices = new List<int>();
        for (var i = 0; i < codes.Count; i++)
        {
            if (codes[i].opcode != OpCodes.Callvirt)
            {
                continue;
            }

            var type = codes[i].operand as MethodInfo;
            if (type == null)
            {
                continue;
            }

            if (type.Name == "get_TicksGame")
            {
                indices.Add(i);
            }
        }

        if (indices.Count > 0)
        {
            foreach (var index in indices)
            {
                var mi = AccessTools.Field(typeof(TickUtility), nameof(TickUtility.adjustedTicksGameInt));
                var modCall = new CodeInstruction(OpCodes.Ldfld, mi);
                codes[index - 1].opcode = OpCodes.Ldnull;
                codes[index] = modCall;
            }
        }
        else
        {
            Log.Warning($"Failed to find any calls to TicksGame in {name} transpiler, nothing changed");
        }

        return codes;
    }
}