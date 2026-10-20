using BepInEx.Configuration;

namespace NivalisNights.FlatNivalisTimes;

internal static class AccessibilitySettings
{
    private static ReadabilityPreference preference = null!;
    internal static bool Enabled => preference.Value;
    internal static bool HasError { get; private set; }

    internal static void Initialize(ConfigFile file)
    {
        preference = new ReadabilityPreference(file);
        try { preference.Restore(preference.Value); }
        catch (Exception error)
        {
            HasError = true;
            Plugin.ReportOnce("initial config write failed", error);
        }
    }

    internal static void Request(bool value)
    {
        HasError = false;
        if (value == Enabled) { SettingsUi.RefreshAll(); return; }
        try
        {
            preference.Set(value);
            PaperStates.RetryRequested();
        }
        catch (Exception error)
        {
            HasError = true;
            Plugin.ReportOnce("config write rejected", error);
        }
        SettingsUi.RefreshAll();
    }

    internal static void Reject(bool retainedValue, Exception error)
    {
        HasError = true;
        try { preference.Restore(retainedValue); }
        catch (Exception saveError) { Plugin.ReportOnce("config rollback failed", saveError); }
        SettingsUi.RefreshAll();
        Plugin.ReportOnce("live switch rejected", error);
    }
}
