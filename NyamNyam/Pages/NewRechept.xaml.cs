using NyamNyam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
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
    /// Логика взаимодействия для NewRechept.xaml
    /// </summary>
    public partial class NewRechept : Page
    {
        Bludo contextBludo;
        public NewRechept(Bludo bludo)
        {
            InitializeComponent();
            contextBludo = bludo;
            Refrash();
        }

        private void Refrash()
        {
            ListRechepts.ItemsSource = App.DB.Rechept.Where(x => x.Bludo.Id == contextBludo.Id).ToList();
            TextRec.Text = null;
            TimeRec.Text = null;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ListRechepts.ItemsSource = App.DB.Rechept.Where(x => x.Bludo.Id == contextBludo.Id).ToList();
        }

        private void Ingredien_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Rechept rechept = (sender as TextBlock).DataContext as Rechept;
            if (rechept != null)
            {
                NavigationService.Navigate(new AllIngredients(rechept));
            }
        }

        private void Del_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Rechept rechept = (sender as TextBlock).DataContext as Rechept;
            if (rechept != null)
            {
                foreach(var oneRecepat in rechept.OneRechept.ToList())
                {
                    App.DB.OneRechept.Remove(oneRecepat);
                }
                App.DB.Rechept.Remove(rechept);
                App.DB.SaveChanges();
                Refrash();
            }
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            if (TextRec.Text != null && TimeRec.Text != null)
            {
                try
                {
                    Rechept rechept = new Rechept();
                    rechept.Num = App.DB.Rechept.Where(x => x.Bludo.Id == contextBludo.Id).Count() + 1;
                    rechept.Bludo = contextBludo;
                    rechept.Text = TextRec.Text;
                    rechept.Time = TimeSpan.Parse(TimeRec.Text);
                    App.DB.Rechept.Add(rechept);
                    App.DB.SaveChanges();
                    Refrash();
                }
                catch
                {
                    MessageBox.Show("Не коректные данные!");
                }
            }
            else
            {
                MessageBox.Show("Заполните все данные!");
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
