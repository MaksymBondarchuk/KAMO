using System;
using System.Collections.Generic;

namespace KAMO
{
    internal class Circuit
    {
        public int I { get; private set; }
        public int J { get; private set; }

        private readonly int _matrixI;
        private readonly int _matrixJ;
        private readonly int _matrixSize;

        private List<int> MyI = new List<int>();
        private List<int> MyJ = new List<int>();

        public Circuit(int matrixI, int matrixJ, int matrixSize)
        {
            _matrixI = matrixI;
            _matrixJ = matrixJ;
            _matrixSize = matrixSize;

            I = matrixI;
            J = matrixJ;
            FillCircuit();
        }

        public void MoveForward()
        {
            // 2
            if (0 < I && J == _matrixSize - 1)
            {
                I--;
                return;
            }

            // 3
            if (I == 0 && 0 < J)
            {
                J--;
                return;
            }

            // 4
            if (J == 0 && I < _matrixI - _matrixJ)
            {
                I++;
                return;
            }

            // 1
            if (_matrixJ <= J)
            {
                I--;
                J++;
                return;
            }

            // 5
            I++;
            J++;
        }

        public bool ContainsPoint(int i, int j)
        {
            return MyI.Contains(i) && MyJ.Contains(j);
        }

        private void FillCircuit()
        {
            var saveI = I;
            var saveJ = J;
            do
            {
                MyI.Add(saveI);
                MyJ.Add(saveJ);
                MoveForward();
                Console.WriteLine($"{I} {J}");
            } while (saveI != I || saveJ != J);
        }
    }
}
