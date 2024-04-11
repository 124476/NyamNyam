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
    /// Логика взаимодействия для AllIngredients.xaml
    /// </summary>
    public partial class AllIngredients : Page
    {
        Rechept contextRechept;
        public AllIngredients(Rechept rechept)
        {
            InitializeComponent();
            contextRechept = rechept;
            ComboIngredients.ItemsSource = App.DB.Ingredient.ToList();
            ComboMainInits.ItemsSource = App.DB.MainInit.ToList();
            Refrash();
        }

        private void Refrash()
        {
            ListOneRechepts.ItemsSource = App.DB.OneRechept.Where(x => x.RecheptId == contextRechept.Id).ToList();
            KolOneRec.Text = null;
            ComboIngredients.SelectedIndex = -1;
            ComboMainInits.SelectedIndex = -1;
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ComboIngredients.SelectedIndex != -1 & KolOneRec.Text != null && ComboMainInits.SelectedIndex != -1)
            {
                try
                {
                    OneRechept oneRechept = new OneRechept();
                    oneRechept.Rechept = contextRechept;
                    oneRechept.Ingredient = ComboIngredients.SelectedItem as Ingredient;
                    oneRechept.MainInit = ComboMainInits.SelectedItem as MainInit;
                    oneRechept.Kol = Double.Parse(KolOneRec.Text);
                    App.DB.OneRechept.Add(oneRechept);
                    App.DB.SaveChanges();
                    Refrash();
                }
                catch
                {
                    MessageBox.Show("Не коректны данные!");
                }
            }
            else
            {
                MessageBox.Show("Заполните все поля!");
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Del_MouseUp(object sender, MouseButtonEventArgs e)
        {
            var oneRechept = (sender as TextBlock).DataContext as OneRechept;
            if (oneRechept != null)
            {
                App.DB.OneRechept.Remove(oneRechept);
                App.DB.SaveChanges();
                Refrash();
            }

        }
    }
}
