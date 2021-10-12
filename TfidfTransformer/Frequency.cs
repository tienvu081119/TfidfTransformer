using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TfidfTransformer
{
    class Frequency : TfidfTransformer
    {
        float[,] termMatrix;
        double[] inverseMatrix;
        public float[,] TermFrequency(int[,] matrix)
        {
            termMatrix = new float[matrix.GetLength(0), matrix.GetLength(1)];
            float[] sum_i = new float[matrix.GetLength(0)];           
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    sum_i[i] += matrix[i, j];
                }
            }
            Console.WriteLine(string.Join(',', sum_i));         
            
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    termMatrix[i, j] = matrix[i, j] / sum_i[i];                 
                }               
            }
            return termMatrix;
        }
        public double[] InverseDocumentFrequency(int[,] matrix)
        {
            inverseMatrix = new double[matrix.GetLength(1)];
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    if (matrix[j, i] != 0)
                    {
                        inverseMatrix[i]++;
                    }                    
                }
                double values = matrix.GetLength(0) / inverseMatrix[i];
                inverseMatrix[i] = Math.Log2(values);
            } 
            return inverseMatrix;
        }
        public float[,] Term_InverseDocument_Frequency(int[,] matrix)
        {
            float[,] mTerm = new float[matrix.GetLength(0), matrix.GetLength(1)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    mTerm[i, j] = (float)(termMatrix[i, j] * inverseMatrix[i]);
                }
            }
            return mTerm;
        }
    }
}
