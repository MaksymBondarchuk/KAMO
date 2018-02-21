﻿using System;
using System.Collections.Generic;
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

            Circuit = new Circuit(i, j, size, CircuitDirection.Clockwise);
        }

        public void Print()
        {
            for (var i = 0; i < Matrix.GetLength(0); i++)
            {
                for (var j = 0; j < Matrix.GetLength(1); j++)
                    if (Circuit.ContainsPoint(i, j))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write($"*{Matrix[i, j],-8:N2}");
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    else
                    {
                        Console.Write($" {Matrix[i, j],-8:N2}");
                    }

                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public double Det3()
        {
            //return 666;
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

        public void RotateForwardN(int n)
        {
            Console.WriteLine($"Rotating forward {n}");
            n %= Circuit.Lenth;

            Circuit.MoveBackward(); // Stay at the end

            var remember = new List<Tuple<int, int, double>>();
            for (var i = Circuit.Lenth - 1; Circuit.Lenth - 1 - n < i; i--, Circuit.MoveBackward())
            {
                remember.Add(new Tuple<int, int, double>(Circuit.I, Circuit.J, Matrix[Circuit.I, Circuit.J]));
            }
            Circuit.Reset();
            Circuit.MoveBackward(); // Stay at the end

            for (var i = Circuit.Lenth - 1; n <= i; i--, Circuit.MoveBackward())
            {
                var nextN = Circuit.GetPreviousN(n);
                Matrix[Circuit.I, Circuit.J] = Matrix[nextN.Item1, nextN.Item2];
            }
            Circuit.Reset();

            for (var i = 0; i < n; i++, Circuit.MoveForward())
            {
                Matrix[Circuit.I, Circuit.J] = remember[n - 1 - i].Item3;
            }
            Circuit.Reset();
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            for (var i = 0; i < Matrix.GetLength(0); i++)
            {
                var sbLine = new StringBuilder();
                for (var j = 0; j < Matrix.GetLength(1); j++)
                {
                    sbLine.Append(Circuit.ContainsPoint(i, j) ? $"*{Matrix[i, j],-15:N2}" : $" {Matrix[i, j],-15:N2}");
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
