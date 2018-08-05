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

        private void launchBrowser(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.Button b = (System.Windows.Controls.Button)sender;
            
            //System.Windows.MessageBox.Show(name);

            if(b.Name.Equals("iconSearch"))
            {
                m.IconText = pickIcon();
            }
            else if(b.Name.Equals("locSearch"))
            {
                m.LocationText = pickLocation();
            }

            
            System.Windows.MessageBox.Show(m.IconText, m.LocationText);
        }

        private void createExtension(object sender, RoutedEventArgs e)
        {
            System.Windows.MessageBox.Show($"{m.IconText}, {m.LocationText}, {m.NameText}, {m.DescriptionText}, {m.AuthorText}");

            //Manifest man = new Manifest(m.LocationText, m.NameText, m.DescriptionText,
            //    m.AuthorText, false);

            //man.writeManifest();
        }

        private string pickIcon()
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

        private string pickLocation()
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
    }
}
