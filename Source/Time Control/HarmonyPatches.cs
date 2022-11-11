using System.Reflection;
using HarmonyLib;
using Verse;

namespace DTimeControl;

internal class HarmonyPatches : Mod
{
    public HarmonyPatches(ModContentPack content) : base(content)
    {
        var harmony = new Harmony("io.github.dametri.timecontrol");
        var assembly = Assembly.GetExecutingAssembly();
        harmony.PatchAll(assembly);
    }
}