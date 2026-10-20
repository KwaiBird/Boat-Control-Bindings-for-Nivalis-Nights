# Nivalis Nights Mods

Independent mods for [Nivalis Nights](https://store.steampowered.com/app/1488490/Nivalis_Nights/) on Windows x64.

Install only the mods you want. Each mod has its own DLL, configuration file, version and license notice; neither mod requires the other.

| Mod | Purpose | Version | Instructions | Download |
| --- | --- | --- | --- | --- |
| Boat Control Bindings | Keyboard and controller shortcuts for boat controls | 0.1.8 | [README](src/BoatControlBindings/README.md) | [Release](https://github.com/KwaiBird/Nivalis-Nights-Mods/releases/tag/v0.1.8) |
| Flat Nivalis Times | Newspaper Readability Mod | 1.0.0 | [README](src/FlatNivalisTimes/README.md) | [Release](https://github.com/KwaiBird/Nivalis-Nights-Mods/releases/tag/flat-nivalis-times-v1.0.0) |

Download each mod separately from its release page. Choose the mod ZIP to install it; source ZIPs are for building from source. Compiled DLLs are distributed as release downloads, rather than committed to the source tree.

## Requirements

- [Nivalis Nights on Steam](https://store.steampowered.com/app/1488490/Nivalis_Nights/) for Windows x64, Steam build **25984046**: **[Small patch after Update #5](https://store.steampowered.com/news/app/1488490/view/705534184444133867)**, released **2026-10-16**.
- BepInEx 6 Unity IL2CPP for Windows x64, installed and working with that game version.
- Tested loader: **6.0.0-be.788+5b766a3**. Compatibility with other game or loader versions has not been established.

Each mod README includes its complete installation, configuration, update and removal instructions. Game, BepInEx and other dependency files are not included.

## Building from source

Install the .NET SDK specified by `global.json` (**8.0.426**, with patch roll-forward enabled). Launch the game with BepInEx once to generate the IL2CPP interop assemblies, then close the game.

Build only the desired project from the repository root:

```powershell
dotnet build src/BoatControlBindings/NivalisNights.BoatControlBindings.csproj -c Release
dotnet build src/FlatNivalisTimes/NivalisNights.FlatNivalisTimes.csproj -c Release
```

The default game directory is `C:\Program Files (x86)\Steam\steamapps\common\Nivalis Nights`. For another location, add `-p:GameDir="D:\SteamLibrary\steamapps\common\Nivalis Nights"` to the selected command.

The resulting mod DLL is in that project's `bin/Release/net6.0` folder. Install only the mod DLL as described in its README. Referenced game and loader assemblies have `Private=false` and are not bundled. This repository contains no additional package-feed configuration.

## Development and verification

OpenAI Codex was used to assist development. The mod author reviewed the changes and check results, performed in-game testing, and carried out final release verification.

## License

Both mods are licensed under **0BSD (Zero-Clause BSD)**. See the repository [LICENSE](LICENSE), [Boat license](src/BoatControlBindings/LICENSE) and [Flat Nivalis Times license](src/FlatNivalisTimes/LICENSE).

Game and third-party rights remain with their respective rights holders. Original game files, copied or decompiled game code, game assets, and third-party library binaries are not distributed here.
