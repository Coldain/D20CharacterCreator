using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD4e.Assets.Scripts.Model
{
    class Information
    {
        #region Properties
        public string Name { get; set; }
        public List<string> List { get; set; }
        public List<string> Definition { get; set; }
        public List<string> Sublist { get; set; }
        #endregion
    }
}
