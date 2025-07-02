using Oqtane.Models;
using Oqtane.Themes;

namespace [Owner].Theme.[Theme];

public class ThemeInfo : ITheme
{
    /// <summary>
    /// The Theme will let Oqtane know what theme this is, and how it should be loaded / rendered etc.
    /// </summary>
    public Oqtane.Models.Theme Theme => new()
    {
        Name = "Cre8magic [Theme]",
        Version = "1.0.0",
        PackageName = "[Owner].Theme.[Theme]",
        ThemeSettingsType = ThemeSettingsType,
        ContainerSettingsType = ContainerSettingsType,
        Resources =
        [
            new Stylesheet("~/Theme.css"),
            new Stylesheet("~/Oqtane.css"),
            new Stylesheet ("~/styles.min.css"), // Bootstrap generated with Sass/Webpack
            new Script("~/bootstrap.bundle.min.js"),
        ]
    };

    #region Settings Type Names for Oqtane to Auto-Inject in the Theme/Module Settings Dialogs

    /// <summary>
    /// The assembly name, used to construct the full type names for settings.
    /// </summary>
    /// <remarks>
    /// The assembly name should not provide version etc. because it will be stored in the database, and future updates would result in a mismatch.
    /// </remarks>
    private static readonly string AssemblyName = typeof(ContainerSettings).Assembly.GetName().Name!;

    /// <summary>
    /// The Theme Settings Type will let Oqtane know what control to show in the page settings, and it will also be used to load language resources.
    /// </summary>
    public static readonly string ThemeSettingsType = $"{typeof(ThemeSettings).FullName}, {AssemblyName}";

    /// <summary>
    /// The Container Settings Type will let Oqtane know what control to show in the module settings, and it will also be used to load language resources.
    /// </summary>
    public static readonly string ContainerSettingsType = $"{typeof(ContainerSettings).FullName}, {AssemblyName}";

    #endregion

    /// <summary>
    /// Prefix used for all keys/settings in this theme.
    /// </summary>
    internal static string KeyPrefix = typeof(ThemeInfo).Namespace!;


    public const string DefaultFooterHtml = """
                                                <div class="container py-4 d-flex justify-content-md-between flex-column flex-md-row text-white">
                                                    <ul class="theme-footer-address d-flex flex-column flex-xl-row" itemscope itemtype="http://schema.org/LocalBusiness">
                                                        <li>
                                                            <strong itemprop="name">Cre8magic Oqtane Theme BS5 by 2sxc </strong>
                                                        </li>
                                                        <li>
                                                            <span itemprop="address" itemscope itemtype="http://schema.org/PostalAddress">
                                                                <span itemprop="streetAddress">Cre8magic Road 42</span>,
                                                                <span itemprop="postalCode">2742</span>
                                                                <span itemprop="addressLocality">Cre8magic City</span>,
                                                                <span itemprop="addressCountry">Cre8magic Country</span>
                                                            </span>
                                                        </li>
                                                        <li><a href="tel:+41 234 56 78">+41 234 56 78</a></li>
                                                        <li>
                                                            <span data-madr1="shine" data-madr2="example" data-madr3="com" data-linktext=""></span>
                                                        </li>
                                                    </ul>
                                                    <div class="theme-footer-imprint">
                                                        <a href="/"> Terms of Use </a> |
                                                        <a href="/"> Privacy </a>
                                                    </div>
                                                </div>
                                            """;

