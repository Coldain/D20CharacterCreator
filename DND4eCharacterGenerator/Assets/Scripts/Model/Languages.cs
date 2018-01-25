using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD4e.Assets.Scripts.Model
{
    public class Languages : INotifyPropertyChanged
    {
        #region Fields
        private string _language;
        private string _setting;
        private string _description;
        private string _image;
        #endregion

        #region Properties
        public string Language
        {
            get
            {
                return _language;
            }
            set
            {
                _language = value;
                NotifyPropertyChanged("Language");
            }
        }
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
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
                NotifyPropertyChanged("Description");
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
        #endregion

        #region Constructors
        public Languages()
        {

        }
        public Languages(Languages copyLanguage)
        {
            Language = copyLanguage.Language;
            Setting = copyLanguage.Setting;
            Description = copyLanguage.Description;
            Image = copyLanguage.Image;
        }
        #endregion

        #region Methods

        #region INotify
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
        #endregion
        #endregion
    }
}
