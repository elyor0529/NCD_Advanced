

namespace NCD.Infrastructure.Helpers
{
    using RazorEngine.Templating;
    using System.IO;

    public static class RazorHelper
    {
        /// <summary>
        /// Razor engine compile to HTML code
        /// </summary>
        /// <param name="path"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public static string Compile(string path, object model)
        {
            var templateService = new TemplateService();
            var template = File.ReadAllText(path);
            var cache = model.GetHashCode().ToString();

            return templateService.Parse(template, model, null, cache);
        }

    }
}
