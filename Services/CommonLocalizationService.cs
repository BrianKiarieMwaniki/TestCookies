using TestCookies.Services;
using Microsoft.Extensions.Localization;
using System.Reflection;
using TestCookies.Resources;

namespace TestCookies.Services
{
    public class CommonLocalizationService
    {
        private readonly IStringLocalizer Localizer;
        public CommonLocalizationService(IStringLocalizerFactory factory)
        {
            var assemblyName = new AssemblyName(typeof(CommonResources).GetTypeInfo().Assembly.FullName);
            Localizer = factory.Create(nameof(CommonResources), assemblyName.Name);
        }

        public string Get(string key)
        {
            return Localizer[key];
        }
    }
}
