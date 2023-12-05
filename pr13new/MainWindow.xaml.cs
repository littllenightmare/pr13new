using System;
using System.Collections.Generic;
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
        }

        private void exitClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void infoClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Выполнено Кульковой Ангелиной.\r\n Дана вещественная матрица А(M, N). Строку, содержащий максимальный элемент, поменять местами со строкой, содержащей минимальный элемент.");
        }

        private void rasClick(object sender, RoutedEventArgs e)
        {

        }

        private void ochClick(object sender, RoutedEventArgs e)
        {
            dgRes.Items.Clear();
        }
    }
}
