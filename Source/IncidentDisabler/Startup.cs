using System.Collections.Generic;
using System.Linq;
using RimWorld;
using Verse;

namespace MURIncidentDisabler;

[StaticConstructorOnStartup]
public static class Startup
{
    static Startup()
    {
        var source = new List<IncidentDef>(DefDatabase<IncidentDef>.AllDefs);
        var list = new List<WeatherDef>(DefDatabase<WeatherDef>.AllDefs);
        list.Remove(WeatherDefOf.Clear);
        IncidentDisabler.IncidentDefs = source.OrderBy(o => o.defName).ToList();
        IncidentDisabler.WeatherDefs = list.OrderBy(o => o.defName).ToList();
    }
}