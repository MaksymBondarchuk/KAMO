using System;
using System.Collections.Generic;
using System.Linq;

namespace KAMO
{
    public enum CircuitDirection
    {
        Clockwise,
        CounterClockwise
    }

    internal class Circuit
    {
        public int I { get; private set; }
        public int J { get; private set; }

        private readonly int _matrixI;
        private readonly int _matrixJ;
        private readonly int _matrixSize;
        private readonly CircuitDirection _direction;

        private readonly List<int> _myI = new List<int>();
        private readonly List<int> _myJ = new List<int>();

        public Circuit(int matrixI, int matrixJ, int matrixSize, CircuitDirection direction)
        {
            _matrixI = matrixI;
            _matrixJ = matrixJ;
            _matrixSize = matrixSize;
            _direction = direction;

            I = matrixI;
            J = matrixJ;
            FillCircuit();
        }

        public void MoveForward()
        {
            switch (_direction)
            {
                case CircuitDirection.CounterClockwise:
                    // 2
                    if (0 < I && J == _matrixSize - 1)
                    {
                        I--;
                        return;
                    }

                    // 3
                    if (I == 0 && Math.Max(_matrixJ - _matrixI, 0) < J)
                    {
                        J--;
                        return;
                    }

                    // 4
                    if (J == 0 && I < Math.Max(_matrixI - _matrixJ, 0))
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
                    break;
                case CircuitDirection.Clockwise:
                    

                    // 4
                    if (J == 0 && 0 < I)
                    {
                        I--;
                        return;
                    }

                    // 3
                    if (I == 0 && J < Math.Min(_matrixI + _matrixJ, _matrixSize - 1))
                    {
                        J++;
                        return;
                    }

                    // 2
                    //if (J == _matrixSize - 1 && I < _matrixSize - 1 - Math.Max(_matrixSize - _matrixI, _matrixSize - _matrixJ))
                    if (J == _matrixSize - 1 && I <= _matrixI - (_matrixSize - _matrixJ))
                    {
                        I++;
                        return;
                    }

                    // 1
                    if (I < _matrixI && _matrixJ < J)
                    {
                        I++;
                        J--;
                        return;
                    }

                    // 5
                    //if (0 < J && Math.Max(_matrixI - _matrixJ, 0) < I && J != _matrixSize - 1)
                    if (0 < J && Math.Max(_matrixI - _matrixJ, 0) < I)
                    {
                        I--;
                        J--;
                        //return;
                    }
                    break;
            }
        }

        public bool ContainsPoint(int i, int j)
        {
            return _myI.Where((t, idx) => t == i && _myJ[idx] == j).Any();
        }

        private void FillCircuit()
        {
            var saveI = I;
            var saveJ = J;
            do
            {
                _myI.Add(I);
                _myJ.Add(J);
                MoveForward();
                //Console.WriteLine($"{I} {J}");
            } while (saveI != I || saveJ != J);
        }
    }
}
