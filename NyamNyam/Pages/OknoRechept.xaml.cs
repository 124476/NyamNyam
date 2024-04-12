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
    /// Логика взаимодействия для OknoRechept.xaml
    /// </summary>
    public partial class OknoRechept : Page
    {
        Bludo contextBludo;
        public OknoRechept(Bludo bludo)
        {
            InitializeComponent();
            contextBludo = bludo;
            Refrash();
        }

        private void LoadIngredients()
        {
            var steps = contextBludo.Rechept.SelectMany(x => x.OneRechept);
            DataIngredients.ItemsSource = steps;
        }

        private void DownSer_Click(object sender, RoutedEventArgs e)
        {
            if (contextBludo.BaseServings != 1)
            {
                contextBludo.BaseServings -= 1;
                App.DB.SaveChanges();
            }
            Refrash();
        }

        private void UpSer_Click(object sender, RoutedEventArgs e)
        {
            contextBludo.BaseServings += 1;
            App.DB.SaveChanges();
            Refrash();
        }

        private void Refrash()
        {
            NameRec.Text = '"' + contextBludo.Name + '"';
            CategoryRec.Text = contextBludo.Category.Name;
            TimeSpan timeSpan = TimeSpan.Zero;
            foreach (var rec in contextBludo.Rechept.ToList())
            {
                timeSpan = timeSpan.Add(rec.Time.Value);
            }
            TimeRec.Text = timeSpan.ToString();
            TotalRec.Text = (contextBludo.Sum * contextBludo.BaseServings).ToString();
            TextRec.Text = contextBludo.Opisanie;
            ListRechepts.ItemsSource = App.DB.Rechept.Where(x => x.Bludo.Id == contextBludo.Id).OrderBy(x => x.Num).ToList();
            LoadIngredients();
            ServingRec.Text = contextBludo.BaseServings.ToString();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Redact_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new NewBludo(contextBludo));
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Refrash();
        }
    }
}
