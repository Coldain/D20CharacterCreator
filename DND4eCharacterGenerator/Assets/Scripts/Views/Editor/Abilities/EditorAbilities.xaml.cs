using DnD4e.Assets.Scripts.Views.Editor.Skills;
using DnD4e.CharacterBuilder.Editor.View.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace DnD4e.Assets.Scripts.Views.Editor.Abilities
{
    public partial class EditorAbilities : UserControl
    {
        int pointBuy;
        int STRPB;
        int CONPB;
        int DEXPB;
        int INTPB;
        int WISPB;
        int CHAPB;
        bool STRHB;
        bool CONHB;
        bool DEXHB;
        bool INTHB;
        bool WISHB;
        bool CHAHB;
        bool STRHB1;
        bool CONHB1 = true;
        bool DEXHB1 = true;
        bool INTHB1 = true;
        bool WISHB1 = true;
        bool CHAHB1 = true;
        bool deselect;
        Canvas canvasSelected;
        bool scoresAssigned;
        int racialSelctionMax;
        int racialSelctionCount;

        Grid currentGrid;
        CharacterEditor editor;
        public EditorAbilities(CharacterEditor _editor)
        {
            editor = _editor;
            DataContext = new
            {
                abilities = editor.main.listDefinitionLists[1],
                character = editor.main.characterCurrent,
            };
            InitializeComponent();

            if (editor.main.characterCurrent.Class.Subclass.SubClass != "Subclass")
            {
                PriorityFill(editor.main.characterCurrent.Class.Subclass.Abilities[0], "Black");
                if (editor.main.characterCurrent.Class.Subclass.Abilities.Count > 1)
                    PriorityFill(editor.main.characterCurrent.Class.Subclass.Abilities[1], "Gray");
                if (editor.main.characterCurrent.Class.Subclass.Abilities.Count > 2)
                    PriorityFill(editor.main.characterCurrent.Class.Subclass.Abilities[2], "DarkGray");
                if (editor.main.characterCurrent.Class.Subclass.Abilities.Count > 3)
                    PriorityFill(editor.main.characterCurrent.Class.Subclass.Abilities[3], "DarkGray");
            }
            if (editor.main.characterCurrent.Race.Race != "Race")
            {
                if (editor.main.characterCurrent.Race.Abilities.Count == 1)
                {
                    checkboxSTR.Opacity = 1;
                    checkboxSTR.Focusable = true;
                    checkboxSTR.IsHitTestVisible = true;
                    checkboxCON.Opacity = 1;
                    checkboxCON.Focusable = true;
                    checkboxCON.IsHitTestVisible = true;
                    checkboxDEX.Opacity = 1;
                    checkboxDEX.Focusable = true;
                    checkboxDEX.IsHitTestVisible = true;
                    checkboxINT.Opacity = 1;
                    checkboxINT.Focusable = true;
                    checkboxINT.IsHitTestVisible = true;
                    checkboxWIS.Opacity = 1;
                    checkboxWIS.Focusable = true;
                    checkboxWIS.IsHitTestVisible = true;
                    checkboxCHA.Opacity = 1;
                    checkboxCHA.Focusable = true;
                    checkboxCHA.IsHitTestVisible = true;
                    if (editor.main.characterCurrent.Race.Abilities[0] == "Any")
                        racialSelctionMax = 1;
                }
                else if (editor.main.characterCurrent.Race.Abilities.Count == 2)
                {
                    CheckIt(editor.main.characterCurrent.Race.Abilities[0], true);
                    CheckIt(editor.main.characterCurrent.Race.Abilities[1], true);
                }
                else if (editor.main.characterCurrent.Race.Abilities.Count == 3)
                {
                    CheckIt(editor.main.characterCurrent.Race.Abilities[0], true);
                    racialSelctionMax = 2;
                    FocusSwitch(editor.main.characterCurrent.Race.Abilities[1], 1, true);
                    FocusSwitch(editor.main.characterCurrent.Race.Abilities[2], 1, true);
                }
                if (editor.main.characterCurrent.Race.AbilityChoice != null && editor.main.characterCurrent.Race.AbilityChoice != "")
                {
                    CheckIt(editor.main.characterCurrent.Race.AbilityChoice, true);
                    racialSelctionCount = 1;
                    if (checkboxSTR != null)
                        if (checkboxSTR.IsChecked != true)
                            FocusSwitch("Str", 0.5, false);
                    if (checkboxCON != null)
                        if (checkboxCON.IsChecked != true)
                            FocusSwitch("Con", 0.5, false);
                    if (checkboxDEX != null)
                        if (checkboxDEX.IsChecked != true)
                            FocusSwitch("Dex", 0.5, false);
                    if (checkboxINT != null)
                        if (checkboxINT.IsChecked != true)
                            FocusSwitch("Int", 0.5, false);
                    if (checkboxWIS != null)
                        if (checkboxWIS.IsChecked != true)
                            FocusSwitch("Wis", 0.5, false);
                    if (checkboxCHA != null)
                        if (checkboxCHA.IsChecked != true)
                            FocusSwitch("Cha", 0.5, false);
                }
            } 
        }

        private void buttonClear_Click()
        {
            editor.main.characterCurrent.StrengthRaw = 8;
            editor.main.characterCurrent.ConstitutionRaw = 10;
            editor.main.characterCurrent.DexterityRaw = 10;
            editor.main.characterCurrent.IntelligenceRaw = 10;
            editor.main.characterCurrent.WisdomRaw = 10;
            editor.main.characterCurrent.CharismaRaw = 10;
        }

        private void buttonNext_Click()
        {
            if (editor.main.characterCurrent.Class.Subclass.SubClass != "Subclass")
            {
                EditorSkills details = new EditorSkills(editor);
                editor.currentButton = editor.pathSkills.Name;
                editor.PathSelected();
                editor.frameContainer.Content = details;
            }
        }       

        private void path_MouseEnter(object sender, MouseEventArgs e)
        {
            Path tempPath = sender as Path;           
            tempPath.Opacity = 0;            
        }

        private void path_MouseLeave(object sender, MouseEventArgs e)
        {
            Path tempPath = sender as Path;
            tempPath.Opacity = 0.2;
        }

        private void path_MouseDown(object sender, MouseEventArgs e)
        {
            editor.mouseBusy = true;
            Path tempPath = sender as Path;
            tempPath.Opacity = 0;
            Canvas canvas = (Canvas)tempPath.Parent;
            TranslateTransform translation = new TranslateTransform(3, 3);
            canvas.RenderTransform = translation;
            Mouse.Capture(tempPath);
        }


        private void path_MouseUp(object sender, MouseEventArgs e)
        {
            Path tempPath = sender as Path;
            Canvas canvas = (Canvas)tempPath.Parent;
            TranslateTransform translation = new TranslateTransform(0, 0);
            canvas.RenderTransform = translation;
            Mouse.Capture(null);
            ButtonOption(canvas);
            editor.mouseBusy = false;
        }

        private void ButtonOption(Canvas canvas)
        {
            switch (canvas.Name)
            {
                case "buttonSTRUp":
                    editor.main.characterCurrent.StrengthRaw++;
                    break;
                case "buttonCONUp":
                    editor.main.characterCurrent.ConstitutionRaw++;
                    break;
                case "buttonDEXUp":
                    editor.main.characterCurrent.DexterityRaw++;
                    break;
                case "buttonINTUp":
                    editor.main.characterCurrent.IntelligenceRaw++;
                    break;
                case "buttonWISUp":
                    editor.main.characterCurrent.WisdomRaw++;
                    break;
                case "buttonCHAUp":
                    editor.main.characterCurrent.CharismaRaw++;
                    break;
                case "buttonSTRDown":
                    editor.main.characterCurrent.StrengthRaw--;
                    break;
                case "buttonCONDown":
                    editor.main.characterCurrent.ConstitutionRaw--;
                    break;
                case "buttonDEXDown":
                    editor.main.characterCurrent.DexterityRaw--;
                    break;
                case "buttonINTDown":
                    editor.main.characterCurrent.IntelligenceRaw--;
                    break;
                case "buttonWISDown":
                    editor.main.characterCurrent.WisdomRaw--;
                    break;
                case "buttonCHADown":
                    editor.main.characterCurrent.CharismaRaw--;
                    break;
                case "buttonRoll":
                    buttonRoll_Click();
                    break;
                case "buttonAssign":
                    buttonAssign_Click(null);
                    break;
                case "buttonAuto":
                    buttonAuto_Click();
                    break;
                case "buttonClear":
                    buttonClear_Click();
                    break;
                case "buttonNext":
                    buttonNext_Click();
                    break;
                    
            }
        }

        private void buttonRoll_Click()
        {
            Random rand = new Random();
            List<int> list = new List<int>();
            for (int x = 0; x < 7; x++)
            {
                List<int> rolls = new List<int>();
                rolls.Add((int)Math.Floor((double)rand.Next(1, 7)));
                rolls.Add((int)Math.Floor((double)rand.Next(1, 7)));
                rolls.Add((int)Math.Floor((double)rand.Next(1, 7)));
                rolls.Add((int)Math.Floor((double)rand.Next(1, 7)));
                rolls = rolls.OrderByDescending(i => i).ToList();
                int score = rolls[0] + rolls[1] + rolls[2];
                list.Add(score);
            } 
            list = list.OrderByDescending(i => i).ToList();
            buttonAssign_Click(list);            
        }

        private void buttonAssign_Click(List<int> array)
        {
            if (array == null)
                if (comboboxArray.SelectedItem != null)
                {

                    string st = comboboxArray.SelectedValue.ToString();
                    array = new List<int>();
                    List<string> converter = st.Split(',').ToList();
                    foreach (string s in converter)
                    {
                        array.Add(Convert.ToInt16(s));
                    }
                }
                else
                {
                    MessageBox.Show("Please select an array.");
                    return;
                }
            if (editor.main.characterCurrent.Class.Subclass == null ||  editor.main.characterCurrent.Class.Class == "Class")
            {
                MessageBox.Show("This works better if you've selected a class and subclass.");
            }
            string[] abilities = new string[] { "Constitution", "Dexterity", "Charisma", "Strength", "Wisdom", "Intelligence" };
            Queue<string> queue = new Queue<string>();
            if (editor.main.characterCurrent.Class.Subclass.Abilities != null && editor.main.characterCurrent.Class.Subclass.Abilities[0] != null)
            {
                queue.Enqueue(editor.main.characterCurrent.Class.Subclass.Abilities[0]);
                if (editor.main.characterCurrent.Class.Subclass.Abilities.Count > 1)
                    queue.Enqueue(editor.main.characterCurrent.Class.Subclass.Abilities[1]);
                if (editor.main.characterCurrent.Class.Subclass.Abilities.Count > 2)
                    queue.Enqueue(editor.main.characterCurrent.Class.Subclass.Abilities[2]);
                if (editor.main.characterCurrent.Class.Subclass.Abilities.Count > 3)
                    queue.Enqueue(editor.main.characterCurrent.Class.Subclass.Abilities[3]);
            }
            foreach (string ability in abilities)
            {
                if (!queue.Contains(ability))
                    queue.Enqueue(ability);
            }
            for (int i = 0; i < 6; i++)
            {
                switch (queue.Dequeue())
                {
                    case "Constitution":
                        editor.main.characterCurrent.ConstitutionRaw = array[i];
                        break;
                    case "Dexterity":
                        editor.main.characterCurrent.DexterityRaw = array[i];
                        break;
                    case "Charisma":
                        editor.main.characterCurrent.CharismaRaw = array[i];
                        break;
                    case "Strength":
                        editor.main.characterCurrent.StrengthRaw = array[i];
                        break;
                    case "Wisdom":
                        editor.main.characterCurrent.WisdomRaw = array[i];
                        break;
                    case "Intelligence":
                        editor.main.characterCurrent.IntelligenceRaw = array[i];
                        break;
                }
            }
        }

        private void buttonAuto_Click()
        {
            MessageBox.Show("Comming Soon...");
        }

        private void textbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (tb.Text != null && tb.Text != "")
            {
                switch (tb.Name)
                {
                    case "STRRaw":
                        if (tb.Text != null || tb.Text != "")
                        {
                            if (Convert.ToInt16(tb.Text) > 7 && Convert.ToInt16(tb.Text) < 19)
                            {
                                STRPB = BuyingPoints(Convert.ToInt16(tb.Text));
                                STRHB = false;                                
                            }
                            else
                                STRHB = true;
                            if (Convert.ToInt16(tb.Text) < 10)
                                STRHB1 = true;
                            else
                                STRHB1 = false;
                            editor.main.characterCurrent.StrengthRaw = Convert.ToInt16(tb.Text);
                        }
                        break;
                    case "CONRaw":
                        if (tb.Text != null || tb.Text != "")
                        {
                            if (Convert.ToInt16(tb.Text) > 7 && Convert.ToInt16(tb.Text) < 19)
                            {
                                CONPB = BuyingPoints(Convert.ToInt16(tb.Text));
                                CONHB = false;
                            }
                            else
                                CONHB = true;
                            if (Convert.ToInt16(tb.Text) < 10)
                                CONHB1 = true;
                            else
                                CONHB1 = false;
                            editor.main.characterCurrent.ConstitutionRaw = Convert.ToInt16(tb.Text);
                        }
                        break;
                    case "DEXRaw":
                        if (tb.Text != null || tb.Text != "")
                        {
                            if (Convert.ToInt16(tb.Text) > 7 && Convert.ToInt16(tb.Text) < 19)
                            {
                                DEXPB = BuyingPoints(Convert.ToInt16(tb.Text));
                                DEXHB = false;
                            }
                            else
                                DEXHB = true;
                            if (Convert.ToInt16(tb.Text) < 10)
                                DEXHB1 = true;
                            else
                                DEXHB1 = false;
                            editor.main.characterCurrent.DexterityRaw = Convert.ToInt16(tb.Text);
                        }
                        break;
                    case "INTRaw":
                        if (tb.Text != null || tb.Text != "" || tb.Text != "-")
                        {
                            if (Convert.ToInt16(tb.Text) > 7 && Convert.ToInt16(tb.Text) < 19)
                            {
                                INTPB = BuyingPoints(Convert.ToInt16(tb.Text));
                                INTHB = false;
                            }
                            else
                                INTHB = true;
                            if (Convert.ToInt16(tb.Text) < 10)
                                INTHB1 = true;
                            else
                                INTHB1 = false;
                            editor.main.characterCurrent.IntelligenceRaw = Convert.ToInt16(tb.Text);
                        }
                        break;
                    case "WISRaw":
                        if (tb.Text != null || tb.Text != "" || tb.Text != "-")
                        {
                            if (Convert.ToInt16(tb.Text) > 7 && Convert.ToInt16(tb.Text) < 19)
                            {
                                WISPB = BuyingPoints(Convert.ToInt16(tb.Text));
                                WISHB = false;
                            }
                            else
                                WISHB = true;
                            if (Convert.ToInt16(tb.Text) < 10)
                                WISHB1 = true;
                            else
                                WISHB1 = false;
                            editor.main.characterCurrent.WisdomRaw = Convert.ToInt16(tb.Text);
                        }
                        break;
                    case "CHARaw":
                        if (tb.Text != null || tb.Text != "" || tb.Text != "-")
                        {
                            if (Convert.ToInt16(tb.Text) > 7 && Convert.ToInt16(tb.Text) < 19)
                            {
                                CHAPB = BuyingPoints(Convert.ToInt16(tb.Text));
                                CHAHB = false;
                            }
                            else
                                CHAHB = true;
                            if (Convert.ToInt16(tb.Text) < 10)
                                CHAHB1 = true;
                            else
                                CHAHB1 = false;
                            editor.main.characterCurrent.CharismaRaw = Convert.ToInt16(tb.Text);
                        }
                        break;
                }
             }
            int i = 0;
            List<bool> HB = new List<bool>(new bool[] { STRHB1, CONHB1, DEXHB1, INTHB1, WISHB1, CHAHB1 });
            foreach (bool bl in HB)
                if (bl)
                    i++;
            pointBuy = STRPB + CONPB + DEXPB + INTPB + WISPB + CHAPB + 2;
            PBPoints.Text = pointBuy.ToString();
            if (STRHB || CONHB || DEXHB || INTHB || WISHB || CHAHB || i > 1 )
                homebrew.Visibility = Visibility.Visible;
            else
                homebrew.Visibility = Visibility.Hidden;
            if (pointBuy != 22)
            {
                if (buttonNext != null && buttonNext.IsEnabled)
                {
                    canvasNext.Opacity = 0.6;
                    buttonNext.IsEnabled = false;
                    editor.pathAbilitiesFinished.Visibility = Visibility.Hidden;
                    editor.abilitiesFinished = false;
                }
            }
            else
            {
                if (canvasNext != null)
                canvasNext.Opacity = 0.2;
                if (buttonNext != null)
                buttonNext.IsEnabled = true;
                editor.pathAbilitiesFinished.Visibility = Visibility.Visible;
                editor.abilitiesFinished = true;
            }
        }

        private void checkbox_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            if (racialSelctionMax == 1 || (racialSelctionMax == 2 && racialSelctionCount == 0))
            {
                switch (cb.Name)
                {
                    case "checkboxSTR":
                        editor.main.characterCurrent.Race.AbilityChoice = "STR";
                        break;
                    case "checkboxCON":
                        editor.main.characterCurrent.Race.AbilityChoice = "CON";
                        break;
                    case "checkboxDEX":
                        editor.main.characterCurrent.Race.AbilityChoice = "DEX";
                        break;
                    case "checkboxINT":
                        editor.main.characterCurrent.Race.AbilityChoice = "INT";
                        break;
                    case "checkboxWIS":
                        editor.main.characterCurrent.Race.AbilityChoice = "WIS";
                        break;
                    case "checkboxCHA":
                        editor.main.characterCurrent.Race.AbilityChoice = "CHA";
                        break;
                }
                racialSelctionCount++;
            }
            if (checkboxSTR != null)
                if (checkboxSTR.IsChecked != true)
                    FocusSwitch("Str", 0.5, false);
            if (checkboxCON != null)
                if (checkboxCON.IsChecked != true)
                    FocusSwitch("Con", 0.5, false);
            if (checkboxDEX != null)
                if (checkboxDEX.IsChecked != true)
                    FocusSwitch("Dex", 0.5, false);
            if (checkboxINT != null)
                if (checkboxINT.IsChecked != true)
                    FocusSwitch("Int", 0.5, false);
            if (checkboxWIS != null)
                if (checkboxWIS.IsChecked != true)
                    FocusSwitch("Wis", 0.5, false);
            if (checkboxCHA != null)
                if (checkboxCHA.IsChecked != true)
                    FocusSwitch("Cha", 0.5, false);
        }

        private void checkbox_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            if (racialSelctionMax == 1 || (racialSelctionMax == 2 && racialSelctionCount == 1))
            {
                editor.main.characterCurrent.Race.AbilityChoice = "";
                racialSelctionCount--;
            }

            if (racialSelctionMax == 2 && racialSelctionCount == 0)
            {
                FocusSwitch(editor.main.characterCurrent.Race.Abilities[1], 1, true);
                FocusSwitch(editor.main.characterCurrent.Race.Abilities[2], 1, true);
            }            
                if (racialSelctionMax == 1 && racialSelctionCount == 0)
                {
                    FocusSwitch("Str", 1, true);
                    FocusSwitch("Con", 1, true);
                    FocusSwitch("Dex", 1, true);
                    FocusSwitch("Int", 1, true);
                    FocusSwitch("Wis", 1, true);
                    FocusSwitch("Cha", 1, true);
                }
        }

        private int BuyingPoints(int score)
        {            
            if (score >= 8 && score < 14)
                return (score - 10);
            else if (score >= 14 && score < 17)
                return (1 + (2 * (score - 12)));
            else if (score == 17)
                return 12;
            else if (score == 18)
                return 16;
            else
                return 100;
        }

        public static bool IsNumber(object value)
        {
            return value is sbyte
                    || value is byte
                    || value is short
                    || value is ushort
                    || value is int
                    || value is uint
                    || value is long
                    || value is ulong
                    || value is float
                    || value is double
                    || value is decimal;
        }

        private void PriorityFill(string stat, string color)
        {
            var converter = new BrushConverter();
            var brush = (Brush)converter.ConvertFromString(color);
            switch (stat)
            {
                case "Strength":
                    rectangleSTR.Fill = brush;
                    break;
                case "Constitution":
                    rectangleCON.Fill = brush;
                    break;
                case "Dexterity":
                    rectangleDEX.Fill = brush;
                    break;
                case "Intelligence":
                    rectangleINT.Fill = brush;
                    break;
                case "Wisdom":
                    rectangleWIS.Fill = brush;
                    break;
                case "Charisma":
                    rectangleCHA.Fill = brush;
                    break;
                default:
                    rectangleSTR.Fill = brush;
                    rectangleCON.Fill = brush;
                    rectangleDEX.Fill = brush;
                    rectangleINT.Fill = brush;
                    rectangleWIS.Fill = brush;
                    rectangleCHA.Fill = brush;
                    break;
            }
        }

        private void CheckIt(string stat, bool state)
        {
            switch (stat)
            {
                case "Str":
                    checkboxSTR.IsChecked = state;
                    break;
                case "Con":
                    checkboxCON.IsChecked = state;
                    break;
                case "Dex":
                    checkboxDEX.IsChecked = state;
                    break;
                case "Int":
                    checkboxINT.IsChecked = state;
                    break;
                case "Wis":
                    checkboxWIS.IsChecked = state;
                    break;
                case "Cha":
                    checkboxCHA.IsChecked = state;
                    break;
                default:
                    break;
            }
        }

        private void FocusSwitch(string stat, double i, bool state)
        {
            switch (stat)
            {
                case "Str":
                    checkboxSTR.Opacity = i;
                    checkboxSTR.Focusable = state;
                    checkboxSTR.IsHitTestVisible = state;
                    break;
                case "Con":
                    checkboxCON.Opacity = i;
                    checkboxCON.Focusable = state;
                    checkboxCON.IsHitTestVisible = state;
                    break;
                case "Dex":
                    checkboxDEX.Opacity = i;
                    checkboxDEX.Focusable = state;
                    checkboxDEX.IsHitTestVisible = state;
                    break;
                case "Int":
                    checkboxINT.Opacity = i;
                    checkboxINT.Focusable = state;
                    checkboxINT.IsHitTestVisible = state;
                    break;
                case "Wis":
                    checkboxWIS.Opacity = i;
                    checkboxWIS.Focusable = state;
                    checkboxWIS.IsHitTestVisible = state;
                    break;
                case "Cha":
                    checkboxCHA.Opacity = i;
                    checkboxCHA.Focusable = state;
                    checkboxCHA.IsHitTestVisible = state;
                    break;
                default:
                    break;
            }
        }

        private void text_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            NumberValidationTextBox(e);
        }

        private void NumberValidationTextBox(TextCompositionEventArgs e)
        {
            int result;
            if (!(int.TryParse(e.Text, out result) || e.Text == "."))
            {
                e.Handled = true;
            }
        }
    }
}

