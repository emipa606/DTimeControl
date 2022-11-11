using System;
using HarmonyLib;
using Verse;

namespace DTimeControl;

[HarmonyPatch(typeof(Map))]
[HarmonyPatch("MapPreTick")]
internal class Patch_MapPreTick_Prefix
{
    public static bool Prefix(Map __instance)
    {
        __instance.itemAvailability.Tick();
        __instance.listerHaulables.ListerHaulablesTick();
        try
        {
            __instance.autoBuildRoofAreaSetter.AutoBuildRoofAreaSetterTick_First();
        }
        catch (Exception ex)
        {
            Log.Error(ex.ToString());
        }

        __instance.roofCollapseBufferResolver.CollapseRoofsMarkedToCollapse();
        __instance.windManager.WindManagerTick();
        if (!(TimeControlBase.partialTick >= 1.0))
        {
            return false;
        }

        try
        {
            __instance.mapTemperature.MapTemperatureTick();
        }
        catch (Exception ex2)
        {
            Log.Error(ex2.ToString());
        }

        return false;
    }
}