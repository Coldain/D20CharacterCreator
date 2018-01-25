using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD4e.Assets.Scripts.Model
{
    [Serializable]
    public class Campaigns : INotifyPropertyChanged
    {
        #region Fields
        private string _setting;
        private string _image;
        private string _shortDescription;
        #endregion

        #region Properties
        public string Setting
        {
            get
            {
                return _setting;
            }
            set
            {
                _setting = value;
                NotifyPropertyChanged("Setting");
            }
        }
        public string Image
        {
            get
            {
                return _image;
            }
            set
            {
                _image = value;
                NotifyPropertyChanged("Image");
            }
        }
        public string Shortdescription
        {
            get
            {
                return _shortDescription;
            }
            set
            {
                _shortDescription = value;
                NotifyPropertyChanged("Shortdescription");
            }
        }
        #endregion

        #region Constructors
        public Campaigns (string tempSetting, string tempImage, string tempShortDescription)
        {
            Setting = tempSetting;
            Image = tempImage;
            Shortdescription = tempShortDescription;
        }

        public Campaigns()
        {
        }

        #endregion

        #region Methods
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
        #endregion
    }
}
