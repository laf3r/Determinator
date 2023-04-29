using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Determinator
{
    class Program
    {
        static int calculate_det(int[,] det, int n)
        {
            int sum = 0, A, m = n - 1;
            if (n == 1) { return det[0, 0]; }
            else if (n == 2)
            {
                return ((det[0, 0] * det[1, 1]) - (det[0, 1] * det[1, 0]));

            }
            else if (n > 2)
            {
                for (int k = 0; k < n; k++)
                {
                    int[,] deter = new int[m, m];
                    for (int i = 1; i < n; i++)
                    {
                        int tmp = 0;
                        for (int j = 0; j < n; j++)
                        {
                            if (j == k)
                            {
                                continue;
                            }
                            deter[i - 1, tmp] = det[i, j];
                            tmp++;
                        }
                    }
                    A = Convert.ToInt32(System.Math.Pow(-1, k + 2));
                    sum += A * det[0, k] * calculate_det(deter, m);

                }
                return sum;
            }
            return 1;
        }
        static void Main(string[] args)
        {
            Console.Write("Enter the order of the determinant(n): ");
            int n = Convert.ToInt32(Console.ReadLine());
            int[,] det = new int[n, n];
            Console.Write("Enter determinant\n");
            for (int i = 0; i < n; i++)
            {
                string[] lines = Console.ReadLine().Split();
                for (int j = 0; j < n; j++)
                {
                    det[i, j] = int.Parse(lines[j]);
                }
            }
            Console.WriteLine("determinant = " + calculate_det(det, n));
            Console.ReadKey();
        }
    }
}
