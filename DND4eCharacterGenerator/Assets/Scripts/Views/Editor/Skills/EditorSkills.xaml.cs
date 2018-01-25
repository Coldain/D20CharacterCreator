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

namespace DnD4e.Assets.Scripts.Views.Editor.Skills
{
    /// <summary>
    /// Interaction logic for EditorSkills.xaml
    /// </summary>
    public partial class EditorSkills : UserControl
    {
        Canvas canvasSelected;
        bool skillsAssigned;
        int skillsSelctionMax;
        int skillsSelctionCount;
        List<CheckBox> skillsSelectionCheckboxes;
        int skillsExtraMax;
        int skillsExtraCount;
        List<CheckBox> skillsExtraCheckboxes;
        int skillsRequiredMax;
        int skillsRequiredCount;
        List<CheckBox> skillsRequiredCheckboxes;
        List<CheckBox> priorSkillCheckboxes;
        Grid currentGrid;
        CharacterEditor editor;

        public EditorSkills(CharacterEditor _editor)
        {
            editor = _editor;
            DataContext = new
            {
                skills = editor.main.listDefinitionLists[2],
                abilities = editor.main.listDefinitionLists[1],
                character = editor.main.characterCurrent,
            }; 
            InitializeComponent();

            priorSkillCheckboxes = new List<CheckBox>();
            skillsSelectionCheckboxes = new List<CheckBox>();
            skillsExtraCheckboxes = new List<CheckBox>();
            skillsRequiredCheckboxes = new List<CheckBox>();
            if (editor.main.characterCurrent.Race.Race == "Human")
                skillsSelctionMax = editor.main.characterCurrent.Class.Subclass.SkillTraining + 1;
            else
                skillsSelctionMax = editor.main.characterCurrent.Class.Subclass.SkillTraining;
            int i = 0;
            Rectangle tempRectangle = null;
            CheckBox tempCheckbox = null;
            if (editor.main.characterCurrent.Class.Subclass.Skills != null)
                foreach (int tempSkill in editor.main.characterCurrent.Class.Subclass.Skills)
                {
                    bool priorSkill = false;
                    switch (i)
                    {
                        case 0:
                            tempRectangle = rectangleAcrobatics;
                            tempCheckbox = checkboxAcrobatics;
                            if (editor.main.characterCurrent.AcrobaticsTraining == true)
                                priorSkill = true;
                            break;
                        case 1:
                            tempRectangle = rectangleArcana;
                            tempCheckbox = checkboxArcana;
                            if (editor.main.characterCurrent.ArcanaTraining == true)
                                priorSkill = true;
                            break;
                        case 2:
                            tempRectangle = rectangleAthletics;
                            tempCheckbox = checkboxAthletics;
                            if (editor.main.characterCurrent.AthleticsTraining == true)
                                priorSkill = true;
                            break;
                        case 3:
                            tempRectangle = rectangleBluff;
                            tempCheckbox = checkboxBluff;
                            if (editor.main.characterCurrent.BluffTraining == true)
                                priorSkill = true;
                            break;
                        case 4:
                            tempRectangle = rectangleDiplomacy;
                            tempCheckbox = checkboxDiplomacy;
                            if (editor.main.characterCurrent.DiplomacyTraining == true)
                                priorSkill = true;
                            break;
                        case 5:
                            tempRectangle = rectangleDungeoneering;
                            tempCheckbox = checkboxDungeoneering;
                            if (editor.main.characterCurrent.DungeoneeringTraining == true)
                                priorSkill = true;
                            break;
                        case 6:
                            tempRectangle = rectangleEndurance;
                            tempCheckbox = checkboxEndurance;
                            if (editor.main.characterCurrent.EnduranceTraining == true)
                                priorSkill = true;
                            break;
                        case 7:
                            tempRectangle = rectangleHeal;
                            tempCheckbox = checkboxHeal;
                            if (editor.main.characterCurrent.HealTraining == true)
                                priorSkill = true;
                            break;
                        case 8:
                            tempRectangle = rectangleHistory;
                            tempCheckbox = checkboxHistory;
                            if (editor.main.characterCurrent.HistoryTraining == true)
                                priorSkill = true;
                            break;
                        case 9:
                            tempRectangle = rectangleInsight;
                            tempCheckbox = checkboxInsight;
                            if (editor.main.characterCurrent.InsightTraining == true)
                                priorSkill = true;
                            break;
                        case 10:
                            tempRectangle = rectangleIntimidate;
                            tempCheckbox = checkboxIntimidate;
                            if (editor.main.characterCurrent.IntimidateTraining == true)
                                priorSkill = true;
                            break;
                        case 11:
                            tempRectangle = rectangleNature;
                            tempCheckbox = checkboxNature;
                            if (editor.main.characterCurrent.AcrobaticsTraining == true)
                                priorSkill = true;
                            break;
                        case 12:
                            tempRectangle = rectanglePerception;
                            tempCheckbox = checkboxPerception;
                            if (editor.main.characterCurrent.PerceptionTraining == true)
                                priorSkill = true;
                            break;
                        case 13:
                            tempRectangle = rectangleReligion;
                            tempCheckbox = checkboxReligion;
                            if (editor.main.characterCurrent.ReligionTraining == true)
                                priorSkill = true;
                            break;
                        case 14:
                            tempRectangle = rectangleStealth;
                            tempCheckbox = checkboxStealth;
                            if (editor.main.characterCurrent.StealthTraining == true)
                                priorSkill = true;
                            break;
                        case 15:
                            tempRectangle = rectangleStreetwise;
                            tempCheckbox = checkboxStreetwise;
                            if (editor.main.characterCurrent.StreetwiseTraining == true)
                                priorSkill = true;
                            break;
                        case 16:
                            tempRectangle = rectangleThievery;
                            tempCheckbox = checkboxThievery;
                            if (editor.main.characterCurrent.ThieveryTraining == true)
                                priorSkill = true;
                            break;
                        default:
                            tempRectangle = null;
                            tempCheckbox = null;
                            break;
                    }
                    switch (tempSkill)
                    {
                        case 1:
                            skillsSelectionCheckboxes.Add(tempCheckbox);
                            break;
                        case 2:
                            skillsExtraCheckboxes.Add(tempCheckbox);
                            skillsExtraMax = 1;
                            break;
                        case 3:
                            tempRectangle.Fill = Brushes.Black;
                            tempCheckbox.IsChecked = true;
                            checkbox_Checked(tempCheckbox, null);
                            skillsRequiredCheckboxes.Add(tempCheckbox);
                            skillsRequiredMax++;
                            break;
                        default:
                            break;
                    }
                    if (tempSkill == 1 || tempSkill == 2)
                    {
                        tempRectangle.Fill = Brushes.Black;
                        tempCheckbox.Opacity = 1;
                        tempCheckbox.Focusable = true;
                        tempCheckbox.IsHitTestVisible = true;
                    }
                    tempCheckbox.Tag = tempSkill;
                    if (priorSkill)
                        priorSkillCheckboxes.Add(tempCheckbox);
                    i++;
                }
            foreach (CheckBox temp2Checkbox in priorSkillCheckboxes)
            {
                checkbox_Checked(temp2Checkbox, null);
            }
        }

