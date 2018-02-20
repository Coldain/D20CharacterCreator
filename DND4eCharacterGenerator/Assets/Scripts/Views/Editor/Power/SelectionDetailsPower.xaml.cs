using DnD4e.Assets.Scripts.Model;
using DnD4e.Assets.Scripts.Views.Misc;
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

namespace DnD4e.Assets.Scripts.Views.Editor.Power
{
    public partial class SelectionDetailsPower : Page
    {
        public SelectionDetailsPower(Powers myPower, MainController main)
        {
            if (myPower != null && myPower.Source != null && myPower.Source != "")
            {
                textSource.Text = main.listDefinitionLists[0].MainList[main.listDefinitionLists[0].SubList.IndexOf(myPower.Source) - 1];
            }
            this.DataContext = myPower;
            InitializeComponent();
            PowerCard tempCard = new PowerCard(main, myPower);
            stackpanelPowers.Children.Add(tempCard);
        }
    }
}
