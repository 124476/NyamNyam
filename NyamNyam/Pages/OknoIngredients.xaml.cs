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
    /// Логика взаимодействия для OknoIngredients.xaml
    /// </summary>
    public partial class OknoIngredients : Page
    {
        public OknoIngredients()
        {
            InitializeComponent();
            Refrash();
        }

        private void Refrash()
        {
            double TotalSm = 0;
            foreach (var ing in App.DB.Ingredient)
            {
                TotalSm += (Double)ing.Sum * (Double)ing.Kol;
            }

            TotalSum.Text = TotalSm.ToString();
            ListIngredints.ItemsSource = App.DB.Ingredient.ToList();
        }

        private void UpKol_Click(object sender, RoutedEventArgs e)
        {
            Ingredient ingredient = (sender as Button).DataContext as Ingredient;
            if (ingredient != null)
            {
                ingredient.Kol += 1;
                App.DB.SaveChanges();
                Refrash();
            }
        }

        private void DownKol_Click(object sender, RoutedEventArgs e)
        {
            Ingredient ingredient = (sender as Button).DataContext as Ingredient;
            if (ingredient != null && ingredient.Kol != 1)
            {
                ingredient.Kol -= 1;
                App.DB.SaveChanges();
                Refrash();
            }
        }

        private void Del_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Ingredient ingredient = (sender as TextBlock).DataContext as Ingredient;
            if (ingredient != null && ingredient.Kol != 1)
            {
                foreach(var item in App.DB.OneRechept)
                {
                    if (item.Ingredient.Id == ingredient.Id)
                    {
                        MessageBox.Show("Данный ингредиент используется!");
                        return;
                    }
                }
                App.DB.Ingredient.Remove(ingredient);
                App.DB.SaveChanges();
                Refrash();
            }
        }

        private void New_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new NewIngredient());
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Refrash();
        }
    }
}
