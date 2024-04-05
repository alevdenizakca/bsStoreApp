using System.Runtime.CompilerServices;
using WebApi.Utilities.Formatters;

namespace WebApi.Extentions
{
    public static class IMvcBuilderExtentions
    {
        public static IMvcBuilder AddCustomCsvFormatter(this IMvcBuilder builder) => builder.AddMvcOptions(config=> config.OutputFormatters
        .Add(new CsvOutputFormatter()));
    }
}
