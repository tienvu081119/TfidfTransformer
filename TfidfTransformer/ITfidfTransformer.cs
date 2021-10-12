using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TfidfTransformer
{
    interface ITfidfTransformer
    {
        public string[] FeatureNames { get; }

        void Fit(string[] corpus);

        int[,] Transform(string[] corpus);

        int[,] FitTransform(string[] corpus);
    }
}
