using System;
using System.Collections.Generic;
using System.IO;
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

namespace DnD4e.CharacterBuilder.Editor.View.Class
{
    /// <summary>
    /// Interaction logic for SelectionDetails.xaml
    /// </summary>
    public partial class SelectionDetailsRole : Page
    {
        bool pictureExists = true;
        public SelectionDetailsRole(string title, string details)
        {
            InitializeComponent();
            labelTile.Content = title;
            textBlockDetails.Text = details;
        }

        public SelectionDetailsRole(string title, string details, string _picture)
        {
            InitializeComponent();
            labelTile.Content = title;
            textBlockDetails.Text = details;
            BitmapImage picture = new BitmapImage();
            try
            {
                picture.BeginInit();
                picture.UriSource = new Uri("pack://application:,,," + _picture);
                picture.EndInit();
            }
            catch
            {
                picture = null;
            }
            image.Source = picture;
        }
    }
}
