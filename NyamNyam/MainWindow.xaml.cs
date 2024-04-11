using Microsoft.Win32;
using NyamNyam.Pages;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace NyamNyam
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            MyFrame.Navigate(new OknoDishes());
        }

        private void Orders_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MyFrame.Navigate(new OknoOrders());
        }

        private void Ingredients_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MyFrame.Navigate(new OknoIngredients());
        }

        private void Dishes_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MyFrame.Navigate(new OknoDishes());
        }
    }
}
