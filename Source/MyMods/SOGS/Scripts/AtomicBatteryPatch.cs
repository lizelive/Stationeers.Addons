using Assets.Scripts.Objects;
using Assets.Scripts.Objects.Items;
using HarmonyLib;
using JetBrains.Annotations;
using UnityEngine;

namespace ExampleMod.Scripts
{
    [HarmonyPatch(typeof(BatteryCell), "OnPowerTick")]
    public class AtomicBatteryPatch
    {
        const float OuchRadius = 2f;
        const float OuchDps = 0.02f;
        [UsedImplicitly]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("CodeQuality", "IDE0051:Remove unused private members", Justification = "Used by mod loader")]
        private static void Prefix(BatteryCell __instance)
        {
            if (__instance.PrefabName != "ItemBatteryCellNuclear")
                return;
            
            __instance.AddPowerSafe(100); //almost reasonable
            
            var pos = __instance.Position;
            var ouchRadiusSqr = OuchRadius * OuchRadius;
            foreach (var stuff in Thing._colliderLookup.Values) {
                var thing = stuff;

                //this part needs to be run on main thread i gues
                //var col = stuff.Key;
                
                //var thingPos = stuff.Key.ClosestPointOnBounds(pos);
                //var distanceSqr = thing.Bounds.SqrDistance(pos);
                var distanceSqr = (pos - thing.Position).sqrMagnitude;
                if (distanceSqr <= ouchRadiusSqr)
                thing.DamageState.Radiation += OuchDps / distanceSqr;
            }
        }
    }
}
