using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TfidfTransformer
{
    class TfidfTransformer : ITfidfTransformer
    {
        Dictionary<string, int> dict;
        char[] separator = { ' ', ',', '.', '?' };
        public string[] FeatureNames => new List<string>(dict.Keys).ToArray();

        public void Fit(string[] corpus)
        {
            dict = new Dictionary<string, int>();
            int c = 0;
            foreach (string line in corpus)
            {
                string[] words = line.Split(separator);
                foreach (string w in words)
                {
                    if (!string.IsNullOrEmpty(w))
                    {
                        string k = w.Trim().ToLower();
                        if (!dict.ContainsKey(k))
                        {
                            dict[k] = c++;
                        }
                    }
                }
            }
        }

        public int[,] FitTransform(string[] corpus)
        {
            Fit(corpus);
            return Transform(corpus);
        }
        public int[,] Transform(string[] corpus)
        {
            int[,] matrix = new int[corpus.Length, dict.Count];
            for (int i = 0; i < corpus.Length; i++)
            {
                string[] words = corpus[i].Split(separator);
                for (int j = 0; j < words.Length; j++)
                {
                    string w = words[j];
                    if (!string.IsNullOrEmpty(w))
                    {
                        string k = w.ToLower();
                        matrix[i, dict[k]] += 1;
                    }
                }
            }
            return matrix;
        }        
    }
}
