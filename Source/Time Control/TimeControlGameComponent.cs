using Verse;

namespace DTimeControl;

public class TimeControlGameComponent : GameComponent
{
    public int adjustedTicks;
    private readonly Game currentGame;

    public TimeControlGameComponent(Game game)
    {
        currentGame = game;
    }

    public override void StartedNewGame()
    {
        TickUtility.GetManagerData(currentGame);
        TickUtility.adjustedTicksGameInt = adjustedTicks;
        TimeControlBase.SetCycleLength();
        base.StartedNewGame();
    }

    public override void LoadedGame()
    {
        TickUtility.GetManagerData(currentGame);
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