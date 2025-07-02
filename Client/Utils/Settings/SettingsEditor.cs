using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace [Owner].Theme.[Theme].Utils.Settings;

internal class SettingsEditor
{
    public ConcurrentDictionary<string, SettingBinder> Binders { get; } = new();

    /// <summary>
    /// The reader/manager which manages all the settings.
    /// </summary>
    /// <remarks>
    /// Will be null at first, but once settings are loaded, will be filled by the <see cref="SettingsEditor"/> .
    /// </remarks>
    public SettingsReader? Main { get; private set; }

    public SettingsReader Fallback { get; private set; } = new();

    public bool UseFallback = true;

    /// <summary> Indexer to access binders by setting name </summary>
    /// <param name="settingName"></param>
    /// <returns></returns>
    public SettingBinder this[string settingName]
        => Binders.GetOrAdd(settingName, newName => new(this, newName));

    public void Setup(SettingsReader main, SettingsReader? fallback)
    {
        Main = main;
        Fallback = fallback ?? new();
        UseFallback = fallback != null;
    }

    public bool ShowFallback(string key)
    {
        // If no fallback available, then don't show it
        if (!UseFallback || Main == null)
            return false;

        // If the main settings already have a value, then don't show the fallback
        if (Main.TryGet(key, out var value) && !string.IsNullOrEmpty(value))
            return false;

        // Only show fallback if we have anything
        return Fallback.TryGet(key, out value) && !string.IsNullOrEmpty(value);
    }

    /// <summary>
    /// Save the current settings to the database.
    /// </summary>
    /// <param name="prefix">Prefix to filter for, so we only save settings which belong to this control.</param>
    /// <returns></returns>
    public async Task Save(string prefix)
    {
        if (Main?.SettingService == null)
            throw new("SettingService is null, cannot save settings. Did you forget to pass it in the constructor?");
        await new SettingsSaver(Main.SettingService).Save(Main, prefix);
    }

}