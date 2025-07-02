using System.Collections.Generic;

namespace [Owner].Theme.[Theme].Utils.Settings;

/// <summary>
/// Helper to bind a value from a settings dictionary to Razor code.
/// </summary>
/// <param name="editor"></param>
/// <param name="key"></param>
internal class SettingBinder(SettingsEditor editor, string key)
{
    public string? Value
    {
        get => editor.Main?.Settings.GetValueOrDefault(key);
        set
        {
            if (editor.Main == null)
                return;

            editor.Main.Settings[key] = value ?? "";
        }
    }
}