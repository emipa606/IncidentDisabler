using HarmonyLib;
using RimWorld;

namespace MURIncidentDisabler;

[HarmonyPatch(typeof(IncidentWorker), nameof(IncidentWorker.TryExecute))]
internal static class IncidentWorker_TryExecute
{
    public static void Postfix(ref IncidentWorker __instance, ref bool __result)
    {
        if (__result)
        {
            IncidentDisabler.LastIncidentName = __instance.def.defName;
        }
    }
}