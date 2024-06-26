﻿using HarmonyLib;
using Verse;

namespace DTimeControl.Core_Patches;

[HarmonyPatch(typeof(Pawn_CarryTracker), nameof(Pawn_CarryTracker.CarryHandsTick))]
internal class Patch_CarryHandsTick_Prefix
{
    public static bool Prefix()
    {
        return !(TimeControlBase.partialTick < 1.0);
    }
}