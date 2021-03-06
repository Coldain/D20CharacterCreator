﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD4e.Assets.Scripts.Model
{
    [Serializable]
    public class Classes : INotifyPropertyChanged
    {
        #region Fields
        private string _class;
        private List<string> _subclasses;
        private SubClasses _subclass;
        private string _primaryRoles;
        private string _secondaryRoles;
        private string _shortDescription;
        private List<string> _source;
        private string _image;
        private List<string> _preferedRaces;      
        #endregion

        #region Properties
        public string Class
        {
            get
            {
                return _class;
            }
            set
            {
                _class = value;
                NotifyPropertyChanged("Class");
            }
        }
        public List<string> Subclasses
        {
            get
            {
                return _subclasses;
            }
            set
            {
                _subclasses = value;
                NotifyPropertyChanged("Subclasses");
            }
        }
        public SubClasses Subclass
        {
            get
            {
                return _subclass;
            }
            set
            {
                _subclass = value;
                NotifyPropertyChanged("Subclass");
            }
        }
        public string PrimaryRoles
        {
            get
            {
                return _primaryRoles;
            }
            set
            {
                _primaryRoles = value;
                NotifyPropertyChanged("PrimaryRoles");
            }
        }
        public string SecondaryRoles
        {
            get
            {
                return _secondaryRoles;
            }
            set
            {
                _secondaryRoles = value;
                NotifyPropertyChanged("SecondaryRoles");
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
                NotifyPropertyChanged("ShortDescription");
            }
        }
        public List<string> Source
        {
            get
            {
                return _source;
            }
            set
            {
                _source = value;
                NotifyPropertyChanged("Source");
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
        public List<string> PreferredRaces
        {
            get
            {
                return _preferedRaces;
            }
            set
            {
                _preferedRaces = value;
                NotifyPropertyChanged("PreferredRaces");
            }
        }        
        #endregion

        #region Comstructors
        public Classes()
        {
            Class = "Class";
            Subclass = new SubClasses();
            ShortDescription = "Click to pick a Class";
        }

        public Classes(Classes copyClass)
        {
            Class = copyClass.Class;
            Subclasses = copyClass.Subclasses;
            Subclass = copyClass.Subclass;
            PrimaryRoles = copyClass.PrimaryRoles;
            SecondaryRoles = copyClass.SecondaryRoles;
            ShortDescription = copyClass.ShortDescription;
            Source = copyClass.Source;
            Image = copyClass.Image;
            PreferredRaces = copyClass.PreferredRaces;
        }

        public Classes(string class_class, List<string> class_subclasses, string class_primaryRoles, string class_secondaryRoles, string class_shortDescription, List<string> class_source, string class_image, List<string> class_preferedRaces)
        {
            _class = class_class;
            _subclasses = class_subclasses;
            _primaryRoles = class_primaryRoles;
            _secondaryRoles = class_secondaryRoles;
            _shortDescription = class_shortDescription;
            _source = class_source;
            _image = class_image;
            _preferedRaces = class_preferedRaces;
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
