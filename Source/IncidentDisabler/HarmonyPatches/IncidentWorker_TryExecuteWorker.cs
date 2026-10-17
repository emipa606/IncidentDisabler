using HarmonyLib;
using RimWorld;

namespace MURIncidentDisabler;

[HarmonyPatch(typeof(IncidentWorker), "TryExecuteWorker")]
internal static class IncidentWorker_TryExecuteWorker
{
    public static void Postfix(ref IncidentWorker __instance, ref bool __result)
    {
        if (__result)
        {
            IncidentDisabler.LastIncidentName = __instance.def.defName;
        }
    }
}