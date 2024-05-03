using Microsoft.Win32;
using Newtonsoft.Json;
using NyamNyam.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace NyamNyam
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static NyamDatabaseEntities DB = new NyamDatabaseEntities();
        //public App()
        //{
        //    InitDataJson();
        //}

        //private void InitDataJson()
        //{
        //    var saveDialog = new SaveFileDialog() { Filter = ".json | *.json;"};
        //    if (saveDialog.ShowDialog().GetValueOrDefault())
        //    {
        //        var data = App.DB.Zakaz.ToList();
        //        var jsonData = JsonConvert.SerializeObject(data);
        //        File.WriteAllText(saveDialog.FileName, jsonData);

        //    }
        //}
    }
}
