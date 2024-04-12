using System.Reflection;
using HarmonyLib;
using Verse;

namespace DTimeControl;

internal class HarmonyPatches : Mod
{
    public HarmonyPatches(ModContentPack content) : base(content)
    {
        new Harmony("io.github.dametri.timecontrol").PatchAll(Assembly.GetExecutingAssembly());
    }
}