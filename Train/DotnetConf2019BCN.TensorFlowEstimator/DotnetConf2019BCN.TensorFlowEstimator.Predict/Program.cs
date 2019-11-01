using System;
using System.IO;
using System.Threading.Tasks;
using DotnetConf2019BCN.TensorFlowEstimator.Predict.Model;
using static DotnetConf2019BCN.TensorFlowEstimator.Predict.Model.ConsoleHelpers;

namespace DotnetConf2019BCN.TensorFlowEstimator.Predict
{
    class Program
    {
        static void Main(string[] args)
        {
            string assetsRelativePath = @"../../../assets";
            string assetsPath = GetAbsolutePath(assetsRelativePath);

            
            var imagesFolder = Path.Combine(assetsPath, "inputs", "images-for-predictions");
            var imageClassifierZip = Path.Combine(assetsPath, "inputs", "MLNETModel", "CookiesClassifier.zip");

            try
            {
                var modelScorer = new ModelScorer(imagesFolder, imageClassifierZip);
                modelScorer.ClassifyImages();
            }
            catch (Exception ex)
            {
                ConsoleWriteException(ex.ToString());
            }

            ConsolePressAnyKey();
        }

        public static string GetAbsolutePath(string relativePath)
        {
            FileInfo _dataRoot = new FileInfo(typeof(Program).Assembly.Location);
            string assemblyFolderPath = _dataRoot.Directory.FullName;

            string fullPath = Path.Combine(assemblyFolderPath, relativePath);

            return fullPath;
        }
    }
}
