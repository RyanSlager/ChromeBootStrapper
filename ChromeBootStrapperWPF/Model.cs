using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChromeBootStrapperWPF
{
    class Model
    {
        private string name;

        public string NameText
        {
            get { return name;  }
            set
            {
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
                icon = value;
                OnPropertyChange("IconText");
            }
           
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChange(string propertyName)
        {
            PropertyChangedEventHandler propertyChangedEvent = PropertyChanged;
            if (propertyChangedEvent != null)
            {
                propertyChangedEvent(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
