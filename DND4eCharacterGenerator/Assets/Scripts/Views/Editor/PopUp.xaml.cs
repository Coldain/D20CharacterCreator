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
using System.Windows.Shapes;

namespace DnD4e.Assets.Scripts.Views.Editor
{    
    public partial class PopUp : Window
    {
        public bool mouseBusy;

        public PopUp()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left && !mouseBusy && e.ButtonState == MouseButtonState.Pressed)
                this.DragMove();
        }
    }
}
