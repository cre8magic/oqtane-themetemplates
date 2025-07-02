using System.Threading.Tasks;
using Oqtane.Models;
using Oqtane.Services;
using Oqtane.Shared;
using Oqtane.UI;

namespace [Owner].Theme.[Theme].Utils.Settings;

internal class OqtaneSettings(ISettingService settingService)
{
    internal async Task<SettingsReader> LoadModule(int moduleId)
        => await Load(EntityNames.Module, moduleId);
    internal async Task<SettingsReader> LoadPage(int pageId)
        => await Load(EntityNames.Page, pageId);
    internal async Task<SettingsReader> LoadSite(int siteId)
        => await Load(EntityNames.Site, siteId);

    public async Task<SettingsReader> Load(string entityName, int entityId)
    {
        var settings = await settingService.GetSettingsAsync(entityName, entityId);
        return new(settingService, entityName, entityId, settings);
    }

    public SettingsReader GetPage(PageState pageState)
    {
        var ofPage = pageState.Page.Settings ?? throw new("Page Settings cannot be null");
        var ofSite = pageState.Site.Settings ?? throw new("Site Settings cannot be null");

        var pageReader = new SettingsReader(settingService, EntityNames.Page, pageState.Page.PageId, ofPage);
        var siteReader = new SettingsReader(settingService, EntityNames.Site, pageState.Site.SiteId, ofSite);
        var merged = pageReader.MergeWith(siteReader);
        return merged;
    }

    public SettingsReader GetModule(Module moduleState)
    {
        var ofModule = moduleState.Settings ?? throw new("Module Settings cannot be null");
        var moduleReader = new SettingsReader(settingService, EntityNames.Module, moduleState.ModuleId, ofModule);
        return moduleReader;
    }
}
