# GitHub Copilot Instructions for [D] Time Control (Continued) Mod

## Mod Overview and Purpose

**Mod Name:** [D] Time Control (Continued)  
**Description:** This mod enables players to control the length of a day in RimWorld, allowing colonists to have more or less time to complete tasks. It's primarily designed for RimWorld versions 1.1 and 1.2, providing more flexibility in gameplay by adjusting time management for colony activities. This mod is compatible with existing saves and can be removed without causing issues.

## Key Features and Systems

- **Adjustable Day Length:** Players can use a slider in the options menu to set the desired day length, making it either longer or shorter than the default.
- **Consistent Pawn Behavior:** Despite longer days, pawns will maintain their usual speed for actions such as movement, combat, and tending to wounds.
- **Work Efficiency Option:** An optional setting allows colonists to accomplish more tasks within extended days.
- **Needs Management:** Colonists' needs, such as food intake and rest, remain consistent on a per-day basis, even with extended days.
- **Health Management:** Extended days allow more time for health-related activities.
  
**Load Order:**

1. Harmony
2. Core
3. Time Control

**Compatibility:** The mod should be compatible with most other mods except for known conflicts, such as Zombieland. It is tested with Smart Speed.

## Coding Patterns and Conventions

- **File Naming:** Use descriptive names for files and keep them organized according to their functionality.
- **Class Naming:** Employ PascalCase for class names and ensure they are descriptive of their purpose, such as `TimeControlMod` or `Patch_GuestTrackerTick_Prefix`.
- **Method Naming:** Follow C# conventions, using PascalCase for method names.
- **Internal Modifiers:** Use `internal` for classes and methods that should not be exposed outside of the assembly.

## XML Integration

While the mod primarily uses C# code to control tick rates and modify time behaviors, ensure that any XML used for settings or options is well-structured and commented. This will help in maintaining compatibility with other mods that may also modify game settings.

## Harmony Patching

- **Purpose:** The core mechanic of this mod involves altering the game's tick code using Harmony patches. 
- **Application:** Use specific patch methods (e.g., `Prefix`, `Postfix`, `Transpiler`) to modify existing game methods without altering the base game files.
- **HarmonyPatches Class:** The `HarmonyPatches` class is used to apply patches across various game elements, ensuring extended compatibility.

## Suggestions for Copilot

- **Assist with New Features:** When making changes or adding new features, Copilot can assist by suggesting potential improvements or solutions based on previous code structures.
- **Patch Assistance:** Utilize Copilot to draft initial patch methods, ensuring they adhere to the mod's coding conventions and main objectives.
- **Optimization Insight:** Leverage Copilot to suggest potential optimizations for tick management and other core functions, to improve performance and compatibility.
- **Code Consistency:** Encourage Copilot to generate code that maintains consistency with existing naming conventions and patterns defined in this document.

By following these instructions, you should be able to create and maintain a well-organized, efficient, and compatible mod project. If any issues arise during development, refer back to these guidelines for structured problem-solving.
