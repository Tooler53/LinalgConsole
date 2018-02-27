using System;
using linalg;

namespace linalg_console1
{
    class Program
    {
        static void Main(string[] args)
        {
            if (hello())
            {
                while (true)
                {
                    Console.Clear();
                    int n = 0;

                    while (true)
                    {
                        Console.WriteLine();
                        Console.WriteLine(" Введите размерность системы"); //Ввод размерности системы
                        Console.WriteLine();
                        Console.Write(" -> ");

                        if (checkN(ref n))
                        {
                            Console.Clear();
                            Console.WriteLine(" Ошибка! Вводить нужно только целые числа!"); //Проверка на то что введены не буквы
                        }
                        else
                        {
                            break;
                        }
                    }

                    while (true)
                    {
                        if (n > 1)
                        {
                            double[] s = new double[n];
                            while (true)
                            {
                                if (checkNMore(ref s))
                                {
                                    Console.WriteLine(" Точность должна быть равна или больше 0!"); //Проверка на то что точность равна или больше 0 
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine(" Ошибка! Размерность сиситемы всегда должна быть больше 1!"); //Проверка на то что размерность больше 0
                        }
                        break;
                    }

                    while (true)
                    {
                        if (end()) //Пользователь дал ответ
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine(" До свидания!");
                            Console.ReadKey();
                            Environment.Exit(0);
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine(" " + "До свидания!");
                Console.ReadKey();
                Environment.Exit(0);
            }
            Console.ReadKey();
        }

        public static bool hello() //Вывод приветствия
        {
            Console.WriteLine("  ________________________________________ ");
            Console.WriteLine(" |                                        |");
            Console.WriteLine(" |                                        |");
            Console.WriteLine(" |                                        |");
            Console.WriteLine(" |                                        |");
            Console.WriteLine(" |                                        |");
            Console.WriteLine(" |     Приветствую тебя пользователь!     |");
            Console.WriteLine(" |                                        |");
            Console.WriteLine(" |                                        |");
            Console.WriteLine(" |                                        |");
            Console.WriteLine(" |     Хочешь решить систему линейных     |");
            Console.WriteLine(" |       уравнений методом Гаусса?        |");
            Console.WriteLine(" |                                        |");
            Console.WriteLine(" |                                        |");
            Console.WriteLine(" |                                        |");
            Console.WriteLine(" |         Да(да)?         Нет(нет)?      |");
            Console.WriteLine(" |                                        |");
            Console.WriteLine(" |                                        |");
            Console.WriteLine(" |                                        |");
            Console.WriteLine(" |________________________________________|");
            Console.WriteLine();

            bool flag = false;
            while (true)
            {
                if (checkAnswer(ref flag))
                {
                    Console.WriteLine();
                    Console.WriteLine(" Вводить нужно только Да(да) или Нет(нет)!");
                    Console.WriteLine(" Повторите ввод");
                }
                else { break; }
            }
            return flag;
        }

        public static bool checkAnswer(ref bool flag)
        {
            Console.Write("  -> ");
            string str = Console.ReadLine();

            str = str.ToLower();

            if (!сheckDigitOrSymbol(str)) //Введены буквы
            {
                if (str == "да") flag = true;
                else if (str == "нет") flag = false;
                else { return true; }
            }
            else //Введены цифры или знаки
            {
                return true;
            }
            return false;
        }

        public static bool end() //Спросить пользователя хочет ли он решить другую систему уравнений
        {
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("  ________________________________________ ");
            Console.WriteLine(" |                                        |");
            Console.WriteLine(" |                                        |");
            Console.WriteLine(" |                                        |");
            Console.WriteLine(" |                                        |");
            Console.WriteLine(" |                                        |");
            Console.WriteLine(" |     Хотите решить еще одну систему?    |");
            Console.WriteLine(" |                                        |");
            Console.WriteLine(" |                                        |");
            Console.WriteLine(" |                                        |");
            Console.WriteLine(" |         Да(да)?         Нет(нет)?      |");
            Console.WriteLine(" |                                        |");
            Console.WriteLine(" |                                        |");
            Console.WriteLine(" |                                        |");
            Console.WriteLine(" |________________________________________|");
            Console.WriteLine();

            bool flag = false;
            while (true)
            {
                if (checkAnswer(ref flag))
                {
                    Console.WriteLine();
                    Console.WriteLine(" Вводить нужно только Да(да) или Нет(нет)!");
                    Console.WriteLine(" Повторите ввод");
                }
                else { break; }
            }
            return flag;
        }

        public static bool сheckDigitOrSymbol(string s) //Проверка на то что введены буквы
        {
            bool f = false;

            for (int i = 0; i < s.Length; i++)
            {
                if (Char.IsDigit(s[i]) || Char.IsSymbol(s[i]))
                {
                    f = true;
                    break;
                }
                else f = false;
            }
            return f;
        }

        public static bool checkN(ref int n)
        {
            try
            {
                n = int.Parse(Console.ReadLine());
                Console.WriteLine();
            }
            catch (FormatException)
            {
                return true;
            }
            return false;
        }

        public static bool checkNMore(ref double[] s)
        {
            FillMatrix fillMatrix = new FillMatrix();
            Console.WriteLine(" Введите точность вычислений.(Количесвто знаков после запятой)"); //Ввод точности вычислений
            Console.WriteLine();
            Console.Write(" -> ");
            int sign = 0;
            try
            {
                sign = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Вводить нужно только числа!");
            }

            Console.WriteLine();

            if (sign > 0)
            {
                string wich = "";//Задание точности
                for (int i = 0; i < sign; i++)
                {
                    wich += "0";
                }
                Console.WriteLine();

                s = fillMatrix.fillMatrix(s.Length, sign); //Получение ответа
                Console.WriteLine(" ___________________ответ_________________");
                Console.WriteLine();
                if (s != null)
                {
                    Console.WriteLine("c["); //Вывод ответа
                    for (int i = 0; i < s.Length; i++)
                        Console.WriteLine(String.Format("{0:0." + wich + "}", s[i]));
                    Console.Write("]");
                }
                else Console.WriteLine(" Детерминант равен 0! Система не имеет решений.");
                return false;
            }
            else return true;
        }
    }
}
