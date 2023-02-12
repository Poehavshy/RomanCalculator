using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RomanExpression.Application;
using RomanExpression.Application.Interfaces;
using RomanExpression.Calculator;
using RomanExpression.Calculator.Interfaces;
using RomanExpression.Translator;
using RomanExpression.Translator.Interfaces;

var host = CreateHostBuilder(args).Build();
var app = host.Services.GetRequiredService<IApplication>();
app.Start();

static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args).ConfigureServices((_, services) =>
        {
            services.AddSingleton<IApplication, Application>();
            services.AddSingleton<ICalculator, RomanCalculator>();
            services.AddSingleton<ITranslator, RomanTranslator>();
        })
        .ConfigureLogging(logging => 
        {
            logging.ClearProviders();
            logging.AddConsole();
        });