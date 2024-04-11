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

namespace NyamNyam.Pages
{
    /// <summary>
    /// Логика взаимодействия для NewIngredient.xaml
    /// </summary>
    public partial class NewIngredient : Page
    {
        Ingredient ingredient;
        public NewIngredient()
        {
            InitializeComponent();
            ingredient = new Ingredient();
            ComboMainInit.ItemsSource = App.DB.MainInit.ToList();
            DataContext = ingredient;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (ingredient.Name != null && ingredient.Sum != null && ingredient.Kol != null && ComboMainInit.SelectedIndex != -1)
            {
                try
                {
                    ingredient.MainInit = ComboMainInit.SelectedItem as MainInit;
                    App.DB.Ingredient.Add(ingredient);
                    App.DB.SaveChanges();
                    NavigationService.GoBack();
                }
                catch
                {
                    MessageBox.Show("Не коректные данные!");
                }
            }
            else
            {
                MessageBox.Show("Заполните все поля!");
            }
        }
    }
}
