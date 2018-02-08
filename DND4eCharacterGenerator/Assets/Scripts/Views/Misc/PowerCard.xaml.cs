using DnD4e.Assets.Scripts.Model;
using DnD4e.Assets.Scripts.Views.Editor;
using DnD4e.CharacterBuilder.Editor.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        MainController main = new MainController();
        public PowerCard(MainController _main, Powers power)
        {
            main = _main;
            List<tempPowerDetails> details = new List<tempPowerDetails>();
            for (int i = 0; i < power.Headers.Count; i++)
            {
                tempPowerDetails temp = new tempPowerDetails();
                temp.Header = power.Headers[i];
                temp.Body = Parser(power.Bodies[i]);
                temp.Filled = i % 2;
                details.Add(temp);
            }
            // need to split the levels and determin which hit based on the level.
            if (power.Hits.Count() > 0)
                power.Hit = Parser(power.Hits[0]);  
            power.AttackType = Attack(power.AttackType);
            DataContext = new
            {
                power = power,                
                character = main.characterCurrent,
                details = details,
            };
            InitializeComponent();
            
            SPPowers.ItemsSource = details;

        }

        private string Parser (string text)
        {
            string tempText = "";
            String[] substrings = text.Split('~');
            for (int i=0; i < substrings.Count(); i++)
            {
                switch (substrings[i])
                {
                    case "STRMod":
                        substrings[i] = main.characterCurrent.StrengthMod.ToString();
                        break;
                    case "CONMod":
                        substrings[i] = main.characterCurrent.ConstitutionMod.ToString();
                        break;
                    case "DEXMod":
                        substrings[i] = main.characterCurrent.DexterityMod.ToString();
                        break;
                    case "WISMod":
                        substrings[i] = main.characterCurrent.WisdomMod.ToString();
                        break;
                    case "INTMod":
                        substrings[i] = main.characterCurrent.IntelligenceMod.ToString();
                        break;
                    case "CHAMod":
                        substrings[i] = main.characterCurrent.CharismaMod.ToString();
                        break;
                    default:
                        break;
                }
                tempText = tempText + substrings[i];
            }
            return tempText;
        }

        private string Attack(string text)
        {
            switch (text)
            {
                case "STR":
                    return main.characterCurrent.StrengthCheck.ToString();
                case "CON":
                    return main.characterCurrent.ConstitutionCheck.ToString();
                case "DEX":
                    return main.characterCurrent.DexterityCheck.ToString();
                case "WIS":
                    return main.characterCurrent.WisdomCheck.ToString();
                case "INT":
                    return main.characterCurrent.IntelligenceCheck.ToString();
                case "CHA":
                    return main.characterCurrent.CharismaCheck.ToString();
                default:
                    return text;
            }
        }
    }
    
    public class tempPowerDetails
    {
        public string Header { get; set; }
        public string Body { get; set; }
        public int Filled { get; set; }
    }
}
