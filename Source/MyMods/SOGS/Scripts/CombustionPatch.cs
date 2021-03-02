using Assets.Scripts;
using Assets.Scripts.Atmospherics;
using Assets.Scripts.UI;
using Assets.Scripts.Util;
using HarmonyLib;
using JetBrains.Annotations;
using UnityEngine;

namespace ExampleMod.Scripts
{

    [HarmonyPatch(typeof(Atmosphere), "Combust")]
    public class AtmosphereCombustPatch
    {
        [UsedImplicitly]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("CodeQuality", "IDE0051:Remove unused private members", Justification = "Used by mod loader")]
        private static bool Prefix(Atmosphere __instance,
                                   ref bool ____inflamed,
                                   Atmosphere.MatterState productType)
        {
            float molesOfH2 = Mathf.Min(__instance.GasMixture.TotalFuel, __instance.GasMixture.Oxygen.Quantity * 2f);
            float molesOfO2 = molesOfH2 / 2f;
            float burnPercentage = 0.95f;
            float removedMolesH2 = molesOfH2 * burnPercentage;
            float removedMolesO2 = molesOfO2 * burnPercentage;
            Mole burnt = __instance.GasMixture.Volatiles.Remove(removedMolesH2);
            burnt.Add(__instance.GasMixture.Oxygen.Remove(removedMolesO2));

            // what is matterstate all?
            float magicOutputScaler = productType == Atmosphere.MatterState.All ? 0.5f : 1f;
            // we only burn h2
            Water water = new Water(magicOutputScaler * removedMolesH2)
            {
                Energy = magicOutputScaler * burnt.Energy
            };
            __instance.GasMixture.Water.Add(water);
            
            __instance.CombustionEnergy = __instance.GasMixture.Volatiles.Enthalpy * removedMolesH2;
            __instance.GasMixture.AddEnergy(__instance.CombustionEnergy);
            __instance.BurnedPropaneQuantity = removedMolesH2;
            __instance.CleanBurnRate = __instance.CombustableMix();
            ____inflamed = true;

            return false;
        }
    }
}
