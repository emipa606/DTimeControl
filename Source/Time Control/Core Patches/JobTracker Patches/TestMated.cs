using HarmonyLib;
using RimWorld;
using Verse;

namespace DTimeControl.Core_Patches.JobTracker_Patches;

[HarmonyPatch(typeof(PawnUtility))]
[HarmonyPatch("Mated")]
internal class TestMated
{
    public static bool Prefix(Pawn male, Pawn female)
    {
        //Log.Message(male + " mated with " + female);
        return true;
    }
}