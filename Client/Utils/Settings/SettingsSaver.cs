using System;
using System.Linq;
using System.Threading.Tasks;
using Oqtane.Services;

namespace [Owner].Theme.[Theme].Utils.Settings;

/// <summary>
/// Tool to help save settings for anything.
/// </summary>
/// <remarks>
/// It must be internal, to ensure that it will not conflict with other themes which may have the same class.
/// </remarks>
/// <param name="settingService">The settings service, should use dependency injection</param>
internal class SettingsSaver(ISettingService settingService)
{
    public async Task Save(SettingsReader reader, string prefix)
    {
        // Only process settings which belong to this theme,
        // otherwise we may inadvertently modify settings which belong to something else.
        var toProcess = reader.Settings
            .Where(pair => pair.Key.StartsWith(prefix, StringComparison.InvariantCultureIgnoreCase))
            .ToDictionary();

        // Check for empty first, because we compare with the existing settings
        // to see if there was a value to remove in the first place.
        var toRemove = toProcess
            .Where(kvp => string.IsNullOrEmpty(kvp.Value))
            .Select(kvp => kvp.Key)
            .ToList();

        // Only update the ones we didn't remove
        var settings = toProcess
            .Where(pair => !string.IsNullOrEmpty(pair.Value))
            .ToDictionary();

        // If we have any updates left, then update them
        if (settings.Any())
            await settingService.UpdateSettingsAsync(settings, reader.EntityName, reader.EntityId);

        // Now delete the empty settings
        foreach (var settingName in toRemove)
            await settingService.DeleteSettingAsync(reader.EntityName, reader.EntityId, settingName);
        
    }
}