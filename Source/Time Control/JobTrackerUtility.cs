using System.Reflection;
using HarmonyLib;
using Verse;
using Verse.AI;

namespace DTimeControl;

[StaticConstructorOnStartup]
public static class JobTrackerUtility
{
    public static readonly MethodInfo DetermineNextConstantThinkTreeJob;
    public static readonly MethodInfo ShouldStartJobFromThinkTree;
    public static readonly MethodInfo CheckLeaveJoinableLordBecauseJobIssued;

    static JobTrackerUtility()
    {
        DetermineNextConstantThinkTreeJob =
            AccessTools.Method(typeof(Pawn_JobTracker), nameof(Pawn_JobTracker.DetermineNextConstantThinkTreeJob));
        ShouldStartJobFromThinkTree =
            AccessTools.Method(typeof(Pawn_JobTracker), nameof(Pawn_JobTracker.ShouldStartJobFromThinkTree));
        CheckLeaveJoinableLordBecauseJobIssued =
            AccessTools.Method(typeof(Pawn_JobTracker), nameof(Pawn_JobTracker.CheckLeaveJoinableLordBecauseJobIssued));
    }
}