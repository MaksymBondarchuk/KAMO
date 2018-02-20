using System;
using System.Text;

namespace KAMO
{
    public class WholeMatrix
    {
        public int I { get; private set; }
        public int J { get; private set; }

        private double[,] Matrix { get; }
        private Circuit Circuit { get; set; }

        public WholeMatrix(int size, int i, int j)
        {
            I = i;
            J = j;
            //Matrix = new double[size * 30, size * 30];
            Matrix = new double[10, 10];
            FillMatrix();

            Circuit = new Circuit(i, j, size);
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

        public double Det3()
        {
            var a = Matrix[I - 2, J - 2];
            var b = Matrix[I - 2, J - 1];
            var c = Matrix[I - 2, J];
            var d = Matrix[I - 1, J - 2];
            var e = Matrix[I - 1, J - 1];
            var f = Matrix[I - 1, J];
            var g = Matrix[I, J - 2];
            var h = Matrix[I, J - 1];
            var i = Matrix[I, J];

            return a * e * i + b * f * g + c * d * h - c * e * g - b * d * i - a * f * h;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            for (var i = 0; i < Matrix.GetLength(0); i++)
            {
                var sbLine = new StringBuilder();
                for (var j = 0; j < Matrix.GetLength(1); j++)
                {
                    if (Circuit.ContainsPoint(i, j))
                    {
                        sbLine.Append($"*{Matrix[i, j],-15:N2}");
                    }
                    else
                    {
                        sbLine.Append($" {Matrix[i, j],-15:N2}");
                    }
                }
                sb.AppendLine(sbLine.ToString());
            }
            return sb.ToString();
        }

        private static double Function(int i, int j)
        {
            return (.01 * j * j - .53 * i + 5.81) * Math.Sin((j + .8 * i * i) / 29);
        }

        private void FillMatrix()
        {
            for (var i = 0; i < Matrix.GetLength(0); i++)
            {
                for (var j = 0; j < Matrix.GetLength(1); j++)
                    Matrix[i, j] = Function(i, j);
            }
        }
    }
}
