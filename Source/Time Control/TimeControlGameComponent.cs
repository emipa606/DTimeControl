using Verse;

namespace DTimeControl;

public class TimeControlGameComponent(Game game) : GameComponent
{
    public int adjustedTicks;

    public override void StartedNewGame()
    {
        TickUtility.GetManagerData(game);
        TickUtility.adjustedTicksGameInt = adjustedTicks;
        TimeControlBase.SetCycleLength();
        base.StartedNewGame();
    }

    public override void LoadedGame()
    {
        TickUtility.GetManagerData(game);
        TickUtility.adjustedTicksGameInt = adjustedTicks;
        TimeControlBase.SetCycleLength();
        base.LoadedGame();
    }

    public override void ExposeData()
    {
        adjustedTicks = TickUtility.adjustedTicksGameInt;
        Scribe_Values.Look(ref adjustedTicks, "adjustedTicks");
        base.ExposeData();
    }
}