    // TODO: @2dg - make same solution with button to add this in settings
    public const string DefaultThemeCss = """
                                          :root,
                                          [data-bs-theme='default-theme'] {
                                            /* BS Main Colors */
                                            --bs-primary: #e23835;
                                            --bs-primary-rgb: 226, 56, 53;
                                            --bs-secondary: #386bb7;
                                            /* Background Color for the backmost level */
                                            --theme-backdrop-bg: #e5e5e5;
                                            /* Default Background-Color and Color */
                                            --bs-body-bg: #fff;
                                            --bs-body-color: #161615;
                                            /* Theme Classes */
                                            --theme-page-main-bg: var(--bs-body-bg);
                                            --theme-breadcrumb-bg: var(--theme-page-main-bg);
                                            --theme-footer-bg: var(--bs-primary);
                                            --theme-nav-bg: #fff;
                                            /* Override Link-Colors */
                                            --bs-nav-link-color: var(--bs-primary);
                                            --bs-link-color: var(--bs-primary);
                                            --bs-link-hover-color: var(--bs-body-color);
                                            /* Font Setting */
                                            --theme-font: system-ui, -apple-system, 'Segoe UI', 'Roboto', 'Helvetica Neue',
                                              'Noto Sans', 'Liberation Sans', Arial, sans-serif, 'Apple Color Emoji',
                                              'Segoe UI Emoji', 'Segoe UI Symbol', 'Noto Color Emoji';
                                            --theme-font-headlines: var(--theme-font);
                                            --bs-body-font-family: var(--theme-font);
                                            --bs-body-font-size: 1rem;
                                            --bs-body-font-weight: 400;
                                            --bs-body-line-height: 1.5;
                                            --bs-body-h1-font-size: 2.5rem;
                                            /* Border Radius  */
                                            --bs-border-radius: 0.375rem;
                                            --bs-border-radius-sm: 0.25rem;
                                            --bs-border-radius-lg: 0.5rem;
                                            --bs-border-radius-xl: 1rem;
                                            --bs-border-radius-xxl: 2rem;
                                            /* Shadows */
                                            --bs-box-shadow: 0 0.5rem 1rem rgba(0, 0, 0, 0.15);
                                            --bs-box-shadow-sm: 0 0.125rem 0.25rem rgba(0, 0, 0, 0.075);
                                            --bs-box-shadow-lg: 0 1rem 3rem rgba(0, 0, 0, 0.175);
                                            --bs-box-shadow-inset: inset 0 1px 2px rgba(0, 0, 0, 0.075);
                                            .breadcrumb {
                                              --bs-breadcrumb-font-size: 14px;
                                            }

                                            /* Main Button-Colors */
                                            .btn-primary {
                                              --bs-btn-color: var(--bs-white);
                                              --bs-btn-bg: var(--bs-primary);
                                              --bs-btn-border-color: var(--bs-primary);
                                              --bs-btn-hover-color: var(--bs-white);
                                              --bs-btn-hover-bg: color-mix(in srgb, var(--bs-primary) 15%, #000);
                                              --bs-btn-hover-border-color: color-mix(
                                                in srgb,
                                                var(--bs-primary) 15%,
                                                #000
                                              );
                                              --bs-btn-active-color: var(--bs-white);
                                              --bs-btn-active-bg: color-mix(in srgb, var(--bs-primary) 15%, #000);
                                              --bs-btn-active-border-color: color-mix(
                                                in srgb,
                                                var(--bs-primary) 15%,
                                                #000
                                              );
                                              --bs-btn-disabled-color: var(--bs-white);
                                              --bs-btn-disabled-bg: var(--bs-primary);
                                              --bs-btn-disabled-border-color: var(--bs-primary);
                                            }

                                            .btn-outline-primary {
                                              --bs-btn-color: var(--bs-primary);
                                              --bs-btn-bg: var(--bs-white);
                                              --bs-btn-border-color: var(--bs-primary);
                                              --bs-btn-hover-color: var(--bs-white);
                                              --bs-btn-hover-bg: var(--bs-primary);
                                              --bs-btn-hover-border-color: var(--bs-primary);
                                              --bs-btn-active-color: var(--bs-white);
                                              --bs-btn-active-bg: var(--bs-primary);
                                              --bs-btn-active-border-color: var(--bs-primary);
                                              --bs-btn-disabled-color: var(--bs-primary);
                                              --bs-btn-disabled-bg: transparent;
                                              --bs-btn-disabled-border-color: var(--bs-primary);
                                            }

                                            .btn-secondary {
                                              --bs-btn-color: var(--bs-white);
                                              --bs-btn-bg: var(--bs-secondary);
                                              --bs-btn-border-color: var(--bs-secondary);
                                              --bs-btn-hover-color: var(--bs-white);
                                              --bs-btn-hover-bg: color-mix(in srgb, var(--bs-secondary) 15%, #000);
                                              --bs-btn-hover-border-color: color-mix(
                                                in srgb,
                                                var(--bs-secondary) 15%,
                                                #000
                                              );
                                              --bs-btn-active-color: var(--bs-white);
                                              --bs-btn-active-bg: color-mix(in srgb, var(--bs-secondary) 15%, #000);
                                              --bs-btn-active-border-color: color-mix(
                                                in srgb,
                                                var(--bs-secondary) 15%,
                                                #000
                                              );
                                              --bs-btn-disabled-color: var(--bs-white);
                                              --bs-btn-disabled-bg: var(--bs-secondary);
                                              --bs-btn-disabled-border-color: var(--bs-secondary);
                                            }

                                            .btn-outline-secondary {
                                              --bs-btn-color: var(--bs-secondary);
                                              --bs-btn-border-color: var(--bs-secondary);
                                              --bs-btn-hover-color: #fff;
                                              --bs-btn-hover-bg: var(--bs-secondary);
                                              --bs-btn-hover-border-color: var(--bs-secondary);
                                              --bs-btn-focus-shadow-rgb: 13, 110, 253;
                                              --bs-btn-active-color: #fff;
                                              --bs-btn-active-bg: var(--bs-secondary);
                                              --bs-btn-active-border-color: var(--bs-secondary);
                                              --bs-btn-active-shadow: inset 0 3px 5px rgba(0, 0, 0, 0.125);
                                              --bs-btn-disabled-color: var(--bs-secondary);
                                              --bs-btn-disabled-bg: transparent;
                                              --bs-btn-disabled-border-color: var(--bs-secondary);
                                              --bs-gradient: none;
                                            }

                                            .footer {
                                              --bs-link-color: var(--bs-white);
                                              --bs-link-hover-color: var(--bs-body-color);
                                            }

                                            .navbar-nav {
                                              --bs-nav-link-color: var(--bs-body-color);
                                              --bs-nav-link-hover-color: var(--bs-primary);
                                              --bs-navbar-active-color: var(--bs-primary);
                                            }

                                            .table {
                                              --bs-table-bg: var(--bs-white);
                                            }
                                          }
                                          """;

}