using HarmonyLib;
using RimWorld;

namespace MURIncidentDisabler;

[HarmonyPatch(typeof(IncidentWorker), nameof(IncidentWorker.TryExecute))]
internal class IncidentWorker_TryExecute
{
    private static void Postfix(ref IncidentWorker __instance, ref bool __result)
    {
        if (__result)
        {
            IncidentDisabler.LastIncidentName = __instance.def.defName;
        }
    }
}