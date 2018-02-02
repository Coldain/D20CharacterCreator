using DnD4e.Assets.Scripts.Model;
using DnD4e.Assets.Scripts.Views.Editor;
using DnD4e.CharacterBuilder.Editor.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace DnD4e.Assets.Scripts.Views.Misc
{
    /// <summary>
    /// Interaction logic for PowerCard.xaml
    /// </summary>
    public partial class PowerCard : UserControl
    {
        public PowerCard(MainController main, Powers power)
        {
            DataContext = new
            {
                power = power,                
                character = main.characterCurrent,
            };
            InitializeComponent();
        }
    }
}
