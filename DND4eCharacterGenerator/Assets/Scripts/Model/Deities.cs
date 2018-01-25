using DnD4e.CharacterBuilder.Editor.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD4e.Assets.Scripts.Model
{
    [Serializable]
    public class Deities : INotifyPropertyChanged
    {
        #region Fields
        private string _deity;
        private List<string> _domains;
        private List<string> _domainDescriptions;
        private string _setting;
        private string _image;
        private string _description;
        private string _shortDescription;
        private string _alignment;
        private List<string> _laws;
        #endregion

        #region Properties
        public string Deity
        {
            get
            {
                return _deity;
            }
            set
            {
                _deity = value;
                NotifyPropertyChanged("Deity");
            }
        }
        public List<string> Domains
        {
            get
            {
                return _domains;
            }
            set
            {
                _domains = value;
                NotifyPropertyChanged("Domains");
            }
        }
        public List<string> DomainDescriptions
        {
            get
            {
                return _domainDescriptions;
            }
            set
            {
                _domainDescriptions = value;
                NotifyPropertyChanged("DomainDescriptions");
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
        public string ShortDescription
        {
            get
            {
                return _shortDescription;
            }
            set
            {
                _shortDescription = value;
                NotifyPropertyChanged("Description");
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
        public string Alignment
        {
            get
            {
                return _alignment;
            }
            set
            {
                _alignment = value;
                NotifyPropertyChanged("Alignment");
            }
        }
        public List<string> Laws
        {
            get
            {
                return _laws;
            }
            set
            {
                _laws = value;
                NotifyPropertyChanged("Laws");
            }
        }
        #endregion

        #region Contstructors
        public Deities()
        {
            Deity = "Deity";
            ShortDescription = "Click to pick a Deity";
            Image = null;
        }

        public Deities(Deities copyDeity)
        {
            Deity = copyDeity.Deity;
            Domains = copyDeity.Domains;
            DomainDescriptions = copyDeity.DomainDescriptions;
            Setting = copyDeity.Setting;
            Image = copyDeity.Image;
            Description = copyDeity.Description;
            ShortDescription = copyDeity.ShortDescription;
        }

        public Deities(string deity_deity, List<string> deity_domains, List<string> deity_domainDescriptions, string deity_setting, string deity_image, string deity_description, string deity_shortDescription, string deity_alignment, List<string> deity_laws)
        {
            _deity = deity_deity;
            _domains = deity_domains;
            _domainDescriptions = deity_domainDescriptions;
            _setting = deity_setting;
            _image = deity_image;
            _description = deity_description;
            _shortDescription = deity_shortDescription;
            _alignment = deity_alignment;
            _laws = deity_laws;
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
