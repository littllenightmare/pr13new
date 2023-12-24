using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace pr13new
{
    internal class ProgramClass
    {
        /// <summary>
        /// Функция для замены строки с наименьшим числом в ячейке и строки с максимальным числом
        /// </summary>
        /// <param name="matr">матрица</param>
        /// <returns>изменённую матрицу</returns>
        public static int[,] ChangeMatrix(int[,] matr)
        {
            int m = matr.GetLength(0), n = matr.GetLength(1), min=10000, max=0, a=0, b=0;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (matr[i, j] < min)
                    {
                        a = i;
                        min = matr[i, j];
                    }
                    if (matr[i, j] > max)
                    {
                        b = i;
                        max = matr[i, j];
                    }
                }
            }
            for (int j = 0; j < n; j++)
            {
                int c = matr[a, j];
                matr[a, j] = matr[b, j];
                matr[b, j] = c;
            }
            return matr;
        }
    }
}
