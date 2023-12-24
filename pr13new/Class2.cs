using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr13new
{
    public class Massiv
    {
        /// <summary>
        /// Заполнение массива рандомом
        /// </summary>
        /// <param name="mas">массив</param>
        /// <param name="column">столбцы</param>
        /// <param name="randMax">максимальный рандом</param>
        public static void InitMas(out int[] mas, int column, int randMax)
        {
            Random random = new Random();
            mas = new int[column];
            for (int i = 0; i < mas.Length; i++)
            {
                mas[i] = random.Next(randMax);
            }
        }
        /// <summary>
        /// Суммирование элементов массива
        /// </summary>
        /// <param name="mas">массив</param>
        /// <returns>сумму</returns>
        public static int SumMas(int[] mas)
        {
            int sum = 0;
            for (int i = 0; i < mas.Length; i++)
            {
                sum += mas[i];
            }
            return sum;
        }
        /// <summary>
        /// Сохранение массива
        /// </summary>
        /// <param name="mas">массив</param>
        public static void SaveMas(int[] mas)
        {
            StreamWriter sw = new StreamWriter("Ìàññèâ.txt");
            sw.WriteLine(mas.Length);
            for (int i = 0; i < mas.Length; i++)
            {
                sw.WriteLine(mas[i]);
            }
            sw.Close();
        }
        /// <summary>
        /// Добавление массива
        /// </summary>
        /// <param name="mas">массив</param>
        public static void OpenMas(out int[] mas)
        {
            StreamReader sr = new StreamReader("Ìàññèâ.txt");
            int len = Convert.ToInt32(sr.ReadLine());
            mas = new int[len];
            for (int i = 0; i < len; i++)
            {
                mas[i] = Convert.ToInt32(sr.ReadLine());
            }
            sr.Close();
        }
        /// <summary>
        /// Сохранение матрицы
        /// </summary>
        /// <param name="matr">матрица</param>
        public static void SaveMatr(int[,] matr)
        {
            StreamWriter sw = new StreamWriter("matrix.txt");
            int rows = matr.GetLength(0);
            int columns = matr.GetLength(1);
            sw.WriteLine($"{rows}");
            sw.WriteLine($"{columns}");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    sw.Write(matr[i, j] + " ");
                }
                sw.WriteLine();
            }
            sw.Close();
        }
        /// <summary>
        /// Добавление матрицы
        /// </summary>
        /// <param name="matr">матрица</param>
        public static void OpenMatr(out int[,] matr)
        {
            StreamReader sr = new StreamReader("matrix.txt");
            int rows = Convert.ToInt32(sr.ReadLine());
            int columns = Convert.ToInt32(sr.ReadLine());
            matr = new int[rows, columns];
            for (int i = 0; i < rows; i++)
            {
                string[] line = sr.ReadLine().Split(' ');
                for (int j = 0; j < columns; j++)
                {
                    matr[i, j] = int.Parse(line[j]);
                }
            }
            sr.Close();
        }
    }
}
