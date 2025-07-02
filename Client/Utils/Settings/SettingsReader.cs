using System.Collections.Generic;
using Oqtane.Services;

namespace [Owner].Theme.[Theme].Utils.Settings;

internal class SettingsReader(ISettingService? settingService, string entityName, int entityId, Dictionary<string, string> settings)
{
    public SettingsReader(): this(null, "Unknown", -1, [])
    { }

    public string EntityName => entityName;

    public int EntityId => entityId;

    public Dictionary<string, string> Settings => settings;

    public bool IsMerged { get; init; }

    internal ISettingService? SettingService = settingService;

    public string Get(string key, string defaultValue = "")
        => SettingService?.GetSetting(settings, key, defaultValue) ?? defaultValue;

    public bool TryGet(string key, [NotNullWhen(true)] out string? value)
        => TryGet(key, "", out value);

    public bool TryGet(string key, string defaultValue, [NotNullWhen(true)] out string? value)
    {
        value = SettingService == null
            ? defaultValue
            : Get(key, defaultValue);
        return !string.IsNullOrEmpty(value);
    }

    public bool Bool(string key, bool defaultValue = false)
    {
        if (string.IsNullOrEmpty(key))
            return defaultValue;
        var asString = Get(key);
        if (string.IsNullOrEmpty(asString))
            return defaultValue;
        return bool.TryParse(asString, out var result)
            ? result
            : defaultValue;
    }

    public SettingsReader MergeWith(SettingsReader lowerPriorityReader)
    {
        if (SettingService == null)
            throw new("Cannot merge settings, because the SettingService is not set.");
        // Clone the dictionaries, to not modify the original ones
        var primary = new Dictionary<string, string>(Settings);
        var secondary = new Dictionary<string, string>(lowerPriorityReader.Settings);
        var mergedDic = SettingService.MergeSettings(secondary, primary) ?? [];

        return new(SettingService, entityName, entityId, mergedDic)
        {
            IsMerged = true,
        };
    }
}