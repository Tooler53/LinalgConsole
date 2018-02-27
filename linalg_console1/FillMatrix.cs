using System;

namespace linalg
{
    class FillMatrix
    {
        public double[] fillMatrix(int n, int sign)
        {
            LinalgSolve linalgSolve = new LinalgSolve();
            Random r = new Random();

            double[,] a = new double[n, n];
            double[] b = new double[n];
            double[] x = new double[n];

            //for (int i = 0; i < n; i++)
            //    for (int j = 0; j < n; j++)
            //        a[i, j] = r.NextDouble() + r.Next(0, 10);

            //for (int i = 0; i < n; i++)
            //    b[i] = r.NextDouble() + r.Next(0, 10);

            while (true)
            {
                if (ChechErr(a, b, n))
                {
                    Console.WriteLine(Environment.NewLine + "Вводить нужно только целые числа числа!");
                    Console.WriteLine("Повторите ввод с самого начала" + Environment.NewLine);
                }
                else
                {
                    break;
                }
            }
            Console.WriteLine();

            string wich = "";

            for (int i = 0; i < sign; i++) //Задание точности
            {
                wich += "0";
            }

            Console.WriteLine(" A["); //Вывод матрицы А
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                    Console.Write(" " + String.Format("{0:0." + wich + "}", a[i, j]) + "\t");
                Console.WriteLine();
            }
            Console.Write(" ]");
            Console.WriteLine(Environment.NewLine);

            Console.WriteLine(" b["); //Вывод вектора b
            for (int i = 0; i < n; i++)
                Console.WriteLine(" " + String.Format("{0:0." + wich + "}", b[i]));
            Console.Write(" ]");
            Console.WriteLine(Environment.NewLine);

            return linalgSolve.LinAlgSolve(a, b, x);
        }

        public bool ChechErr(double[,] a, double[] b, int n)
        {
            try
            {
                Console.WriteLine(" Ввод осуществляется через Enter");
                Console.WriteLine(" Введите элементы матрицы");
                Console.WriteLine();
                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine(" строка {0}", i + 1);
                    for (int j = 0; j < n; j++)
                    {
                        Console.Write(" -> ");
                        a[i, j] = Int32.Parse(Console.ReadLine());
                    }
                }
                Console.WriteLine();

                Console.WriteLine(" Введите элементы вектора");
                Console.WriteLine();
                for (int i = 0; i < n; i++)
                {
                    Console.Write(" -> ");
                    b[i] = Int32.Parse(Console.ReadLine());
                }
            }
            catch (FormatException)
            {
                return true;
            }
            return false;
        }
    }
}
