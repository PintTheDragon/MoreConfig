using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoreConfig.Patches
{
    [HarmonyPatch(typeof(Scp939_VisionController))]
    class Scp939VisionController
    {
        private static void Postfix(Scp939_VisionController __instance)
        {
            __instance.minimumNoiseLevel = MoreConfig.singleton.Config.Scp939Config.minimumNoiseLevel;
            __instance.minimumSilenceTime = MoreConfig.singleton.Config.Scp939Config.minimumSilenceTime;
        }
    }
}
