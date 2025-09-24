using HarmonyLib;
using RimWorld;

namespace MURIncidentDisabler;

[HarmonyPatch(typeof(IncidentWorker), nameof(IncidentWorker.CanFireNow))]
internal class IncidentWorker_CanFireNow
{
    private static void Postfix(ref IncidentWorker __instance, ref bool __result)
    {
        if (__result && IncidentDisablerMod.Instance.Settings.DisabledIncidentNames.Contains(__instance.def.defName))
        {
            __result = false;
        }
    }
}