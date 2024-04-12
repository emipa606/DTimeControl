using HarmonyLib;
using RimWorld;
using Verse.AI;

namespace DTimeControl.Core_Patches.JobTracker_Patches;

[HarmonyPatch(typeof(JobDriver), nameof(JobDriver.DriverTick))]
internal class Patch_DriverTick_Prefix
{
    public static bool Prefix(JobDriver __instance)
    {
        return !(TimeControlBase.partialTick < 1.0) ||
               (!TimeControlSettings.scalePawns || !TimeControlSettings.slowWork ||
                TimeControlBase.ExcludedListOfJobDrivers.Contains(__instance.GetType().Name)) &&
               __instance is not (JobDriver_ChatWithPrisoner or JobDriver_Tame);
    }
}