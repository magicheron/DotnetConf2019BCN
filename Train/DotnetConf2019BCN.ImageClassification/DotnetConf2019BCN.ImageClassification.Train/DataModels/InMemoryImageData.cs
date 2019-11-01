using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DotnetConf2019BCN.ImageClassification.Train.DataModels
{
    public class InMemoryImageData
    {
        public byte[] Image;

        public string Label;

        public string ImageFileName;
    }
}
