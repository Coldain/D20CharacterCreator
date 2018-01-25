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

namespace DnD4e.Assets.Scripts.Views.Editor.Race
{
    public partial class SelectionDetailsRace : Page
    {
        public SelectionDetailsRace(Races myRace)
        {
            InitializeComponent();
            this.DataContext = myRace;

            if (myRace.Race != "Race")
            {
                if (myRace.Description != null)
                {
                    textblockDescription.Inlines.Add(new Bold(new Run("Description")));
                    textblockDescription.Inlines.Add(new LineBreak());
                    for (int i = 0; i < myRace.Description.Count; i++)
                    {                      
                        textblockDescription.Inlines.Add(new Run(myRace.Description[i].ToString()));
                        textblockDescription.Inlines.Add(new LineBreak());
                    }
                }
                if (myRace.Bodies != null && myRace.Bodies.Count > 1)
                    for (int i = 0; i < myRace.Headers.Count; i++)
                    {
                        textblockHeaders.Inlines.Add(new Bold(new Run(myRace.Headers[i].ToString())));
                        textblockHeaders.Inlines.Add(new Run(" " + myRace.Bodies[i].ToString()));
                        textblockHeaders.Inlines.Add(new LineBreak());
                    }                
                Abilities(myRace.Abilities[0], Brushes.Black, 14);
                if (myRace.Abilities.Count == 2)
                    Abilities(myRace.Abilities[1], Brushes.Black, 14);
                if (myRace.Abilities.Count == 3)
                {
                    Abilities(myRace.Abilities[1], Brushes.Gray, 12);
                    Abilities(myRace.Abilities[2], Brushes.Gray, 12);
                }
            }
        }    

        private void Abilities(string ability, Brush brush, int size)
        {
            switch (ability)
            {
                case "Str":
                    labelSTR.Content = "+2";
                    labelSTR.Foreground = brush;
                    labelSTR.FontSize = size;
                    break;
                case "Con":
                    labelCON.Content = "+2";
                    labelCON.Foreground = brush;
                    labelCON.FontSize = size;
                    break;
                case "Dex":
                    labelDEX.Content = "+2";
                    labelDEX.Foreground = brush;
                    labelDEX.FontSize = size;
                    break;
                case "Int":
                    labelINT.Content = "+2";
                    labelINT.Foreground = brush;
                    labelINT.FontSize = size;
                    break;
                case "Wis":
                    labelWIS.Content = "+2";
                    labelWIS.Foreground = brush;
                    labelWIS.FontSize = size;
                    break;
                case "Cha":
                    labelCHA.Content = "+2";
                    labelCHA.Foreground = brush;
                    labelCHA.FontSize = size;
                    break;
                default:
                    labelSTR.Content = "+2";
                    labelSTR.Foreground = Brushes.Gray;
                    labelCON.Content = "+2";
                    labelCON.Foreground = Brushes.Gray;
                    labelDEX.Content = "+2";
                    labelDEX.Foreground = Brushes.Gray;
                    labelINT.Content = "+2";
                    labelINT.Foreground = Brushes.Gray;
                    labelWIS.Content = "+2";
                    labelWIS.Foreground = Brushes.Gray;
                    labelCHA.Content = "+2";
                    labelCHA.Foreground = Brushes.Gray;
                    break;
            }
        }          
    }
}
