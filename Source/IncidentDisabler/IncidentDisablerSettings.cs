using System.Collections.Generic;
using Verse;

namespace MURIncidentDisabler;

public class IncidentDisablerSettings : ModSettings
{
    public List<string> DisabledIncidentNames = [];

    public override void ExposeData()
    {
        base.ExposeData();
        Scribe_Collections.Look(ref DisabledIncidentNames, "disabledIncidents");
    }
}