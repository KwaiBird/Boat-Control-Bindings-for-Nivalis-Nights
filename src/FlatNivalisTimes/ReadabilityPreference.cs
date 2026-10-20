using BepInEx.Configuration;

namespace NivalisNights.FlatNivalisTimes;

// Persistence has no Unity/game dependency. The only file is the supplied plugin ConfigFile.
internal sealed class ReadabilityPreference
{
    private readonly ConfigFile file;
    private readonly ConfigEntry<bool> entry;
    internal bool Value => entry.Value;

    internal ReadabilityPreference(ConfigFile file)
    {
        this.file = file;
        file.SaveOnConfigSet = false;
        entry = file.Bind("General", "Enabled", true,
            "Improve newspaper readability. Can be changed live in Settings > Gameplay. Stored only in this mod config.");
    }

    internal void Set(bool value)
    {
        bool previous = entry.Value;
        try { entry.Value = value; file.Save(); }
        catch { entry.Value = previous; throw; }
    }

    internal void Restore(bool value)
    {
        // Runtime restoration has already happened. Keep memory/UI aligned with it even
        // if the disk is unwritable; the caller reports that persistence failed.
        entry.Value = value;
        file.Save();
    }
}
