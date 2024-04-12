using HarmonyLib;
using Verse;

namespace DTimeControl.Core_Patches;

[HarmonyPatch(typeof(TickManager), MethodType.Constructor)]
internal class Patch_TickManagerConstructor_Postfix
{
    public static void Postfix(ref TickList ___tickListNormal, ref TickList ___tickListRare,
        ref TickList ___tickListLong)
    {
        ___tickListNormal = new TCTickList(___tickListNormal);
        ___tickListRare = new TCTickList(___tickListRare);
        ___tickListLong = new TCTickList(___tickListLong);
    }
}