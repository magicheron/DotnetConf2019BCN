

using Microsoft.ML.Data;

namespace DotnetConf2019BCN.API.ML.DataModels
{
    public class ImageLabelPredictions
    {
        //TODO: Change to fixed output column name for TensorFlow model
        [ColumnName("loss")]
        public float[] PredictedLabels;
    }
}
