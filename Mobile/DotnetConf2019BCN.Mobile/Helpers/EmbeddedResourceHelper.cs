using System.IO;
using System.Reflection;

namespace DotnetConf2019BCN.Mobile.Helpers
{
    internal static class EmbeddedResourceHelper
    {
        internal static string Load(string resourceName)
        {
            var assembly = Assembly.GetExecutingAssembly();

            using (var stream = assembly.GetManifestResourceStream(resourceName))
            using (var reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }
    }
}
