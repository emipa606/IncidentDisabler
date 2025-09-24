using HarmonyLib;
using RimWorld;

namespace MURIncidentDisabler;

[HarmonyPatch(typeof(IncidentWorker), "TryExecuteWorker")]
internal class IncidentWorker_TryExecuteWorker
{
    private static void Postfix(ref IncidentWorker __instance, ref bool __result)
    {
        if (__result)
        {
            IncidentDisabler.LastIncidentName = __instance.def.defName;
        }
    }
}