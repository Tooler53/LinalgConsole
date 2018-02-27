using System;

namespace linalg
{
    class LinalgSolve
    {
        public double[] LinAlgSolve(double[,] a, double[] b, double[] x)
        {
            int rowCount = a.GetUpperBound(0) + 1;
            double s = 0;

            for (int i = 0; i < b.Length; i++)
                x[i] = 0;

            for (int k = 0; k < b.Length - 1; k++) //Приведение к ступенчатому виду
            {
                for (int i = k + 1; i < b.Length; i++)
                {
                    for (int j = k + 1; j < b.Length; j++)
                        a[i, j] = a[i, j] - a[k, j] * (a[i, k] / a[k, k]);
                    b[i] = b[i] - b[k] * a[i, k] / a[k, k];
                }
            }

            bool flag = false;

            if (determinant(a) != 0)//Проверка на то что детермимнант равен 0
            {
                for (int k = b.Length - 1; k >= 0; k--)
                {
                    s = 0;

                    for (int j = k + 1; j < b.Length; j++)
                        s = s + a[k, j] * x[j];
                    x[k] = (b[k] - s) / a[k, k];
                }

                for (int i = 0; i < x.Length; i++)
                {
                    if (x[i] / 2 > 0)
                    {
                        flag = true;
                    }
                    else
                    {
                        flag = true;
                        break;
                    }
                }

                if (!flag)
                {
                    return null;
                }
                else return x;
            }
            else return null;
        }

        public double determinant(double[,] a)
        {
            //Вычисление детерминанта
            int n = a.GetLength(1);
            double result = 1;

            for (int i = 0; i < n; i++)
            {
                result *= a[i, i];
            };

            return result;
        }
    }
}
