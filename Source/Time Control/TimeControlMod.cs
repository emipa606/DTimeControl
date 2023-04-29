using Mlie;
using UnityEngine;
using Verse;

namespace DTimeControl;

internal class TimeControlMod : Mod
{
    public static string currentVersion;
    private TimeControlSettings settings;

    public TimeControlMod(ModContentPack content) : base(content)
    {
        settings = GetSettings<TimeControlSettings>();
        currentVersion =
            VersionFromManifest.GetVersionFromModMetaData(content.ModMetaData);
    }

    public override void DoSettingsWindowContents(Rect inRect)
    {
        TimeControlSettings.DrawSettings(inRect);
        base.DoSettingsWindowContents(inRect);
    }

    public override string SettingsCategory()
    {
        return "Time Control";
    }


    public override void WriteSettings() // called when settings window closes
    {
        TimeControlSettings.WriteAll();
        base.WriteSettings();
    }
}