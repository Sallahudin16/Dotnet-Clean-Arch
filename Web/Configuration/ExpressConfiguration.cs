using Asp.Versioning;
using Web.Options;

namespace Web.Configuration
{
    public static class ExpressConfiguration
    {
        public static void ConfigureApiVersioning(IServiceCollection Services)
        {
            var apiVersionBuilder = Services.AddApiVersioning(config =>
            {
                config.DefaultApiVersion = new ApiVersion(1, 0);
                config.AssumeDefaultVersionWhenUnspecified = true;
                config.ReportApiVersions = true;
                config.ApiVersionReader = new UrlSegmentApiVersionReader();
            });

            apiVersionBuilder.AddApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });

            //Add Swagger
            Services.AddSwaggerGen();
            //Configure Versioning for swagger
            Services.ConfigureOptions<ConfigureSwaggerOptions>();
            Services.AddEndpointsApiExplorer();
        }
    }
}
