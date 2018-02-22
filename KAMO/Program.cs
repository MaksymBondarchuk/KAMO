using System;
using System.IO;

namespace KAMO
{
    internal static class Program
    {
        private static void Main()
        {
            var wm = new WholeMatrix(10, 8, 6);
            Console.WriteLine(wm.Det3());
            wm.Print();
            //wm.RotateForwardN(3);
            wm.Sort();
            wm.Print();

            using (var file = new StreamWriter("Matrix.txt"))
            {
                file.Write(wm);
            }
        }
    }
}
