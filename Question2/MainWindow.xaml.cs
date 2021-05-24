using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
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
using Path = System.IO.Path;

namespace Question2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    class Person
    {
        //There are 10 files in the DLL folder.
        //We get the versions of all of the files.
        //Should use file iterator here instead.
        public void getVersions() {
            var pathToDLLFile1 = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "myDLLs\\Antlr3.Runtime.dll");
            var pathToDLLFile2 = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "myDLLs\\EntityFramework.dll");
            var pathToDLLFile3 = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "myDLLs\\EntityFramework.SqlServer.dll");
            var pathToDLLFile4 = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "myDLLs\\Microsoft.CodeDom.Providers.DotNetCompilerPlatform.dll");
            var pathToDLLFile5 = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "myDLLs\\Microsoft.Web.Infrastructure.dll");
            var pathToDLLFile6 = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "myDLLs\\MyApplication.dll");
            var pathToDLLFile7 = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "myDLLs\\Newtonsoft.Json.dll");
            var pathToDLLFile8 = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "myDLLs\\System.Web.Helpers.dll");
            var pathToDLLFile9 = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "myDLLs\\System.Web.Mvc.dll");
            var pathToDLLFile10 = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "myDLLs\\System.Web.Optimization.dll");

            Assembly assembly1 = Assembly.LoadFrom(pathToDLLFile1);
            Assembly assembly2 = Assembly.LoadFrom(pathToDLLFile2);
            Assembly assembly3 = Assembly.LoadFrom(pathToDLLFile3);
            Assembly assembly4 = Assembly.LoadFrom(pathToDLLFile4);
            Assembly assembly5 = Assembly.LoadFrom(pathToDLLFile5);
            Assembly assembly6 = Assembly.LoadFrom(pathToDLLFile6);
            Assembly assembly7 = Assembly.LoadFrom(pathToDLLFile7);
            Assembly assembly8 = Assembly.LoadFrom(pathToDLLFile8);
            Assembly assembly9 = Assembly.LoadFrom(pathToDLLFile9);
            Assembly assembly10 = Assembly.LoadFrom(pathToDLLFile10);

            string[] result;
        }
    }



    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var myBinding = new Binding("ColorName");
            
            //TextBlock1.SetBinding(TextBlock.TextProperty, myBinding);
        }

        public int CountNumberOfFilesInDirectory(string directory)
        {
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(directory);
            int count = dir.GetFiles().Length;
            return count;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //There are 10 files in the DLL folder.
            //We get the versions of all of the files.
            //Should use file iterator here instead.

            var pathToDLLFile1 = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "myDLLs\\Antlr3.Runtime.dll");
            var pathToDLLFile2 = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "myDLLs\\EntityFramework.dll");
            var pathToDLLFile3 = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "myDLLs\\EntityFramework.SqlServer.dll");
            var pathToDLLFile4 = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "myDLLs\\Microsoft.CodeDom.Providers.DotNetCompilerPlatform.dll");
            var pathToDLLFile5 = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "myDLLs\\Microsoft.Web.Infrastructure.dll");
            var pathToDLLFile6 = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "myDLLs\\MyApplication.dll");
            var pathToDLLFile7 = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "myDLLs\\Newtonsoft.Json.dll");
            var pathToDLLFile8 = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "myDLLs\\System.Web.Helpers.dll");
            var pathToDLLFile9 = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "myDLLs\\System.Web.Mvc.dll");
            var pathToDLLFile10 = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "myDLLs\\System.Web.Optimization.dll");

            Assembly assembly1 = Assembly.LoadFrom(pathToDLLFile1);
            Assembly assembly2 = Assembly.LoadFrom(pathToDLLFile2);
            Assembly assembly3 = Assembly.LoadFrom(pathToDLLFile3);
            Assembly assembly4 = Assembly.LoadFrom(pathToDLLFile4);
            Assembly assembly5 = Assembly.LoadFrom(pathToDLLFile5);
            Assembly assembly6 = Assembly.LoadFrom(pathToDLLFile6);
            Assembly assembly7 = Assembly.LoadFrom(pathToDLLFile7);
            Assembly assembly8 = Assembly.LoadFrom(pathToDLLFile8);
            Assembly assembly9 = Assembly.LoadFrom(pathToDLLFile9);
            Assembly assembly10 = Assembly.LoadFrom(pathToDLLFile10);

            String ver1 = assembly1.GetName().Version.ToString();
            String ver2 = assembly2.GetName().Version.ToString();
            String ver3 = assembly3.GetName().Version.ToString();
            String ver4 = assembly4.GetName().Version.ToString();
            String ver5 = assembly5.GetName().Version.ToString();
            String ver6 = assembly6.GetName().Version.ToString();
            String ver7 = assembly7.GetName().Version.ToString();
            String ver8 = assembly8.GetName().Version.ToString();
            String ver9 = assembly9.GetName().Version.ToString();
            String ver10 = assembly10.GetName().Version.ToString();

           

            MessageBox.Show(ver10);

            string test = CountNumberOfFilesInDirectory("C:\\").ToString();

            MessageBox.Show(test);

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }

    class MainWindowViewModel : INotifyPropertyChanged
    {
        private MainWindow Model;
        public MainWindowViewModel(MainWindow model)
        {
            this.Model = model;
        }

        public string Name
        {
            get { return Model.Name; }
            set
            {
                Model.Name = value;
                OnPropertyChanged("Name");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            var e = new PropertyChangedEventArgs(propertyName);
            PropertyChangedEventHandler changed = PropertyChanged;
            if (changed != null) changed(this, e);
        }
    }
}