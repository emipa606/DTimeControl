using HarmonyLib;
using Verse;
using Verse.AI;

namespace DTimeControl.Core_Patches.JobTracker_Patches;

[HarmonyPatch(typeof(Pawn_JobTracker))]
[HarmonyPatch("JobTrackerTick")]
internal class Patch_JobTrackerTick_Postfix
{
    public static bool Prefix(Pawn_JobTracker __instance, Pawn ___pawn)
    {
        if (!___pawn.NoOverlapAdjustedIsHashIntervalTick(30))
        {
            return true;
        }

        var thinkResult = (ThinkResult)JobTrackerUtility.DetermineNextConstantThinkTreeJob.Invoke(__instance, null);
        if (!thinkResult.IsValid)
        {
            return true;
        }

        var start = (bool)JobTrackerUtility.ShouldStartJobFromThinkTree.Invoke(__instance,
            new object[] { thinkResult });
        if (start)
        {
            JobTrackerUtility.CheckLeaveJoinableLordBecauseJobIssued.Invoke(__instance,
                new object[] { thinkResult });
            __instance.StartJob(thinkResult.Job, JobCondition.InterruptForced, thinkResult.SourceNode, false,
                false, ___pawn.thinker.ConstantThinkTree, thinkResult.Tag);
        }
        else if (thinkResult.Job != __instance.curJob && !__instance.jobQueue.Contains(thinkResult.Job))
        {
            JobMaker.ReturnToPool(thinkResult.Job);
        }

        return true;
    }
}