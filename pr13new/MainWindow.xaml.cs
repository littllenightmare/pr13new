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
        int[,] matr;//описываем как глобальный объект
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

        private void ochClick(object sender, RoutedEventArgs e)//кнопка очистки матриц
        {
            dgRes.ItemsSource = null;
            dgDano.ItemsSource = null;
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
                dgDano.ItemsSource = VisualArray.ToDataTable(matr).DefaultView;//выодим на форму
                sizematr.Content = $"Размер матрицы: {m}, {n}";//выводим размер матрицы
            }
            else MessageBox.Show("Введите корректные данные");//если данных нет или они неправильные
        }

        private void Danocelleditending(object sender, DataGridCellEditEndingEventArgs e)//при изменении ячеек матрицы исходных данных очищает матрицу результат
        {
            dgRes.ItemsSource = null;
            int IndexColumn = e.Column.DisplayIndex;
            int IndexRow = e.Row.GetIndex();
            matr[IndexColumn, IndexRow] = Convert.ToInt32(((TextBox)e.EditingElement).Text);
        }

        private void Createtch(object sender, TextChangedEventArgs e)//При изменении текстбоксов создания матрицы очищает матрицы
        {
            dgRes.ItemsSource = null;
            dgDano.ItemsSource = null;
        }

        private void rasClick(object sender, RoutedEventArgs e)//кнопка расчета вызвает класс программы и выносит на форму
        {
            int m, n;      
            if (Int32.TryParse(tbM.Text, out m) == true & Int32.TryParse(tbN.Text, out n) == true)//проверяем текстбоксы на верность
            {
                ProgramClass.ChangeMatrix(matr);
                dgRes.ItemsSource = VisualArray.ToDataTable(matr).DefaultView;
            }
        }

        private void SaveClick(object sender, RoutedEventArgs e)//кнопка сохранения матрицы
        {
            Massiv.SaveMatr(matr);
            Openbtn.IsEnabled = true;
        }

        private void DownloadClick(object sender, RoutedEventArgs e)//кнопка выгрузки матрицы
        {
            Massiv.OpenMatr(out matr);
            dgDano.ItemsSource = VisualArray.ToDataTable(matr).DefaultView;
        }

        private void CurrentCellChanged(object sender, EventArgs e)//для расчета выделенной ячейки
        {
            if (dgDano.CurrentCell.Column != null)
            {
                int selectedRow = dgDano.SelectedIndex;
                int selectedColumn = dgDano.CurrentCell.Column.DisplayIndex;
                numyach.Content = $"Номер выделенной ячейки: {selectedRow}, {selectedColumn}";
            }
        }
    }
}
