using Microsoft.ML.Transforms.Image;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

namespace DotnetConf2019BCN.API.ML.DataModels
{
    public class ImageInputData
    {
        [ImageType(227, 227)]
        public Bitmap Image { get; set; }
    }
}
