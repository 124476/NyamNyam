using Microsoft.Win32;
using NyamNyam.Models;
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

namespace NyamNyam.Pages
{
    /// <summary>
    /// Логика взаимодействия для NewBludo.xaml
    /// </summary>
    public partial class NewBludo : Page
    {
        Bludo contextBludo;
        public NewBludo(Bludo bludo)
        {
            InitializeComponent();
            contextBludo = bludo;
            DataContext = contextBludo;
            ComboCategoryes.ItemsSource = App.DB.Category.ToList();
            if (contextBludo.Id == 0)
            {
                RecheptBtn.Visibility = Visibility.Hidden;
            }
        }

        private void UplodePhoto_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog() { Filter = "*.png; | *.png;" };
            if (dialog.ShowDialog().GetValueOrDefault())
            {
                contextBludo.Photo = File.ReadAllBytes(dialog.FileName);
                DataContext = null;
                DataContext = contextBludo;
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (contextBludo.Photo != null && contextBludo.Name != null && contextBludo.Opisanie != null && contextBludo.BaseServings != null)
            {
                try
                {
                    if (contextBludo.Id == 0)
                    {
                        App.DB.Bludo.Add(contextBludo);
                    }
                    App.DB.SaveChanges();
                    NavigationService.GoBack();
                }
                catch
                {
                    MessageBox.Show("Не коректный данные!");
                }
            }
            else
            {
                MessageBox.Show("Заполните все данные!");
            }
        }

        private void RecheptBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new NewRechept(contextBludo));
        }
    }
}
