# Boat Control Bindings for Nivalis Nights

Keyboard and controller bindings for the boat engine, docking and lights in [Nivalis Nights](https://store.steampowered.com/app/1488490/Nivalis_Nights/).

Version: 0.1.8.

## Boat Control Bindings

Control the engine, docking and lights without aiming at the cockpit buttons. The original interaction controls remain available.

| Action | Keyboard | Controller (Xbox labels) |
| --- | --- | --- |
| Start / stop engine | V | Y |
| Dock boat | B | X |
| Toggle lights | H | LB |

Engine start is available near the cockpit inside the boat. Docking is available only within docking range. Stopping follows the game's original behavior: dock when in range, otherwise leave the controls.

On-screen prompts show currently available actions and follow the game's language and input device. They fade with the HUD and move above the security-awareness panel when it is visible.

## Requirements

- [Nivalis Nights on Steam](https://store.steampowered.com/app/1488490/Nivalis_Nights/) for Windows x64.
- BepInEx 6 Unity IL2CPP for Windows x64, installed and working with your game version.

Supported game version: **[Small patch after Update #5](https://store.steampowered.com/news/app/1488490/view/705534184444133867)**, the **2026-10-16 release**, Steam build **25984046**. Compatibility with other game versions has not been established.

The tested BepInEx loader is **6.0.0-be.788+5b766a3**. Other builds are not covered by this validation. Game, BepInEx and other dependency files are not included.

## Installation

1. Download BepInEx from the [official Bleeding Edge builds page](https://builds.bepinex.dev/projects/bepinex_be). Choose the archive whose name starts with **`BepInEx-Unity.IL2CPP-win-x64-6.0.0`**. The tested archive is `BepInEx-Unity.IL2CPP-win-x64-6.0.0-be.788+5b766a3.zip`.
2. Extract BepInEx into the game folder containing `Nivalis Nights.exe`. Launch the game once to complete its initial setup, then close the game.
3. Download the compiled Boat Control Bindings DLL from the release files. Source-code archives are for building the plugin, not for installation.
4. Place the DLL in the folder below, relative to your game installation:

```text
BepInEx/plugins/NivalisNights.BoatControlBindings/NivalisNights.BoatControlBindings.dll
```

Launch the game to use Boat Control Bindings and generate its configuration file.

## Configuration

Configuration is stored in `BepInEx/config/NivalisNights.BoatControlBindings.ini` inside your game folder.

Set `Enabled = false` in `[General]` to disable Boat Control Bindings. Change bindings separately in `[Keyboard]` and `[Gamepad]`. Leave a value empty to disable that added action and its prompt.

Use a key or button name inside each device section; the device prefix is added automatically. For example:

```ini
[Keyboard]
Engine = v
Dock = b
Light = h

[Gamepad]
Engine = buttonNorth
Dock = buttonWest
Light = leftShoulder
```

Full paths such as `<Keyboard>/v` and `<Gamepad>/buttonNorth` remain supported, so existing INI files do not need to be rewritten. Device sections must match any explicit prefix.

Boat settings reload about once per second. Release the controls after changing settings before pressing them again.

Invalid or conflicting bindings are disabled and reported in the log. Steam Input or another mod may handle the same buttons separately.

## Updating

Close the game before replacing the DLL. Keep only one copy of Boat Control Bindings inside `BepInEx/plugins/`, including its subfolders. Existing configuration files can be kept.

### Updating from Boat Shortcuts

Remove the old `NivalisNights.BoatShortcuts.dll` from `BepInEx/plugins/` and its subfolders before installing Boat Control Bindings. Do not load both versions together.

The INI is now named `NivalisNights.BoatControlBindings.ini`. If it does not exist, the plugin imports `local.nivalisnights.boatcontrolbindings.ini`, or falls back to `local.nivalisnights.boatshortcuts.ini` when the former is absent. Existing settings take priority, and legacy files are preserved.

## Uninstallation

Close the game and remove `NivalisNights.BoatControlBindings.dll`. You may also remove `NivalisNights.BoatControlBindings.ini` if you no longer want its saved settings. Leave BepInEx and other plugins in place if they are still needed.

## Troubleshooting

If a binding does not work, check that the action is available in the current situation and that its INI value does not conflict with another control. Boat controls are unavailable during menus, loading, blocked interactions or incompatible held-item states.

For reports, include the plugin version, game build, input device, relevant bindings, reproduction steps and related entries from `BepInEx/LogOutput.log`. Review logs for personal information before sharing them.

Fonts, translated action names and controller icons are obtained from the installed game; they are not bundled with the plugin.

## Development and verification

OpenAI Codex was used to assist development. The mod author reviewed the changes and check results, performed in-game testing, and carried out final release verification.

## License and third-party rights

Boat Control Bindings source code and the compiled mod are licensed under **0BSD (Zero-Clause BSD)**. See [LICENSE](LICENSE) for the full text.

This license applies only to this mod. Nivalis Nights, BepInEx, Unity, Harmony, Il2CppInterop and all other third-party software or assets remain subject to their respective authors' and rights holders' licenses and terms. This mod does not relicense any of those materials.

No original game files, copied or decompiled game code, game assets, or third-party library binaries are included in the release archives. Fonts, translations and controller icons are referenced from the user's installed game at runtime, rather than redistributed.
