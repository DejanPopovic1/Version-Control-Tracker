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

    public partial class MainWindow : Window
    {
        String trackingDirectory;

        public MainWindow()
        {
            InitializeComponent();
            var myBinding = new Binding("ColorName");
        }

        public List<String> createListOfProjects()
        {
            String listOfProjects = ProjectNameTextBox.Text;
            List<string> idList = listOfProjects.Split(new[] { "\r\n" }, StringSplitOptions.None).ToList();
            return idList;
        }

        public Dictionary<string, string> trimDirectoryDictionary(Dictionary<String, String> d, List<string> projects)
        {
            foreach (KeyValuePair<string, string> entry in d)
            {
                if (projects.Contains(entry.Key)) {
                    d.Remove(entry.Key);
                }
            }
            return d;
        }

        public int versionToMagnitude(String ver) {
            List<string> verList = ver.Split(new[] { "." }, StringSplitOptions.None).ToList();
            int first = Int32.Parse(verList.ElementAt(0)) * (int)Math.Pow(10, 3);
            int second = Int32.Parse(verList.ElementAt(1)) * (int)Math.Pow(10, 2);
            int third = Int32.Parse(verList.ElementAt(2)) * (int)Math.Pow(10, 1);
            int fourth = Int32.Parse(verList.ElementAt(3)) * (int)Math.Pow(10, 0);
            return first + second + third + fourth;
        }

        public bool isValidUpdate(String oldVer, String newVer)
        {
            if (versionToMagnitude(newVer) <= versionToMagnitude(oldVer)) {
                return false;
            }
            return true;
        }

        public Dictionary<string, string> getDirectoryDictionary(String directory)
        {
            Dictionary<string, string> ans = new Dictionary<string, string>();
            foreach (var file in Directory.EnumerateFiles(directory, "*.dll"))
            {
                Assembly assembly1 = Assembly.LoadFrom(file);
                String ver1 = assembly1.GetName().Version.ToString();
                ans.Add(Path.GetFileName(file), ver1);
            }
            return ans;
        }

        public Dictionary<string, string> getListOfPreviousLibraryVersions()
        {
            Dictionary<string, string> ans = new Dictionary<string, string>();
            var File = new System.IO.StreamReader(@trackingDirectory + @"\.dllTracker");
            String line;
            while ((line = File.ReadLine()) != null) {
                List<string> verList = line.Split(new[] { "," }, StringSplitOptions.None).ToList();
                ans.Add(verList.ElementAt(0), verList.Last());
            }
            File.Close();
            return ans;
        }

        public int CountNumberOfFilesInDirectory(string directory)
        {
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(directory);
            int count = dir.GetFiles().Length;
            return count;
        }

        private void VersionTheBuild_Click(object sender, RoutedEventArgs e)
        {
            //Load file to memory
            trackingDirectory = DirectoryTextBox.Text;
            if (!Directory.Exists(trackingDirectory)) {
                MessageBox.Show("Invalid Directory");
                return;
            }
            var File = new System.IO.StreamReader(@trackingDirectory + @"\.dllTracker");
            String fileString = File.ReadToEnd();
            File.Close();
            String[] verList = fileString.Split(new[] { "\r\n" }, StringSplitOptions.None).ToArray();

            System.IO.File.WriteAllText(@trackingDirectory + @"\.dllTracker", string.Empty);
            int i = 0;
            foreach (var line in verList){
                verList[i] = verList[i] + ",ADDED:" + getDirectoryDictionary(trackingDirectory)[verList[i]];
                i++;
            }


            TextWriter tw = new StreamWriter(@trackingDirectory + @"\.dllTracker");
            foreach (String s in verList) {
                tw.WriteLine(s);
            }

            tw.Close();




            //MessageBox.Show(verList[4]);




            //while ((line = File.ReadToEnd()) != null)
            //{
            //    //List<string> verList = line.Split(new[] { "," }, StringSplitOptions.None).ToList();
            //    //ans.Add(verList.ElementAt(0), verList.Last());
            //    line += "TESTING";
            //}

            return;
        }

        public List<String> identifyOutliers(Dictionary<string, string> h, Dictionary<string, string> c) 
        {
            List<String> result = new List<String>();
            foreach (KeyValuePair<string, string> j in h)
            {
                foreach (KeyValuePair<string, string> k in c)
                {
                    if (j.Key == k.Key) {
                        if (!isValidUpdate(j.Value, k.Value)){
                            result.Add(j.Key);
                        }
                    }
                }
            }
            return result;
        }

        private void CheckForOutdatedLibraries_Click(object sender, RoutedEventArgs e)
        {
            trackingDirectory = DirectoryTextBox.Text;
            if (!Directory.Exists(trackingDirectory))
            {
                MessageBox.Show("Invalid Directory");
                return;
            }
            Dictionary<string, string> histDirDic = getListOfPreviousLibraryVersions();
            Dictionary<string, string> dirDic =  getDirectoryDictionary(@trackingDirectory);
            List<String> l = createListOfProjects();
            Dictionary<string, string> trimmedDirDic = trimDirectoryDictionary(dirDic, l);
            List<String> result = identifyOutliers(histDirDic, trimmedDirDic);
            OutputTextBox.Text = outputList(result);
        }

        public String outputList(List<String> l) {
            return String.Join("\n", l.ToArray());
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
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