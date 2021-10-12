using System;

namespace TfidfTransformer
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] corpus =
            {
                "This I Can't is the first document.",
                "This document is the second document.",
                "And this is the third one.",
                "Is this the first document?"
            };

            Frequency frequency = new Frequency();
            int[,] matrix = frequency.FitTransform(corpus);
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j]}");
                }
                Console.WriteLine();
            }

            Console.WriteLine("_________________________________");
            float[,] matrix2 = frequency.TermFrequency(matrix);
            for (int i = 0; i < matrix2.GetLength(0); i++)
            {
                for (int j = 0; j < matrix2.GetLength(1); j++)
                {
                    Console.Write($"{matrix2[i, j]}");
                }
                Console.WriteLine();
            }
            Console.WriteLine("_________________________________");
            double[] array = frequency.InverseDocumentFrequency(matrix);
            Console.WriteLine(string.Join(',', array));
            Console.WriteLine("_________________________________");
            float[,] matrix3 = frequency.Term_InverseDocument_Frequency(matrix);
            for (int i = 0; i < matrix3.GetLength(0); i++)
            {
                for (int j = 0; j < matrix3.GetLength(1); j++)
                {
                    Console.Write($"{matrix3[i, j]}");
                }
                Console.WriteLine();
            }



        }
    }
}
