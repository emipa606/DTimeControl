using HarmonyLib;
using RimWorld;
using Verse.AI;

namespace DTimeControl.Core_Patches.JobTracker_Patches;

[HarmonyPatch(typeof(JobDriver))]
[HarmonyPatch("DriverTick")]
internal class Patch_DriverTick_Prefix
{
    public static bool Prefix(JobDriver __instance)
    {
        return !(TimeControlBase.partialTick < 1.0)
               || (!TimeControlSettings.scalePawns || !TimeControlSettings.slowWork
                                                   || __instance is JobDriver_TendPatient
                                                       or JobDriver_Lovin
                                                       or JobDriver_Mate || //|| (__instance is JobDriver_Wait || __instance is JobDriver_WaitDowned || __instance is JobDriver_WaitMaintainPosture)
                                                   // A RimWorld of Magic
                                                   __instance.GetType().Name is "TMJobDriver_CastAbilityVerb"
                                                       or "TMJobDriver_CastAbilitySelf" or "JobDriver_GotoAndCast")
               && __instance is not (JobDriver_ChatWithPrisoner or JobDriver_Tame);
    }
}