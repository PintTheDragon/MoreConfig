namespace MoreConfig.Patches
{
    using HarmonyLib;

    [HarmonyPatch(typeof(Scp939_VisionController))]
    class Scp939Vision
    {
        private static void Postfix(Scp939_VisionController __instance)
        {
            __instance.minimumNoiseLevel = MoreConfig.singleton.Config.Scp939Config.minimumNoiseLevel;
            __instance.minimumSilenceTime = MoreConfig.singleton.Config.Scp939Config.minimumSilenceTime;
        }
    }
}
