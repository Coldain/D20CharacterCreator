using DnD4e.CharacterBuilder.Editor.ViewModels;
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

namespace DnD4e.Assets.Scripts.Views.CharacterSheet
{
    /// <summary>
    /// Interaction logic for CSBattleMain.xaml
    /// </summary>
    public partial class CSBattleMain : Page
    {
        public CSBattleMain(MainController main)
        {
            DataContext = new
            {
                skills = main.listDefinitionLists[2],
                abilities = main.listDefinitionLists[1],
                character = main.characterCurrent,
            };
            InitializeComponent();
        }
    }
}
