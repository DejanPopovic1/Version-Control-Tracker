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
        //SplashScreen s = new SplashScreen("C:/C_C++ Code PORTFOLIO/Question2/Question2/imageBackground.jpg");
        //s.Show(TimeSpan.FromSeconds(2));

        String specifiedDirectory;

        public MainWindow()
        {
            InitializeComponent();
            var myBinding = new Binding("ColorName");
            getListOfPreviousLibraryVersions();
            getDirectoryDictionary("Inpt test");
            Debug.WriteLine("TESTING");
            Console.WriteLine("Testiong 1 2 3");
            System.Console.WriteLine("Third Time Lucky???");
            //TextBlock1.SetBinding(TextBlock.TextProperty, myBinding);
        }

        public List<String> createListOfProjects()
        {
            //
            //String directory = TextBox1.Text;
            return new List<String>();
        }

        public Dictionary<string, string> trimDirectoryDictionary(Dictionary<String, String> untrimmedDictionary, List<string> projects)
        {
            //
            return new Dictionary<string, string>();
        }

        public Dictionary<string, string> getDirectoryDictionary(String directory)
        {
            directory = @"C:\C_C++ Code PORTFOLIO\Question2\Question2\bin\Release\netcoreapp3.1\myDLLs";
            Dictionary<string, string> ans = new Dictionary<string, string>();
            foreach (var file in Directory.EnumerateFiles(directory, "*.dll"))
            {
                Assembly assembly1 = Assembly.LoadFrom(file);
                String ver1 = assembly1.GetName().Version.ToString();
                ans.Add(Path.GetFileName(file), ver1);
            }
            return ans;
        }

        //Currently Hardcoded
        public Dictionary<string, string> getListOfPreviousLibraryVersions()
        {
            Dictionary<string, string> ans = new Dictionary<string, string>();
            ans.Add("My.First.Project","2.0.0.0");
            ans.Add("My.Second.Project", "5.0.0.0");
            ans.Add("My.Third.Project", "5.0.0.0");
            ans.Add("My.Fourth.Project", "1.0.0.0");
            ans.Add("My.Fifth.Project", "0.0.0.0");
            return ans;
        }


        public int CountNumberOfFilesInDirectory(string directory)
        {
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(directory);
            int count = dir.GetFiles().Length;
            return count;
        }

        public void isValidDirectory(String input) { 

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {


            //Debug.WriteLine("TESTING");
            //Console.WriteLine("Testiong 1 2 3");
            //System.Console.WriteLine("Third Time Lucky???");
            

            String directory = TextBox1.Text;
            if (!Directory.Exists(directory)) {
                MessageBox.Show("Invalid Directory");
                return;
            }
            int numberOfFiles = CountNumberOfFilesInDirectory(directory);
          
            String test = CountNumberOfFilesInDirectory(directory).ToString();

            //There are 10 files in the DLL folder.
            //We get the versions of all of the files.
            //Should use file iterator here instead.

            var pathToDLLFile1 = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "myDLLs\\My.First.Project.dll");
            var pathToDLLFile2 = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "myDLLs\\My.Second.Project.dll");
            var pathToDLLFile3 = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "myDLLs\\My.Third.Project.dll");
            var pathToDLLFile4 = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "myDLLs\\My.Fourth.Project.dll");
            var pathToDLLFile5 = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "myDLLs\\My.Fifth.Project.dll");
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

            String result = ver1 + "\n" + ver2 + "\n" + ver3 + "\n" + ver4 + "\n" + ver5 + "\n" + ver6 + "\n" + ver7 + "\n" + ver8 + "\n" + ver9 + "\n" + ver10;
            TextBox2.Text = result;


            MessageBox.Show(ver1);




            MessageBox.Show(test);

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
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