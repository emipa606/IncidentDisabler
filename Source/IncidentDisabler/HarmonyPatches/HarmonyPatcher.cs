using System.Reflection;
using HarmonyLib;
using Verse;

namespace MURIncidentDisabler;

[StaticConstructorOnStartup]
internal static class HarmonyPatcher
{
    static HarmonyPatcher()
    {
        new Harmony("rimworld.murmur.incidentdisabler").PatchAll(Assembly.GetExecutingAssembly());
    }
}