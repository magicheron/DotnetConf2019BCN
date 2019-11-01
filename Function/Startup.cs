using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.ML;
using NetCoreConf2019;
using NetCoreConf2019.DataModels;
using System;
using System.Collections.Generic;
using System.Text;

[assembly: FunctionsStartup(typeof(Startup))]
namespace NetCoreConf2019
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddPredictionEnginePool<SentimentData, SentimentPrediction>()
                .FromFile("MLModels/sentiment_model.zip");
        }
    }
}
