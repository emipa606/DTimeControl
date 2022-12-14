using System;
using System.Collections.Generic;
using HarmonyLib;
using SnapOut;
using Verse.AI;

namespace DTimeControl;

[HarmonyPatch(typeof(JobDriver_CalmDown), "MakeNewToils")]
internal class JobDriver_CalmDown_AttemptCalm
{
    private static IEnumerable<Toil> Postfix(IEnumerable<Toil> values)
    {
        foreach (var toil in values)
        {
            if (toil.defaultDuration == SOMod.Settings.CalmDuration)
            {
                toil.defaultDuration /= (int)Math.Floor(TimeControlSettings.speedMultiplier);
            }

            yield return toil;
        }
    }
}