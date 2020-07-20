namespace MoreConfig.Patches
{
    using HarmonyLib;

    [HarmonyPatch(typeof(Scp079PlayerScript))]
    class Scp079
    {
        private static void Postfix(Scp079PlayerScript __instance)
        {
            __instance.NetworkcurMana = MoreConfig.singleton.Config.Scp079Config.startingMana;
            __instance.NetworkmaxMana = MoreConfig.singleton.Config.Scp079Config.maxMana;
        }
    }
}
