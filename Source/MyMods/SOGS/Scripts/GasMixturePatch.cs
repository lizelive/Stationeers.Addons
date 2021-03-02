using Assets.Scripts.Atmospherics;
using Assets.Scripts.UI;
using Assets.Scripts.Util;
using HarmonyLib;
using JetBrains.Annotations;
using UnityEngine;

namespace ExampleMod.Scripts
{
    //[HarmonyPatch(typeof(GasMixture), "Temperature", MethodType.Getter)]
    //public class GasMixturePatch
    //{
    //    [UsedImplicitly]
    //    [System.Diagnostics.CodeAnalysis.SuppressMessage("CodeQuality", "IDE0051:Remove unused private members", Justification = "Used by mod loader")]
    //    private static bool Prefix(GasMixture __instance,
    //                               ref float __result,
    //                               ref float ____temperatureCached)
    //    {
    //        var value = ____temperatureCached;
    //        if (!(__instance.IsCachable && !Atmosphere.CanWriteAccess))
    //            value = __instance.HeatCapacity.IsDenormalToNegative() ? 0.0f : __instance.TotalEnergy / __instance.HeatCapacity / __instance.TotalMolesGassesAndLiquids;
    //        __result = 300;
    //        return false;
    //    }
    //}
}
