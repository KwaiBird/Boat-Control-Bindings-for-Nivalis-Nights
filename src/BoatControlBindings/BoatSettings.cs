namespace NivalisNights.BoatControlBindings;

internal static class BoatSettings
{
    internal const string Id = "NivalisNights.BoatControlBindings";

    internal static string Resolve(string directory)
    {
        string path = Path.Combine(directory, Id + ".ini");
        // Keep an existing new configuration authoritative; preserve the old file for rollback.
        if (!File.Exists(path))
            foreach (string name in new[] { "local.nivalisnights.boatcontrolbindings.ini", "local.nivalisnights.boatshortcuts.ini" })
            {
                string legacy = Path.Combine(directory, name);
                if (!File.Exists(legacy)) continue;
                File.Copy(legacy, path, false);
                break;
            }
        return path;
    }
}
