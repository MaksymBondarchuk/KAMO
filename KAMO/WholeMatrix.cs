using System;
using System.Collections.Generic;
using System.Text;

namespace KAMO
{
    public class WholeMatrix
    {
        private double[,] Matrix { get; set; }

        public WholeMatrix(int size)
        {
            //var actualSize = size * 30;
            Matrix = new double[size * 30, size * 30];
            for (var i = 0; i < Matrix.GetLength(0); i++)
            {
                for (var j = 0; j < Matrix.GetLength(1); j++)
                    Matrix[i, j] = Function(i, j);
            }
        }

        public void Print()
        {
            for (var i = 0; i < Matrix.GetLength(0); i++)
            {
                for (var j = 0; j < Matrix.GetLength(1); j++)
                    Console.Write($"{Matrix[i, j],8:N2}");
                Console.WriteLine();
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            for (var i = 0; i < Matrix.GetLength(0); i++)
            {
                var sbLine = new StringBuilder();
                for (var j = 0; j < Matrix.GetLength(1); j++)
                    sbLine.Append($"{Matrix[i, j],8:N2}");
                sb.AppendLine(sbLine.ToString());
            }
            return sb.ToString();
        }

        private static double Function(int i, int j)
        {
            return (.01 * j * j - .53 * i + 5.81) * Math.Sin((j + .8 * i * i) / 29);
        }
    }
}
