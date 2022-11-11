using System;
using RimWorld;
using UnityEngine;
using Verse;

namespace DTimeControl;

[StaticConstructorOnStartup]
public static class TimeControlBase
{
    public static double partialTick;

    public static int cycleLength = 1;

    static TimeControlBase()
    {
    }

    public static void SetCycleLength()
    {
        if (Current.Game == null)
        {
            return;
        }

        cycleLength = 1.0 / TimeControlSettings.speedMultiplier > 1
            ? Mathf.RoundToInt(1.0f / TimeControlSettings.speedMultiplier)
            : 1;

        TickUtility.tickListNormal.cycleStep = 0;
        TickUtility.tickListRare.cycleStep = 0;
        TickUtility.tickListLong.cycleStep = 0;
    }

    public static void TickManagerTick(TickManager tm, bool firstRun = true)
    {
        var mult = TimeControlSettings.speedMultiplier;
        if (firstRun)
        {
            partialTick += 1.0 / mult;
        }

        var maps = Find.Maps;
        foreach (var map in maps)
        {
            map.MapPreTick();
        }

        if (partialTick >= 1.0)
        {
            if (!DebugSettings.fastEcology)
            {
                TickUtility.ticksGameInt++;
            }
            else
            {
                TickUtility.ticksGameInt += 2000;
            }
        }

        if (firstRun || TimeControlSettings.dontScale)
        {
            if (!DebugSettings.fastEcology)
            {
                TickUtility.adjustedTicksGameInt++;
            }
            else
            {
                TickUtility.adjustedTicksGameInt += 2000;
            }
        }

        Shader.SetGlobalFloat(ShaderPropertyIDs.GameSeconds, tm.TicksGame.TicksToSeconds() * mult);
        TickUtility.tickListNormal.DoTick(partialTick, firstRun);
        TickUtility.tickListRare.DoTick(partialTick, firstRun);
        TickUtility.tickListLong.DoTick(partialTick, firstRun);
        if (partialTick >= 1.0)
        {
            try
            {
                Find.DateNotifier.DateNotifierTick();
            }
            catch (Exception ex)
            {
                Log.Error(ex.ToString());
            }

            try
            {
                Find.Scenario.TickScenario();
            }
            catch (Exception ex2)
            {
                Log.Error(ex2.ToString());
            }

            try
            {
                Find.World.WorldTick();
            }
            catch (Exception ex3)
            {
                Log.Error(ex3.ToString());
            }

            try
            {
                Find.StoryWatcher.StoryWatcherTick();
            }
            catch (Exception ex4)
            {
                Log.Error(ex4.ToString());
            }

            try
            {
                Find.GameEnder.GameEndTick();
            }
            catch (Exception ex5)
            {
                Log.Error(ex5.ToString());
            }

            try
            {
                Find.Storyteller.StorytellerTick();
            }
            catch (Exception ex6)
            {
                Log.Error(ex6.ToString());
            }

            try
            {
                Find.TaleManager.TaleManagerTick();
            }
            catch (Exception ex7)
            {
                Log.Error(ex7.ToString());
            }

            try
            {
                Find.QuestManager.QuestManagerTick();
            }
            catch (Exception ex8)
            {
                Log.Error(ex8.ToString());
            }

            try
            {
                Find.World.WorldPostTick();
            }
            catch (Exception ex9)
            {
                Log.Error(ex9.ToString());
            }

            foreach (var map in maps)
            {
                map.MapPostTick();
            }

            try
            {
                Find.History.HistoryTick();
            }
            catch (Exception ex10)
            {
                Log.Error(ex10.ToString());
            }

            GameComponentUtility.GameComponentTick();
            try
            {
                Find.LetterStack.LetterStackTick();
            }
            catch (Exception ex11)
            {
                Log.Error(ex11.ToString());
            }

            try
            {
                Find.Autosaver.AutosaverTick();
            }
            catch (Exception ex12)
            {
                Log.Error(ex12.ToString());
            }

            if (DebugViewSettings.logHourlyScreenshot &&
                Find.TickManager.TicksGame >= TickUtility.lastAutoScreenshot + 2500)
            {
                ScreenshotTaker.QueueSilentScreenshot();
                TickUtility.lastAutoScreenshot = Find.TickManager.TicksGame / 2500 * 2500;
            }

            try
            {
                TickUtility.FilthMonitorTick();
            }
            catch (Exception ex13)
            {
                Log.Error(ex13.ToString());
            }

            partialTick -= 1.0;
        }
        else
        {
            foreach (var map in maps)
            {
                map.resourceCounter.ResourceCounterTick();
            }
        }

        Debug.developerConsoleVisible = false;
        if (partialTick >= 1.0)
        {
            TickManagerTick(tm, false);
        }
    }


    public static int HourMinuteReadout(long absTicks, float longitude)
    {
        Log.Message("moo");
        return GenDate.HourInteger(absTicks, longitude);
    }
}