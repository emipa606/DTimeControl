using System.Reflection;
using HarmonyLib;
using Verse;

namespace DTimeControl;

[StaticConstructorOnStartup]
public static class SnapOutPatch
{
    static SnapOutPatch()
    {
        Log.Message("[TimeControl]: Adding support for Snap Out!");
        new Harmony("io.github.dametri.timecontrol.snapoutpatch").PatchAll(Assembly.GetExecutingAssembly());
    }
}