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

namespace DnD4e.Assets.Scripts.Views.Editor.Class
{
    /// <summary>
    /// Interaction logic for SelectionDetailsClass.xaml
    /// </summary>
    public partial class SelectionDetailsClass : Page
    {
        public SelectionDetailsClass(Classes myClass, MainController main)
        {
            InitializeComponent();
            this.DataContext = myClass;

            foreach (Powers tempPowerL in main.listPowers)
            {
                foreach (string tempPowerC in myClass.Subclass.Powers)
                {
                    if (tempPowerC.ToUpper() == tempPowerL.Power.ToUpper())
                    {
                        PowerCard tempPowerCard = new PowerCard(main, tempPowerL);
                        stackpanelPowers.Children.Add(tempPowerCard);
                    }
                }
            }
            if (myClass.Subclass.SubClass != "Subclass")
            {
                if (myClass.Subclass.Bodies != null && myClass.Subclass.Bodies.Count > 1)
                    for (int i = 0; i < myClass.Subclass.Headers.Count; i++)
                    {
                        textblockHeaders.Inlines.Add(new Bold(new Run(myClass.Subclass.Headers[i].ToString())));
                        textblockHeaders.Inlines.Add(new Run(" " + myClass.Subclass.Bodies[i].ToString()));
                        textblockHeaders.Inlines.Add(new LineBreak());
                    }
                switch (myClass.Subclass.Abilities[0])
                {
                    case "Strength":
                        labelSTR.Foreground = Brushes.Black;
                        labelSTR.FontSize = 14;
                        break;
                    case "Constitution":
                        labelCON.Foreground = Brushes.Black;
                        labelCON.FontSize = 14;
                        break;
                    case "Dexterity":
                        labelDEX.Foreground = Brushes.Black;
                        labelDEX.FontSize = 14;
                        break;
                    case "Intelligence":
                        labelINT.Foreground = Brushes.Black;
                        labelINT.FontSize = 14;
                        break;
                    case "Wisdom":
                        labelWIS.Foreground = Brushes.Black;
                        labelWIS.FontSize = 14;
                        break;
                    case "Charisma":
                        labelCHA.Foreground = Brushes.Black;
                        labelCHA.FontSize = 14;
                        break;
                    default:
                        labelSTR.Foreground = Brushes.Black;
                        labelSTR.FontSize = 14;
                        labelCON.Foreground = Brushes.Black;
                        labelCON.FontSize = 14;
                        labelDEX.Foreground = Brushes.Black;
                        labelDEX.FontSize = 14;
                        labelINT.Foreground = Brushes.Black;
                        labelINT.FontSize = 14;
                        labelWIS.Foreground = Brushes.Black;
                        labelWIS.FontSize = 14;
                        labelCHA.Foreground = Brushes.Black;
                        labelCHA.FontSize = 14;
                        break;
                }
                switch (myClass.Subclass.Abilities[1])
                {
                    case "Charisma":
                        labelCHA.Foreground = Brushes.Gray;
                        break;
                    case "Intelligence":
                        labelINT.Foreground = Brushes.Gray;
                        break;
                    case "Wisdom":
                        labelWIS.Foreground = Brushes.Gray;
                        break;
                    case "Strength":
                        labelSTR.Foreground = Brushes.Gray;
                        break;
                    case "Dexterity":
                        labelDEX.Foreground = Brushes.Gray;
                        break;
                    case "Constitution":
                        labelCON.Foreground = Brushes.Gray;
                        break;
                    default:
                        break;
                }
                if (myClass.Subclass.Abilities.Count > 2)
                    switch (myClass.Subclass.Abilities[2])
                    {
                        case "Charisma":
                            labelCHA.Foreground = Brushes.DarkGray;
                            break;
                        case "Intelligence":
                            labelINT.Foreground = Brushes.DarkGray;
                            break;
                        case "Wisdom":
                            labelWIS.Foreground = Brushes.DarkGray;
                            break;
                        case "Strength":
                            labelSTR.Foreground = Brushes.DarkGray;
                            break;
                        case "Dexterity":
                            labelDEX.Foreground = Brushes.DarkGray;
                            break;
                        case "Constitution":
                            labelCON.Foreground = Brushes.DarkGray;
                            break;
                        default:
                            break;
                    }
                if (myClass.Subclass.Abilities.Count > 3)
                    switch (myClass.Subclass.Abilities[3])
                    {
                        case "Charisma":
                            labelCHA.Foreground = Brushes.DarkGray;
                            break;
                        case "Intelligence":
                            labelINT.Foreground = Brushes.DarkGray;
                            break;
                        case "Wisdom":
                            labelWIS.Foreground = Brushes.DarkGray;
                            break;
                        case "Strength":
                            labelSTR.Foreground = Brushes.DarkGray;
                            break;
                        case "Dexterity":
                            labelDEX.Foreground = Brushes.DarkGray;
                            break;
                        case "Constitution":
                            labelCON.Foreground = Brushes.DarkGray;
                            break;
                        default:
                            break;
                    }
            }  
        }
    }
}
