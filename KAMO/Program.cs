using System;
using System.IO;

namespace KAMO
{
    internal static class Program
    {
        private static void Main()
        {
            var wm = new WholeMatrix(23)
            {
                I = 422,
                J = 415
            };
            Console.WriteLine(wm.Det3());

            using (var file = new StreamWriter("Matrix.txt"))
            {
                file.Write(wm);
            }
        }
    }
}
