using HarmonyLib;
using RimWorld;
using Verse;

namespace MURIncidentDisabler;

[HarmonyPatch(typeof(WeatherDecider), "CurrentWeatherCommonality")]
internal static class WeatherDecider_CurrentWeatherCommonality
{
    public static void Postfix(WeatherDef weather, ref float __result)
    {
        if (__result != 0f && IncidentDisablerMod.Instance.Settings.DisabledIncidentNames.Contains(weather.defName))
        {
            __result = 0f;
        }
    }
}