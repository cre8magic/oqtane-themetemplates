using System.Collections.Generic;
using Oqtane.Models;
using Oqtane.Themes;
using Oqtane.Shared;

namespace [Owner].Cre8magic.Theme.[Theme]
{
    public class ThemeInfo : ITheme
    {
        public Oqtane.Models.Theme Theme => new Oqtane.Models.Theme
        {
            Name = "[Owner] Cre8magic [Theme]",
            Version = "[FrameworkVersion]",
            PackageName = "[Owner].Cre8magic.Theme.[Theme]",
            ThemeSettingsType = "[Owner].Cre8magic.Theme.[Theme].ThemeSettings, [Owner].Cre8magic.Theme.[Theme].Client.Oqtane",
            ContainerSettingsType = "[Owner].Cre8magic.Theme.[Theme].ContainerSettings, [Owner].Cre8magic.Theme.[Theme].Client.Oqtane",
            Resources = new List<Resource>()
            {
		        // obtained from https://cdnjs.com/libraries
                 new Resource { ResourceType = ResourceType.Stylesheet, Url = "~/Theme.css"},
                 new Resource { ResourceType = ResourceType.Stylesheet, Url = "~/Oqtane.css"},
                 new Resource { ResourceType = ResourceType.Stylesheet, Url = "~/styles.min.css"}, // Bootstrap generated with Sass/Webpack
                 new Resource { ResourceType = ResourceType.Script,Url = "~/bootstrap.bundle.min.js" } // Bootstrap JS
            }
        };

    }
}
