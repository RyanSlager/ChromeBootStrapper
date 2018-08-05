using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ChromeBootStrapperWPF
{
    class Model : INotifyPropertyChanged
    {
        private string name;

        public string NameText
        {
            get { return name;  }
            set
            {
                if (value == name)
                    return;

                name = value;
                OnPropertyChange("NameText");
            }
        }

        private string description;

        public string DescriptionText
        {
            get { return description; }
            set
            {
                if (value == description)
                    return;

                description = value;
                OnPropertyChange("DescriptionText");
            }
        }

        private string author;

        public string AuthorText
        {
            get { return author; }
            set
            {
                if (value == author)
                    return;

                author = value;
                OnPropertyChange("AuthorText");
            }
        }

        private string location;

        public string LocationText
        {
            get { return location; }
            set
            {
                if (value == location)
                    return;

                location = value;
                OnPropertyChange("LocationText");
            }
        }

        private string icon;

        public string IconText
        {
            get { return icon; }
            set
            {
                if (value == icon)
                    return;

                icon = value;
                OnPropertyChange("IconText");
            }
           
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChange(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
