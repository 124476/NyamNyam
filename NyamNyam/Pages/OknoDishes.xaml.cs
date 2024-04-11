using NyamNyam.Models;
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
using System.Xml.Linq;

namespace NyamNyam.Pages
{
    /// <summary>
    /// Логика взаимодействия для OknoDishes.xaml
    /// </summary>
    public partial class OknoDishes : Page
    {
        public OknoDishes()
        {
            InitializeComponent();
            ComboCategories.ItemsSource = App.DB.Category.ToList().Append(new Category() { Name = "All" });
            ComboCategories.SelectedIndex = App.DB.Category.Count();
            Refrash();
        }

        private void Refrash()
        {
            var bludes = App.DB.Bludo.Where(x => x.Name.Contains(PoiskText.Text)).ToList();

            Category category = ComboCategories.SelectedItem as Category;
            if (category.Name != "All")
            {
                bludes = bludes.Where(x => x.CategoryId == category.Id).ToList();
            }

            try
            {
                bludes = bludes.Where(x => x.Sum >= double.Parse(PoiskStart.Text) && x.Sum <= double.Parse(PoiskEnd.Text)).ToList();
            }
            catch
            {
                try
                {
                    bludes = bludes.Where(x => x.Sum >= double.Parse(PoiskStart.Text)).ToList();
                }
                catch
                {
                    try
                    {
                        bludes = bludes.Where(x => x.Sum <= double.Parse(PoiskEnd.Text)).ToList();
                    }
                    catch
                    {

                    }
                }
            }

            if (CheckOnly.IsChecked == true)
            {
                foreach(var bludo in bludes.ToList())
                {
                    if (bludo.DishColor == "Gray32Float")
                    {
                        bludes.Remove(bludo);
                    }
                }
            }
            ListLineOne.ItemsSource = bludes;
        }

        private void ComboCategories_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refrash();
        }

        private void PoiskText_TextChanged(object sender, TextChangedEventArgs e)
        {
            Refrash();
        }

        private void CheckOnly_Checked(object sender, RoutedEventArgs e)
        {
            Refrash();
        }

        private void ListLineOne_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var blude = ListLineOne.SelectedItem as Bludo;
            if (blude != null)
            {
                NavigationService.Navigate(new OknoRechept(blude));
            }
        }

        private void New_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new NewBludo(new Bludo()));
        }
    }
}
