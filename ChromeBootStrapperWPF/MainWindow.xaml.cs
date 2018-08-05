using System.Windows;
using Newtonsoft.Json;
using ChromeBootStrapper;
using System.Windows.Forms;
using System.Windows.Data;
using System.IO;

namespace ChromeBootStrapperWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Model m = new Model();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = m;
        }

        private void LaunchBrowser(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.Button b = (System.Windows.Controls.Button)sender;

            if(b.Name.Equals("iconSearch"))
            {
                m.IconText = PickIcon();

            }
            else if(b.Name.Equals("locSearch"))
            {
                m.LocationText = PickLocation();
            }
        }

        private void CreateExtension(object sender, RoutedEventArgs e)
        {
            //System.Windows.MessageBox.Show($"{m.IconText}, {m.LocationText}, {m.NameText}, {m.DescriptionText}, {m.AuthorText}");
            string dirPath = $"{m.LocationText}\\{m.NameText}";
            Manifest man = new Manifest(dirPath, m.NameText, m.DescriptionText, m.AuthorText, false);

            CreateDirectory();
            man.writeManifest();
        }

        private string PickIcon()
        {
            OpenFileDialog iconFBD = new OpenFileDialog();
            string iconPath = "icon.png";

            if (iconFBD.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                iconPath = iconFBD.FileName;
                return iconPath;
            }
            return iconPath;
        }

        private string PickLocation()
        {
            FolderBrowserDialog storageDirFBD = new FolderBrowserDialog();
            string dirPath;

            if (storageDirFBD.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                dirPath = storageDirFBD.SelectedPath;
                return dirPath;
            }
            else
            {
                dirPath = dirPath = $"%USERPROFILE%\\Desktop\\Extension";
                DirectoryInfo dir = Directory.CreateDirectory(dirPath);
                return dirPath;
            }
        }

        private void CreateDirectory()
        {
            System.IO.Directory.CreateDirectory($"{m.LocationText}\\{m.NameText}");
            System.IO.File.Copy(m.IconText, $"{m.LocationText}\\{m.NameText}\\icon.png", true);
        }
    }
}