        private void buttonClear_Click()
        {

        }

        private void buttonNext_Click()
        {
            //EditorPowers details = new EditorPowers(editor);
            editor.currentButton = editor.pathSkills.Name;
            editor.PathSelected();
            //editor.frameContainer.Content = details;
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

        private void buttonAuto_Click()
        {
            MessageBox.Show("Comming Soon...");
        }

        private void checkbox_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            if (!editor.main.characterCurrent.TrainedSkills.Contains(cb.Name.Substring(8)))
                editor.main.characterCurrent.TrainedSkills.Add(cb.Name.Substring(8));
            List<CheckBox> tempCheckBoxes = null;
            int tempMax = 0;
            int tempCount = 0;
            switch (cb.Tag)
            {
                case 1:
                    skillsSelctionCount++;
                    tempCheckBoxes = skillsSelectionCheckboxes;
                    tempMax = skillsSelctionMax;
                    tempCount = skillsSelctionCount;
                    break;
                case 2:
                    skillsExtraCount++;
                    tempCheckBoxes = skillsExtraCheckboxes;
                    tempMax = skillsExtraMax;
                    tempCount = skillsExtraCount;
                    break;
                case 3:
                    skillsRequiredCount++;
                    tempCheckBoxes = skillsRequiredCheckboxes;
                    tempMax = skillsRequiredMax;
                    tempCount = skillsRequiredCount;
                    break;
                default:
                    break;
            }
            int i = 0;
            if (tempCheckBoxes != null)
                if (tempCount >= tempMax)
                    foreach (CheckBox tempcb in tempCheckBoxes)
                    {
                        if (tempcb.IsChecked != true)
                        {
                            tempcb.Opacity = 0.5;
                            tempcb.Focusable = false;
                            tempcb.IsHitTestVisible = false;
                        }
                        i++;
                    }
        }

        private void checkbox_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            editor.main.characterCurrent.TrainedSkills.Remove(cb.Name.Substring(8));
            List<CheckBox> tempCheckBoxes = new List<CheckBox>();
            switch (cb.Tag)
            {
                case 1:
                    skillsSelctionCount--;
                    tempCheckBoxes = skillsSelectionCheckboxes;
                    break;
                case 2:
                    skillsExtraCount--;
                    break;
                case 3:
                    skillsRequiredCount--;
                    tempCheckBoxes = skillsRequiredCheckboxes;
                    break;
                default:
                    break;
            }
            int i = 0;
            foreach (CheckBox tempcb in tempCheckBoxes)
            {
                tempcb.Opacity = 1;
                tempcb.Focusable = true;
                tempcb.IsHitTestVisible = true;
                i++;
            }
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

