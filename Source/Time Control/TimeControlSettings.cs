using UnityEngine;
using Verse;

namespace DTimeControl;

public class TimeControlSettings : ModSettings
{
    public static float speedMultiplier = 1.25f;
    public static bool scalePawns = true;
    public static bool dontScale;
    public static bool showAdvanced;
    public static bool speedUnlocked;
    public static bool speedReallyUnlocked;
    public static bool slowWork = true;

    public static int min = 90;
    public static int max = 300;

    public override void ExposeData()
    {
        Scribe_Values.Look(ref speedMultiplier, "speedMultiplier", 1.25f);
        Scribe_Values.Look(ref scalePawns, "scalePawns", true);
        Scribe_Values.Look(ref dontScale, "dontScale");
        Scribe_Values.Look(ref showAdvanced, "showAdvanced");
        Scribe_Values.Look(ref speedUnlocked, "speedUnlocked");
        Scribe_Values.Look(ref speedReallyUnlocked, "speedReallyUnlocked");
        Scribe_Values.Look(ref slowWork, "slowWork", true);
        base.ExposeData();
    }

    public static void WriteAll() // called when settings window closes
    {
        if (!showAdvanced)
        {
            scalePawns = true;
            dontScale = false;
            speedUnlocked = false;
            speedReallyUnlocked = false;
        }

        if (dontScale)
        {
            scalePawns = false;
        }

        if (!speedUnlocked)
        {
            speedReallyUnlocked = false;
        }

        speedMultiplier = Mathf.Clamp(speedMultiplier, min / 100f, max / 100f);
        TimeControlBase.SetCycleLength();
    }

    public static void DrawSettings(Rect rect)
    {
        var ls = new Listing_Standard(GameFont.Small)
        {
            ColumnWidth = rect.width - 30f
        };
        ls.Begin(rect);
        ls.Gap();


        if (speedReallyUnlocked && speedUnlocked)
        {
            min = 1;
            max = 1000;
        }
        else
        {
            min = 90;
            max = 300;
            speedMultiplier = Mathf.Clamp(speedMultiplier, min / 100f, max / 100f);
        }

        var timeMultRect = ls.GetRect(Text.LineHeight);
        var timeMultLabelRect = timeMultRect.LeftPartPixels(300);
        var timeMultSliderRect = timeMultRect.RightPartPixels(timeMultRect.width - 300);
        Widgets.Label(timeMultLabelRect, "TiCo.DayLength".Translate());
        var multPercent = Mathf.RoundToInt(speedMultiplier * 100);
        multPercent = Mathf.RoundToInt(Widgets.HorizontalSlider_NewTemp(timeMultSliderRect, multPercent, min, max,
            false,
            $"{multPercent}%", null, null, 1f));
        speedMultiplier = multPercent / 100f;
        ls.Gap();

        ls.CheckboxLabeled("TiCo.KeepWorkSpeed".Translate(), ref slowWork, "TiCo.KeepWorkSpeed.Tooltip".Translate());
        ls.Gap();

        ls.CheckboxLabeled("TiCo.Advanced".Translate(), ref showAdvanced, "TiCo.Advanced.Tooltip".Translate());
        ls.Gap();
        if (showAdvanced)
        {
            ls.CheckboxLabeled("TiCo.DontScale".Translate(), ref dontScale, "TiCo.DontScale.Tooltip".Translate());
            ls.Gap();
            if (!dontScale)
            {
                ls.CheckboxLabeled("TiCo.ScalePawns".Translate(), ref scalePawns,
                    "TiCo.ScalePawns.Tooltip".Translate());
            }
            else
            {
                ls.Label("TiCo.ScalePawns".Translate());
            }

            ls.Gap();
            ls.CheckboxLabeled("TiCo.UnlockSpeed".Translate(), ref speedUnlocked,
                "TiCo.UnlockSpeed.Tooltip".Translate());
            ls.Gap();
            if (speedUnlocked)
            {
                ls.CheckboxLabeled("TiCo.Really".Translate(), ref speedReallyUnlocked,
                    "TiCo.Really.Tooltip".Translate());
            }
        }

        if (TimeControlMod.currentVersion != null)
        {
            ls.Gap();
            GUI.contentColor = Color.gray;
            ls.Label("TiCo.CurrentModVersion".Translate(TimeControlMod.currentVersion));
            GUI.contentColor = Color.white;
        }

        ls.End();
    }
}