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
        int[,] matr;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void exitClick(object sender, RoutedEventArgs e)//кнопка выхода
        {
            this.Close();
        }

        private void infoClick(object sender, RoutedEventArgs e)//кнопка вывода информации
        {
            MessageBox.Show("Выполнено Кульковой Ангелиной.\r\n Дана вещественная матрица А(M, N). Строку, содержащий максимальный элемент, поменять местами со строкой, содержащей минимальный элемент.");
        }

        private void ochClick(object sender, RoutedEventArgs e)//кнопка очистки матрицы результата
        {
            dgRes.Items.Clear();
        }

        private void CreateCLick(object sender, RoutedEventArgs e)//Кнопка создания матрицы
        {
            int m, n;
            if (Int32.TryParse(tbM.Text, out m) == true & Int32.TryParse(tbN.Text, out n) == true)//проверяем текстбоксы на верность
            {
                Random rnd = new Random();
                matr = new int[m, n];        
                for(int i=0; i<m; i++)//заполняем матрицу рандомными числами
                {
                    for(int j=0; j<n; j++)
                    {
                        matr[i, j] = rnd.Next(1, 10);
                    }
                }
                dgDano.ItemsSource = VisualArray.ToDataTable(matr).DefaultView;
                sizematr.Content = $"Размер матрицы: {m}, {n}";
            }
            else MessageBox.Show("Введите корректные данные");//если данных нет или они неправильные
        }

        private void Danocelleditending(object sender, DataGridCellEditEndingEventArgs e)//при изменении ячеек матрицы исходных данных очищает матрицу результат
        {
            dgRes.ItemsSource = null;
            int IndexColumn = e.Column.DisplayIndex;
            int IndexRow = e.Column.DisplayIndex;
            matr[IndexColumn, IndexRow] = Convert.ToInt32(((TextBox)e.EditingElement).Text);
        }

        private void Createtch(object sender, TextChangedEventArgs e)//При изменении текстбоксов создания матрицы очищает матрицы
        {
            dgRes.ItemsSource = null;
            dgDano.ItemsSource = null;
        }

        private void rasClick(object sender, RoutedEventArgs e)
        {
            int m, n, a = 0, b = 0, min = 10000, max = 0;        
            if (Int32.TryParse(tbM.Text, out m) == true & Int32.TryParse(tbN.Text, out n) == true)//проверяем текстбоксы на верность
            {
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
                        int c = matr[a,j];
                        matr[a, j] = matr[b, j];
                        matr[b, j] = c;
                    }
                dgRes.ItemsSource = VisualArray.ToDataTable(matr).DefaultView;
            }
        }

        private void SaveClick(object sender, RoutedEventArgs e)
        {
            Massiv.SaveMatr(matr);
            Openbtn.IsEnabled = true;
        }

        private void DownloadClick(object sender, RoutedEventArgs e)
        {
            Massiv.OpenMatr(out matr);
            dgDano.ItemsSource = VisualArray.ToDataTable(matr).DefaultView;
        }
    }
}
