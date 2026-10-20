# Flat Nivalis Times

*Newspaper Readability Mod*

Make Nivalis Times easier to read while keeping the newspaper in the character's hands.

Version: **1.0.0**.

## Features

- Flatten the newspaper surface and remove its subtle swaying.
- Stop the reading idle animation while preserving the lift and lower animations.
- Adjust the grip and thumbs to the flat paper.
- Turn the readability features on or off together from **Settings > Gameplay > Improve newspaper readability**. Changes apply immediately, without restarting the game or reopening the newspaper.
- Keep the game's newspaper content, language and weather display.

The option is available in both title-screen and in-game settings. It follows the game's language and supports English, German, French, Korean, Japanese, Simplified Chinese, Traditional Chinese, Spanish, Portuguese, Russian and Turkish.

These changes apply only to the Nivalis Times newspaper.

## Requirements

- [Nivalis Nights on Steam](https://store.steampowered.com/app/1488490/Nivalis_Nights/) for Windows x64.
- BepInEx 6 Unity IL2CPP for Windows x64, installed and working with your game version.

Supported game version: **[Small patch after Update #5](https://store.steampowered.com/news/app/1488490/view/705534184444133867)**, the **2026-10-16 release**, Steam build **25984046**. Compatibility with other game versions has not been established.

The tested BepInEx loader is **6.0.0-be.788+5b766a3**. Other builds are not covered by this validation. Game, BepInEx and other dependency files are not included. No other mods are required.

## Installation

1. Download BepInEx from the [official Bleeding Edge builds page](https://builds.bepinex.dev/projects/bepinex_be). Choose Unity IL2CPP, Windows x64. The tested archive is `BepInEx-Unity.IL2CPP-win-x64-6.0.0-be.788+5b766a3.zip`.
2. Extract BepInEx into the game folder containing `Nivalis Nights.exe`. Launch the game once to complete setup, then close it.
3. Download the compiled Flat Nivalis Times mod from the release files. Source-code archives are for building the plugin, not for installation.
4. Place the DLL at this path relative to the game folder:

```text
BepInEx/plugins/NivalisNights.FlatNivalisTimes/NivalisNights.FlatNivalisTimes.dll
```

Launch the game. The readability option is enabled by default.

## Configuration

Open **Settings > Gameplay > Improve newspaper readability** to change the option. Changes apply immediately and save to:

```text
BepInEx/config/NivalisNights.FlatNivalisTimes.cfg
```

```ini
[General]
Enabled = true
```

Turning it off restores the original newspaper shape, idle movement and grip. The choice is saved only in the mod config and does not affect game saves. You do not need to press the game's Apply button. Restoring Gameplay defaults also returns this option to its default enabled value.

To edit the config manually, close the game, edit `Enabled`, then relaunch. Live changes should use the gameplay option.

## Updating

Close the game before replacing the DLL. Keep only one Flat Nivalis Times DLL anywhere under `BepInEx/plugins`. Keep the config to retain your preference.

## Uninstallation

Close the game, remove `NivalisNights.FlatNivalisTimes.dll`, then restart. You may also remove its config if you no longer want the saved preference. A remaining config has no effect when the mod is absent. No changes are written to game assets or save data. Leave BepInEx and other mods in place if they are still needed.

## Troubleshooting

The startup log should list **Flat Nivalis Times 1.0.0** and **Newspaper Readability Mod**. If the option cannot be saved or applied, it shows an error message and the mod logs the failure. Include the mod version, game build, reproduction steps and related `BepInEx/LogOutput.log` entries in a report. Review logs for personal information before sharing them.

If the option is missing, check that BepInEx loaded the mod and that the DLL is installed at the path shown above. If the newspaper still moves, check that **Improve newspaper readability** is enabled.

## Building from source

See the repository [build instructions](../../README.md#building-from-source). Build this project independently; other mods are not required.

## Development

OpenAI Codex was used to assist development. The mod author reviewed the changes and check results and performed in-game testing.

## License and third-party rights

Flat Nivalis Times source code, compiled mod and accompanying authored documentation are licensed under **0BSD (Zero-Clause BSD)**. See [LICENSE](LICENSE).

Nivalis Nights, BepInEx, Unity, Harmony, Il2CppInterop and other third-party software or assets remain subject to their respective rights holders' licenses and terms. The license does not relicense them.

Original game files, copied or decompiled game code, game assets and third-party library binaries are not included. Newspaper content, game fonts, the hand model and other game assets are referenced from the installed game at runtime and are not redistributed.
