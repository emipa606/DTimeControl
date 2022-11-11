
/*
namespace DTimeControl.Core_Patches
{
    [HarmonyPatch(typeof(Pawn_InteractionsTracker))]
    [HarmonyPatch("InteractedTooRecentlyToInteract")]
    class Patch_InteractedTooRecentlyToInteract_Prefix
    {
        public static bool Prefix(ref bool __result, Pawn_InteractionsTracker pit)
        {
            FieldInfo lit = AccessTools.Field(typeof(Pawn_InteractionsTracker), "lastInteractionTime");
            int time = Mathf.RoundToInt((int)lit.GetValue(pit)  * TimeControlSettings.speedMultiplier);
            __result = TickUtility.adjustedTicksGameInt < (time + 120);
            return false;
        }
    }
}
*/