using DnD4e.Assets.Scripts.Model;
using System;
using System.Collections.Generic;
using System.Linq;
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

namespace DnD4e.Assets.Scripts.Views.Editor.Class
{
    /// <summary>
    /// Interaction logic for SelectionDetailsClass.xaml
    /// </summary>
    public partial class SelectionDetailsBuild : Page
    {
        public SelectionDetailsBuild(Builds myBuild)
        {
            InitializeComponent();
            this.DataContext = myBuild;          
        }
    }
}
