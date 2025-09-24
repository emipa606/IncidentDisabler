using Mlie;
using UnityEngine;
using Verse;

namespace MURIncidentDisabler;

public class IncidentDisablerMod : Mod
{
    private static string currentVersion;

    public static IncidentDisablerMod Instance;
    public readonly IncidentDisablerSettings Settings;
    private Vector2 scrollPosition = Vector2.zero;

    private Rect viewRect = new(0f, 0f, 100f, 10000f);

    public IncidentDisablerMod(ModContentPack content)
        : base(content)
    {
        Instance = this;
        Settings = GetSettings<IncidentDisablerSettings>();
        currentVersion = VersionFromManifest.GetVersionFromModMetaData(content.ModMetaData);
    }

    public override string SettingsCategory()
    {
        return "Incident Disabler";
    }

    public override void DoSettingsWindowContents(Rect inRect)
    {
        var rect = new Rect(inRect.x, inRect.y + 24f, inRect.width, inRect.height - 24f);
        var rect2 = new Rect(rect.x, rect.y - 64f, rect.width - 40f, 10000f);
        var listingStandard = new Listing_Standard();
        listingStandard.Begin(rect);
        listingStandard.ColumnWidth = inRect.width / 2f;
        listingStandard.Gap(4f);
        var text = "InDi.None".Translate();
        if (IncidentDisabler.LastIncidentName != null)
        {
            text = IncidentDisabler.LastIncidentName;
        }

        listingStandard.Label("InDi.LastIncident".Translate(text));
        listingStandard.NewColumn();
        listingStandard.ColumnWidth = rect.width / 4.5f;
        if (listingStandard.ButtonText("InDi.DisableAll".Translate()))
        {
            foreach (var incidentDef in IncidentDisabler.IncidentDefs)
            {
                Settings.DisabledIncidentNames.Add(incidentDef.defName);
            }
        }

        listingStandard.NewColumn();
        if (listingStandard.ButtonText("InDi.EnableAll".Translate()))
        {
            Settings.DisabledIncidentNames.Clear();
        }

        if (currentVersion != null)
        {
            listingStandard.Gap();
            GUI.contentColor = Color.gray;
            listingStandard.Label("InDi.ModVersion".Translate(currentVersion));
            GUI.contentColor = Color.white;
        }

        listingStandard.End();
        var rect3 = new Rect(rect.x, rect.y + 34f, rect.width, 30f);
        var listingStandard2 = new Listing_Standard();
        Widgets.DrawHighlight(rect3);
        listingStandard2.Begin(rect3);
        listingStandard2.Gap(5f);
        listingStandard2.ColumnWidth = 460f;
        listingStandard2.Label("InDi.IncidentName".Translate());
        listingStandard2.NewColumn();
        listingStandard2.Gap(5f);
        listingStandard2.ColumnWidth = 100f;
        listingStandard2.Label("InDi.Enabled".Translate());
        listingStandard2.End();
        Widgets.BeginScrollView(new Rect(rect.x, rect.y + 64f, rect.width, 484f), ref scrollPosition, viewRect);
        var listingStandard3 = new Listing_Standard();
        listingStandard3.Begin(rect2);
        listingStandard3.verticalSpacing = 8f;
        listingStandard3.ColumnWidth = 500f;
        listingStandard3.Gap(4f);
        foreach (var incidentDef2 in IncidentDisabler.IncidentDefs)
        {
            var checkOn = !Settings.DisabledIncidentNames.Contains(incidentDef2.defName);
            listingStandard3.CheckboxLabeled(incidentDef2.defName, ref checkOn);
            if (checkOn)
            {
                if (Settings.DisabledIncidentNames.Contains(incidentDef2.defName))
                {
                    Settings.DisabledIncidentNames.Remove(incidentDef2.defName);
                }
            }
            else if (!Settings.DisabledIncidentNames.Contains(incidentDef2.defName))
            {
                Settings.DisabledIncidentNames.Add(incidentDef2.defName);
            }
        }

        listingStandard3.Gap(16f);
        listingStandard3.Label("InDi.Weather".Translate());
        foreach (var weatherDef in IncidentDisabler.WeatherDefs)
        {
            var checkOn2 = !Settings.DisabledIncidentNames.Contains(weatherDef.defName);
            listingStandard3.CheckboxLabeled(weatherDef.defName, ref checkOn2);
            if (checkOn2)
            {
                if (Settings.DisabledIncidentNames.Contains(weatherDef.defName))
                {
                    Settings.DisabledIncidentNames.Remove(weatherDef.defName);
                }
            }
            else if (!Settings.DisabledIncidentNames.Contains(weatherDef.defName))
            {
                Settings.DisabledIncidentNames.Add(weatherDef.defName);
            }
        }

        viewRect.height = listingStandard3.CurHeight;
        listingStandard3.End();
        Widgets.EndScrollView();
    }
}