using System;
using System.IO;

namespace KAMO
{
    internal static class Program
    {
        private static void Main()
        {
            var wm = new WholeMatrix(size: 27, i: 396, j: 384);
			//wm.Print();
			//wm.RotateForwardN(3);
			wm.PrintDet3();
            Console.WriteLine(wm.Det3());
			Console.WriteLine();
			wm.Sort();
			wm.PrintDet3();
			Console.WriteLine(wm.Det3());
			Console.WriteLine();
			//wm.Print();

			//using (var file = new StreamWriter("Matrix.txt"))
   //         {
   //             file.Write(wm);
   //         }
        }
    }
}
