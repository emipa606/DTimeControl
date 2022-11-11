using System;
using System.Collections.Generic;
using RimWorld;
using Verse;

namespace DTimeControl;

public class TCTickList : TickList
{
    public List<List<Thing>> adjustedthingList = new List<List<Thing>>();

    public int cycleStep;

    public List<List<Thing>> normalThingList = new List<List<Thing>>();
    public List<List<Thing>> thingLists;
    public List<Thing> thingsToDeregister;
    public List<Thing> thingsToRegister;

    public TickerType tickType;

    public TCTickList(TickList old) : base(GetTickType(old))
    {
        tickType = GetTickType(old);
        thingLists = base.thingLists;
        thingsToRegister = base.thingsToRegister;
        thingsToDeregister = base.thingsToDeregister;

        for (var i = 0; i < TickInterval; i++)
        {
            normalThingList.Add(new List<Thing>());
            adjustedthingList.Add(new List<Thing>());
        }
    }

    public int TickInterval
    {
        get
        {
            switch (tickType)
            {
                case TickerType.Normal:
                    return 1;
                case TickerType.Rare:
                    return 250;
                case TickerType.Long:
                    return 2000;
                default:
                    return -1;
            }
        }
    }

    public List<Thing> BucketOf(Thing t)
    {
        var num = t.GetHashCode();
        if (num < 0)
        {
            num *= -1;
        }

        var index = num % TickInterval;
        if (t is Pawn ||
            t.def.projectile != null && (t.def.projectile.damageDef != null || t.def.projectile.extraDamages != null ||
                                         t.def.projectile.explosionRadius > 0) ||
            t is Building_Door or Building_TurretGun or Building_Turret)
        {
            return adjustedthingList[index];
        }

        return normalThingList[index];
    }

    public void TickThing(Thing thing)
    {
        if (thing.Destroyed)
        {
            return;
        }

        try
        {
            switch (tickType)
            {
                case TickerType.Normal:
                    thing.Tick();
                    break;
                case TickerType.Rare:
                    thing.TickRare();
                    break;
                case TickerType.Long:
                    thing.TickLong();
                    break;
            }
        }
        catch (Exception ex)
        {
            var text = thing.Spawned ? $" (at {thing.Position})" : "";
            if (Prefs.DevMode)
            {
                Log.Error($"Exception ticking {thing.ToStringSafe()}{text}: {ex}");
            }
            else
            {
                Log.ErrorOnce(
                    $"Exception ticking {thing.ToStringSafe()}{text}. Suppressing further errors. Exception: {ex}",
                    thing.thingIDNumber ^ 576876901);
            }
        }
    }

    public void
        DoTick(double partialTick, bool firstRun) // faster: firstRun may be false; slower: partialTick may be < 1
    {
        if (TimeControlSettings.dontScale && partialTick < 1.0f)
        {
            return;
        }

        foreach (var thing in thingsToRegister)
        {
            BucketOf(thing).Add(thing);
        }

        thingsToRegister.Clear();
        foreach (var thing in thingsToDeregister)
        {
            BucketOf(thing).Remove(thing);
        }

        thingsToDeregister.Clear();
        if (DebugSettings.fastEcology &&
            partialTick > 1.0) // fast ecology update; faster: run this always, slower: don't run if not a tick
        {
            Find.World.tileTemperatures.ClearCaches();
            foreach (var list in thingLists)
            {
                foreach (var thing in list)
                {
                    if (thing.def.category == ThingCategory.Plant)
                    {
                        thing.TickLong();
                    }
                }
            }
        }

        var adjustedTicksGame = TickUtility.adjustedTicksGameInt % TickInterval;
        var normalTicksGame = Find.TickManager.TicksGame % TickInterval;

        if (partialTick >= 1.0)
        {
            foreach (var normalThing in normalThingList[normalTicksGame])
            {
                TickThing(normalThing);
            }
        }

        if (Find.TickManager.TicksGame % TimeControlBase.cycleLength != cycleStep && !TimeControlSettings.dontScale &&
            TimeControlSettings.scalePawns)
        {
            return;
        }

        cycleStep--;
        if (cycleStep <= 0)
        {
            cycleStep = TimeControlBase.cycleLength - 1;
        }

        foreach (var adjustedThing in adjustedthingList[adjustedTicksGame])
        {
            TickThing(adjustedThing);
        }
    }

    public static TickerType GetTickType(TickList tick)
    {
        return tick.tickType;
    }
}