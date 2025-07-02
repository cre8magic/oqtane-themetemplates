namespace [Owner].Theme.[Theme];
internal class MyThemeSettings(SettingsReader settings)
{
    internal static string KeyLogin = $"{KeyPrefix}:Login";
    internal static string KeyRegister = $"{KeyPrefix}:Register";
    internal static string KeyFooterHtml = $"{KeyPrefix}:FooterHtml";
    internal static string KeyThemeCss = $"{KeyPrefix}:ThemeCss";

    public string FooterHtml => settings.Get(KeyFooterHtml, DefaultFooterHtml);

    public bool ShowRegister => settings.Bool(KeyRegister, true);

    public bool ShowLogin => settings.Bool(KeyLogin, true);

    public bool TryGetThemeCss([NotNullWhen(true)] out string? value)
        => settings.TryGet(KeyThemeCss, out value);
}
