using Asp.Versioning;
using Asp.Versioning.ApiExplorer;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Web.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
Data.Configuration.ContainerBindings.AddRepositories(
    builder.Services, 
    builder.Configuration.GetConnectionString("dev")
);

builder.Services.AddMediatR(
    config => config.RegisterServicesFromAssembly(
                typeof(Application.AssemblyReference).Assembly));

builder.Services
    .AddControllers()
    .AddApplicationPart(typeof(REST.AssemblyReference).Assembly);

ExpressConfiguration.ConfigureApiVersioning(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();

    //Configure Swagger Ui for Versionsing
    app.UseSwaggerUI(options =>
    {
        var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

        foreach (var description in provider.ApiVersionDescriptions)
        {
            options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", 
                description.ApiVersion.ToString());
        }
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
