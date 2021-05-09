using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using Path = System.IO.Path;

namespace Question2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (HelloButton.IsChecked == true)
            {
                MessageBox.Show("Hello.");
            }
            else if (GoodbyeButton.IsChecked == true)
            {
                MessageBox.Show("Goodbye.");
            }
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            //string text = System.IO.File.ReadAllText(@".\TEST.txt");
            //System.Console.WriteLine("Contents of WriteText.txt = {0}", text);
            //Environment.NewLine("Hello, world!");
            //Debug.WriteLine("Hellow World!");
            //System.Diagnostics.Debug.WriteLine("Hello World!");

            var path = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "myDLLs\\Test.txt");
            //var path = Path.Combine(Directory.GetCurrentDirectory(), "\\TEST.txt");
            string text = System.IO.File.ReadAllText(path);
            MessageBox.Show(text);

        }

    }
}


//Assembly assembly = Assembly.LoadFrom("TestAssembly.dll");
//Version ver = assembly.GetName().Version;