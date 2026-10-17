# GitHub Copilot Instructions for Incident Disabler (Continued) Mod Development

## Mod Overview and Purpose

**Mod Name:** Incident Disabler (Continued)

**Description:** 
Incident Disabler (Continued) is a RimWorld mod that updates the original mod by Murmur. Its primary function is to allow players to disable any game incidents during gameplay. This includes both incidents from the base game and those introduced by other mods. In addition to incidents, weather events can also be toggled on or off.

**Key Objectives:**
- Provide flexibility in gameplay by allowing players to disable unwanted incidents.
- Ensure compatibility and seamless integration with other RimWorld mods.
- Support both new and existing game saves, allowing the mod to be added or removed without affecting game progress.

## Key Features and Systems

- **Incident Management:** Ability to toggle any in-game incident off or on via the mod configuration menu, which includes a comprehensive list of incidents.
- **Weather Event Control:** Incorporates weather events, providing them as a separate category at the bottom of the incident list.
- **Safe Game Integration:** The mod can be dynamically integrated into or removed from ongoing games without adversely affecting the save state.
- **Broad Compatibility:** Designed to work with virtually all other mods, minimizing compatibility issues.

## Coding Patterns and Conventions

- **C# File Structure:** The code base is organized with a clear structure for code handling incidents and patches.
  - Example file locations include `HarmonyPatcher.cs`, `Startup.cs`, and various `IncidentWorker` override methods.
  
- **Descriptive Naming:** Classes and methods are descriptively named to indicate their purpose, such as `IncidentWorker_CanFireNow` with a `Postfix` method.

- **Consistent Formatting:** Adhere to consistent naming conventions, code formatting, and organization to promote clarity and maintainability.

## XML Integration

- **Mod Metadata:** Utilizes XML files, such as `About.xml`, to define mod information and dependencies. 

- **Dependency Declaration:** The XML integration is crucial for declaring dependencies, such as `brrainz.harmony`, which is necessary for harmony patching.

## Harmony Patching

- **Harmony Library:** The mod uses the Harmony library to inject custom functionality into the game's original code without altering the core files.

- **Patch Implementation:** Patches are defined using Harmony to modify incident behaviors, with examples including postfixes on the `IncidentWorker` classes.

- **Example Patches:**
  - `IncidentWorker_CanFireNow.cs` - Controls whether incidents can occur.
  - `IncidentWorker_TryExecute.cs` - Determines the execution of incidents.
  - `IncidentWorker_TryExecuteWorker.cs` - Manages the worker's ability to execute incidents.

## Suggestions for Copilot

When using GitHub Copilot to assist with mod development for Incident Disabler (Continued), consider the following suggestions:

1. **Code Completion:** Leverage Copilot to suggest code snippets for common patterns in Harmony patching, such as creating postfix or prefix methods for the incident management code.

2. **XML Editing:** Use Copilot to help write or refine XML entries, particularly for defining dependency relationships and mod metadata.

3. **Error Handling:** Trust Copilot for ideas on error handling or logging mechanisms that can be incorporated into the mod to improve reliability and user feedback.

4. **Optimization Suggestions:** Allow Copilot to suggest potential optimizations or improvements in the incident handling logic, such as reducing redundancy or enhancing performance.

5. **Documentation:** Utilize Copilot to generate or improve comments and documentation within the codebase to ensure clarity for future developers.

By following these instructions, developers can effectively utilize GitHub Copilot to enhance the development of the Incident Disabler (Continued) mod, resulting in a robust, flexible, and player-centric experience.

## Project Solution Guidelines
- Relevant mod XML files are included as Solution Items under the solution folder named XML, these can be read and modified from within the solution.
- Use these in-solution XML files as the primary files for reference and modification.
- The `.github/copilot-instructions.md` file is included in the solution under the `.github` solution folder, so it should be read/modified from within the solution instead of using paths outside the solution. Update this file once only, as it and the parent-path solution reference point to the same file in this workspace.
- When making functional changes in this mod, ensure the documented features stay in sync with implementation; use the in-solution `.github` copy as the primary file.
- In the solution is also a project called Assembly-CSharp, containing a read-only version of the decompiled game source, for reference and debugging purposes.
- For any new documentation, update this copilot-instructions.md file rather than creating separate documentation files.


## Hard rules (must follow)
- Do NOT run commands that modify the repo (no git commit, git apply, dotnet format) unless explicitly asked.
- Prefer minimal reads: read only the smallest code region needed (around the suspicious lines).
- When mentioning SonarQube issues, automatically use the SonarQube MCP service to fetch and address issues instead of making inferred fixes without querying SonarQube first.
- When mentioning the rimworld log, automatically use the Rimworld MCP service to fetch the log.

