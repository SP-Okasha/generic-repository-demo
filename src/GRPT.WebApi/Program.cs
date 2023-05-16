using GRPT.Model.Common;
using GRPT.WebApi.Common;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
ConfigurationExtension.ServiceConfigurations(builder.Services, builder.Configuration);
//Getting application settings configs from appSettings.json 
builder.Services.Configure<ApplicationSettingsModel>(builder.Configuration.GetSection(ApplicationSettingsModel.ApplicationSettings));

builder.Host.UseSerilog((ctx, loggerConfiguration) => loggerConfiguration.ReadFrom.Configuration(ctx.Configuration));
var app = builder.Build();
//Configuring middlewares
ConfigurationExtension.ConfigureMiddleWares(app);
app.Run();