using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreConf2019.DataModels
{
    public class SentimentPrediction : SentimentData
    {

        [ColumnName("PredictedLabel")]
        public bool Prediction { get; set; }

        public float Probability { get; set; }

        public float Score { get; set; }
    }
}
