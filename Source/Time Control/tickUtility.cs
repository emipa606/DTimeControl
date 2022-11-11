using System;
using System.Reflection;
using HarmonyLib;
using Verse;

namespace DTimeControl;

[StaticConstructorOnStartup]
public static class TickUtility
{
    public static TickManager tickManager;

    public static TCTickList tickListNormal;
    public static TCTickList tickListRare;
    public static TCTickList tickListLong;

    public static Type FilthMonitor;
    public static MethodInfo fmt;

    public static int adjustedTicksGameInt = 0;

    static TickUtility()
    {
        FilthMonitor = AccessTools.TypeByName("RimWorld.FilthMonitor");
        fmt = AccessTools.Method(FilthMonitor, "FilthMonitorTick");
    }

    public static int ticksGameInt
    {
        get => tickManager.TicksGame;
        set => tickManager.ticksGameInt = value;
    }

    public static int AdjustedTicksGame => adjustedTicksGameInt;

    public static int lastAutoScreenshot
    {
        get => tickManager.lastAutoScreenshot;
        set => tickManager.lastAutoScreenshot = value;
    }


    public static bool AdjustedIsHashIntervalTick(this Thing t, int interval)
    {
        return t.AdjustedHashOffsetTicks() % interval == 0;
    }

    public static int AdjustedHashOffsetTicks(this Thing t)
    {
        return adjustedTicksGameInt + t.thingIDNumber.HashOffset();
    }

    public static bool NoOverlapAdjustedIsHashIntervalTick(this Thing t, int interval)
    {
        return t.AdjustedIsHashIntervalTick(interval) && !t.IsHashIntervalTick(interval);
    }

    public static bool NoOverlapTickMod(int interval)
    {
        return adjustedTicksGameInt % interval == 0 && ticksGameInt % interval != 0;
    }

    public static void FilthMonitorTick()
    {
        fmt.Invoke(null, null);
    }

    public static void GetManagerData(Game currentGame)
    {
        tickManager = currentGame.tickManager;

        tickListNormal = (TCTickList)tickManager.tickListNormal;
        tickListRare = (TCTickList)tickManager.tickListRare;
        tickListLong = (TCTickList)tickManager.tickListLong;
    }
}