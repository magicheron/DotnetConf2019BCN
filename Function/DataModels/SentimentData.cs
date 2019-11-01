using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreConf2019.DataModels
{
    public class SentimentData
    {
        [LoadColumn(0)]
        public string SentimentText { get; set; }

        [LoadColumn(1)]
        [ColumnName("Label")]
        public bool Sentiment { get; set; }
    }
}
