using HarmonyLib;
using PlayableScps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace MoreConfig.Patches
{
    [HarmonyPatch(typeof(PlayableScps.Scp096), nameof(PlayableScps.Scp096.GetVisionInformation))]
    class Scp096
    {
        public void Postfix(PlayableScps.Scp096 __instance, VisionInformation __result, GameObject source)
        {
			VisionInformation visionInformation = new VisionInformation
			{
				Source = source,
				Target = __instance.Hub.gameObject,
				RaycastHit = false,
				Looking = false
			};
			if (source == __instance.Hub.gameObject)
			{
				__result = visionInformation;
				return;
			}
			Transform playerCameraReference = ReferenceHub.GetHub(source).PlayerCameraReference;
			Vector3 position = __instance.Hub.PlayerCameraReference.position;
			Vector3 position2 = playerCameraReference.position;
			visionInformation.Distance = Vector3.Distance(position2, position);
			float num = -Vector3.Dot((position2 - position).normalized, playerCameraReference.forward);
			float num2 = -Vector3.Dot((position - position2).normalized, __instance.Hub.PlayerCameraReference.forward);
			visionInformation.DotProduct = num;
			visionInformation.Looking = true;
			if (num < MoreConfig.singleton.Config.Scp096Config.bounds1 || num2 < MoreConfig.singleton.Config.Scp096Config.bounds2)
			{
				visionInformation.Looking = false;
				__result = visionInformation;
				return;
			}
			if (visionInformation.Distance > ((__instance.Hub.transform.position.y > 980f) ? 60f : 30f))
			{
				__result = visionInformation;
				return;
			}
			RaycastHit raycastResult;
			if (!Physics.Raycast(visionInformation.Source.transform.position, (visionInformation.Target.transform.position - visionInformation.Source.transform.position).normalized, out raycastResult, 60f, PlayableScps.Scp096.VisionLayerMask))
			{
				__result = visionInformation;
				return;
			}
			visionInformation.RaycastHit = true;
			visionInformation.RaycastResult = raycastResult;
			__result = visionInformation;
        }
    }
}
