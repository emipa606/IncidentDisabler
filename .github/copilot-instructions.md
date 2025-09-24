# Copilot Instructions for "Incident Disabler (Continued)" Mod Development

## Mod Overview and Purpose

The "Incident Disabler (Continued)" mod is designed to enhance the user experience in RimWorld by granting players the ability to disable or enable any incident, including those created by other mods, during an ongoing game. It offers a flexible approach to game customization, allowing players to tailor their experience by managing incidents and weather events according to their preferences. This mod ensures seamless integration and can be added or removed mid-game without risks.

## Key Features and Systems

- **Incident Management**: Allows toggling of all game incidents, both vanilla and modded, via a configuration menu.
- **Weather Control**: Adds functionality to manage weather-related events, categorized separately at the bottom of the configuration menu.
- **Mod Compatibility**: Designed to work alongside other mods without causing conflicts or requiring extensive setup.

## Coding Patterns and Conventions

- **Namespaces and Access Modifiers**: Use internal access for classes that are not intended to be accessed from outside the assembly, and public access for settings and mod classes that interface with RimWorld.
- **Singleton and Static Classes**: Use static classes like `S` and `Startup` for maintaining global states or executing startup logic.
- **Mod Settings Integration**: Employ the `ModSettings` derived class (`Settings`) to handle configuration and persist user choices.

## XML Integration

- Ensure that all references to incidents and weather events are correctly reflected in the RimWorld's XML definitions for proper integration. Modify XML files as needed to introduce new configuration options and inject them into the mod settings menu.

## Harmony Patching

- Utilize Harmony to safely and effectively alter the vanilla game's methods. 
- Commonly patched areas are the incident trigger checks (`IncidentWorker_CanFireNow`) and execution paths (`IncidentWorker_TryExecute`, `IncidentWorker_TryExecuteWorker`).
- Implement harmony patches within the `HarmonyPatcher.cs` to ensure mod operations coexist with base game mechanics.

## Suggestions for Copilot

When using GitHub Copilot to aid in development:

1. **Code Completion**: Leverage Copilot to autocomplete method signatures when working on classes like `IncidentWorker_*` and `WeatherDecider_*`.
2. **Harmony Setup**: Use Copilot to assist in setting up Harmony patches. Look for patterns on how to structure prefix and postfix methods within `HarmonyPatcher.cs`.
3. **UI Elements**: Seek suggestions on creating dynamic UI elements in `ModSettingsPage.cs` to improve configurability within the mod menu.
4. **Debugging and Logging**: Copilot can suggest patterns for implementing logging within methods to facilitate debugging, especially for complex incident management logic.
5. **Documentation**: Ask Copilot to generate or fill in XML comments for methods and classes to maintain comprehensive documentation within the source code.

By following these instructions and leveraging tools such as GitHub Copilot, you'll be able to streamline the development and maintenance of the "Incident Disabler (Continued)" mod effectively.
