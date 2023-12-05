using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace pr13new
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            sizematr.Content = $"Размер матрицы: {dgDano.ActualHeight}, {dgDano.ActualWidth}";
        }

        private void exitClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void infoClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Выполнено Кульковой Ангелиной.\r\n Дана вещественная матрица А(M, N). Строку, содержащий максимальный элемент, поменять местами со строкой, содержащей минимальный элемент.");
        }

        private void ochClick(object sender, RoutedEventArgs e)
        {
            dgRes.Items.Clear();
        }

        private void CreateCLick(object sender, RoutedEventArgs e)
        {
            int m,n,a=0,b=0,min=10000,max=0;
            if (Int32.TryParse(tbM.Text, out m) == true & Int32.TryParse(tbN.Text, out n) == true)
            {
                Random rnd = new Random();
                int[,] matr = new int[m, n];        
                for(int i=0; i<m; i++)
                {
                    for(int j=0; j<n; j++)
                    {
                        matr[m, n] = rnd.Next(1, 10);
                    }
                }
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
                            max= matr[i, j];
                        }
                    }
                }
                for (int i = 0; i < m; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        int c = a;
                        matr[a, j] = matr[b, j];
                        matr[b, j] = matr[c, j];
                    }
                }
            }
            else MessageBox.Show("Введите корректные данные");
        }

        private void Danocelleditending(object sender, DataGridCellEditEndingEventArgs e)
        {
            dgRes.Items.Clear();
        }

        private void Createtch(object sender, TextChangedEventArgs e)
        {
            dgRes.Items.Clear();
            dgDano.Items.Clear();
        }
    }
}
