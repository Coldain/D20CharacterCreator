
using DnD4e.Assets.Scripts.Controller.Data;
using DnD4e.Assets.Scripts.Model;
using DnD4e.CharacterBuilder.Editor.ViewModels;
using DnD4e.CharacterOOP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using WpfApplication1;

namespace DnD4e.Assets.Scripts.Views.Home
{
    public partial class LoadingPage : Window
    {
        public MainController main = new MainController();
        public ExcelImporter tempExcel = new ExcelImporter();
        HomePage homePage = new HomePage();
        int mainLoadTotals = 11;
        int mainLoadCurrent = 0;
        string mainLoadName = "Data Loading...";

        public LoadingPage()
        {
            InitializeComponent();
            this.Show();
            labelLoadingMain.Content = mainLoadName;     
            BackgroundWorker worker = new BackgroundWorker();
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;      
            worker.WorkerReportsProgress = true;
            worker.DoWork += worker_DoWork;
            worker.ProgressChanged += worker_ProgressChanged;
            worker.RunWorkerAsync();
        }

        private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            loaderCurrent.Width = e.ProgressPercentage * 7;
            labelCurrentPercentage.Content = e.ProgressPercentage.ToString() + "%";
            labelLoadingCurrent.Content = (string)e.UserState;
            if (e.ProgressPercentage == 100)
            {
                mainLoadCurrent++;
                int percentageMain = (mainLoadCurrent) * 100 / mainLoadTotals;
                loaderMain.Width = percentageMain * 7;
                labelMainPercentage.Content = percentageMain.ToString() + "%";
                labelLoadingMain.Content = mainLoadName;
            }
        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Mouse.OverrideCursor = null;
            MessageBox.Show("Loading Complete");
            main.dataLoaded = true;
            homePage.main = main;
            homePage.Show();
            this.Close();
        }
        
        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            #region Initializer / Referencer Data
            List<string> sheets = new List<string>();
            List<int> itemCounts = new List<int>();
            tempExcel.Create();
            mainLoadName = "Loading Reference Magic...";
            tempExcel.SetSheet("Referencer");
            var worker = sender as BackgroundWorker;
            worker.ReportProgress(0, String.Format("DataLoading"));
            for (int i = 2; i < 17; i++)
            {
                double percentage = ((double)i / (double)16) * 100.0;
                string row = i.ToString();
                List<string> myReferencerData = tempExcel.GetRangeValue("A" + row, "B" + row);
                sheets.Add(myReferencerData[0]);
                Thread.Sleep(1);
                worker.ReportProgress((int)percentage, String.Format("Processing " + myReferencerData[0]));
                itemCounts.Add(Convert.ToInt16(myReferencerData[1]));
            }
            #endregion

            int x = 0;


            #region Definitions Data
            mainLoadName = "Loading the archives of knowledge...";
            tempExcel.SetSheet(sheets[x]);
            for (int i = 2; i < (itemCounts[x] + 2); i++)
            {
                double percentage = ((double)i / (double)(itemCounts[x] + 1)) * 100.0;
                string row = i.ToString();
                List<string> myDefinitionData = tempExcel.GetRangeValue("A" + row, "D" + row);
                Definitions tempDefinition = new Definitions();
                tempDefinition.Name = myDefinitionData[0];
                Thread.Sleep(1);
                worker.ReportProgress((int)percentage, String.Format("Processing " + tempDefinition.Name));
                tempDefinition.Description = myDefinitionData[1];
                tempDefinition.Pick = myDefinitionData[2];
                main.listDefinitions.Add(tempDefinition);
            }
            x++;
            #endregion

            #region Lists Data
            mainLoadName = "Loading Definitions Settings...";
            tempExcel.SetSheet(sheets[x]);            
            for (int i = 2; i < (itemCounts[x] + 2); i++)
            {
                double percentage = ((double)i / (double)(itemCounts[x] + 1)) * 100.0;
                string row = i.ToString();
                List<string> myDefinitionListData = tempExcel.GetRangeValue("A" + row, "D" + row);
                DefinitionList tempDefinitionList = new DefinitionList();
                tempDefinitionList.Name = myDefinitionListData[0];
                Thread.Sleep(1);
                worker.ReportProgress((int)percentage, String.Format("Processing " + tempDefinitionList.Name));
                tempDefinitionList.MainList = myDefinitionListData[1].Split('|').ToList(); ;
                tempDefinitionList.Description = myDefinitionListData[2].Split('|').ToList(); ;
                tempDefinitionList.SubList = myDefinitionListData[3].Split('|').ToList(); ;
                main.listDefinitionLists.Add(tempDefinitionList);
            }
            x++;
            #endregion

            #region Campaing Data
            mainLoadName = "Loading Campaign Settings...";
            tempExcel.SetSheet(sheets[x]);
            for (int i = 2; i < (itemCounts[x] + 2); i++)
            {
                double percentage = ((double)i / (double)8) * 100.0;
                string row = i.ToString();
                List<string> myCampaignData = tempExcel.GetRangeValue("A" + row, "B" + row);
                Campaigns tempCampaign = new Campaigns();
                tempCampaign.Setting = myCampaignData[0];
                Thread.Sleep(1);
                worker.ReportProgress((int)percentage, String.Format("Processing " + tempCampaign.Setting));
                tempCampaign.Image = "/DND4eCharacterGenerator;component/Assets/Images/Campaigns/" + myCampaignData[0] + ".png";
                tempCampaign.Shortdescription = myCampaignData[1];
                main.listCampaings.Add(tempCampaign);
            }
            x++;
            #endregion

            #region Role Data
            mainLoadName = "Loading Roles...";
            tempExcel.SetSheet(sheets[x]);
            for (int i = 2; i < (itemCounts[x] + 2); i++)
            {

                double percentage = ((double)i / (double)6) * 100.0;
                string row = i.ToString();
                List<string> myRoleData = tempExcel.GetRangeValue("A" + row, "C" + row);
                Roles tempRole = new Roles();
                tempRole.Role = myRoleData[0];
                Thread.Sleep(1);
                worker.ReportProgress((int)percentage, String.Format("Processing " + tempRole.Role));
                tempRole.Description = myRoleData[1];
                tempRole.Pick = myRoleData[2];
                main.listRoles.Add(tempRole);
            }
            x++;
            #endregion

            #region Class Data
            mainLoadName = "Loading Classes...";
            tempExcel.SetSheet(sheets[x]);
            for (int i = 2; i < (itemCounts[x] + 2); i++)
            {
                double percentage = ((double)i / (double)28) * 100.0;
                string row = i.ToString();
                List<string> myClassData = tempExcel.GetRangeValue("A" + row, "G" + row);
                Classes tempClass = new Classes();
                tempClass.Class = myClassData[0];
                Thread.Sleep(1);
                worker.ReportProgress((int)percentage, String.Format("Processing " + tempClass.Class));
                tempClass.Subclasses = myClassData[1].Split('|').ToList();
                tempClass.PrimaryRoles = myClassData[2];
                tempClass.SecondaryRoles = myClassData[3];
                tempClass.ShortDescription = myClassData[4];
                tempClass.Image = "/DND4eCharacterGenerator;component/Assets/Images/Classes/" + myClassData[0] + ".png";
                tempClass.PreferredRaces = myClassData[5].Split('|').ToList();
                main.listclassMain.Add(tempClass);                                
            }
            x++;
            #endregion

            #region Subclass Data
            mainLoadName = "Loading Subclasses...";
            tempExcel.SetSheet(sheets[x]);
            for (int i = 2; i < (itemCounts[x] + 2); i++)
            {
                double percentage = ((double)i / (double)54) * 100.0;
                string row = i.ToString();
                List<string> mySubclassData = tempExcel.GetRangeValue("A" + row, "BG" + row);
                SubClasses tempSubclass = new SubClasses();
                tempSubclass.SubClass = mySubclassData[0];
                Thread.Sleep(1);
                worker.ReportProgress((int)percentage, String.Format("Processing " + tempSubclass.SubClass));
                tempSubclass.Source = mySubclassData[1];
                tempSubclass.Power = mySubclassData[2];
                tempSubclass.Role = mySubclassData[3];
                tempSubclass.Abilities = mySubclassData[4].Split('|').ToList();
                tempSubclass.HPStart = Convert.ToInt16(mySubclassData[5]);
                tempSubclass.HPLvl = Convert.ToInt16(mySubclassData[6]);
                List<int> defints = new List<int>();
                defints.Add(Convert.ToInt16(mySubclassData[7]));
                defints.Add(Convert.ToInt16(mySubclassData[8]));
                defints.Add(Convert.ToInt16(mySubclassData[9]));
                tempSubclass.Defences = defints;
                tempSubclass.Attack = Convert.ToInt16(mySubclassData[10]);
                tempSubclass.Surges = Convert.ToInt16(mySubclassData[11]);
                List<bool> profints = new List<bool>();
                profints.Add(Convert.ToBoolean(mySubclassData[12]));
                profints.Add(Convert.ToBoolean(mySubclassData[13]));
                profints.Add(Convert.ToBoolean(mySubclassData[14]));
                profints.Add(Convert.ToBoolean(mySubclassData[15]));
                profints.Add(Convert.ToBoolean(mySubclassData[16]));
                profints.Add(Convert.ToBoolean(mySubclassData[17]));
                profints.Add(Convert.ToBoolean(mySubclassData[18]));
                profints.Add(Convert.ToBoolean(mySubclassData[19]));
                profints.Add(Convert.ToBoolean(mySubclassData[20]));
                profints.Add(Convert.ToBoolean(mySubclassData[21]));
                profints.Add(Convert.ToBoolean(mySubclassData[22]));
                profints.Add(Convert.ToBoolean(mySubclassData[23]));
                tempSubclass.Proficiencies = profints;
                tempSubclass.SkillTraining = Convert.ToInt16(mySubclassData[24]);
                List<int> skilints = new List<int>();
                skilints.Add(Convert.ToInt16(mySubclassData[25]));
                skilints.Add(Convert.ToInt16(mySubclassData[26]));
                skilints.Add(Convert.ToInt16(mySubclassData[27]));
                skilints.Add(Convert.ToInt16(mySubclassData[28]));
                skilints.Add(Convert.ToInt16(mySubclassData[29]));
                skilints.Add(Convert.ToInt16(mySubclassData[30]));
                skilints.Add(Convert.ToInt16(mySubclassData[31]));
                skilints.Add(Convert.ToInt16(mySubclassData[32]));
                skilints.Add(Convert.ToInt16(mySubclassData[33]));
                skilints.Add(Convert.ToInt16(mySubclassData[34]));
                skilints.Add(Convert.ToInt16(mySubclassData[35]));
                skilints.Add(Convert.ToInt16(mySubclassData[36]));
                skilints.Add(Convert.ToInt16(mySubclassData[37]));
                skilints.Add(Convert.ToInt16(mySubclassData[38]));
                skilints.Add(Convert.ToInt16(mySubclassData[39]));
                skilints.Add(Convert.ToInt16(mySubclassData[40]));
                skilints.Add(Convert.ToInt16(mySubclassData[41]));
                tempSubclass.Skills = skilints;
                tempSubclass.Paths = mySubclassData[42].Split('|').ToList();
                tempSubclass.DefaultFeat = mySubclassData[43];
                tempSubclass.Implements = mySubclassData[44].Split('|').ToList();
                tempSubclass.Special = mySubclassData[45];
                tempSubclass.Encounter = mySubclassData[46];
                tempSubclass.Feats = mySubclassData[47].Split('|').ToList();
                tempSubclass.Description = mySubclassData[48];
                tempSubclass.Builds = mySubclassData[49].Split('|').ToList();
                tempSubclass.Headers = mySubclassData[50].Split('|').ToList();
                tempSubclass.Bodies = mySubclassData[51].Split('|').ToList();
                List<SubClasses.OptionChoices> tempListChoices = new List<SubClasses.OptionChoices>();
                SubClasses.OptionChoices tempChoice1 = new SubClasses.OptionChoices();
                SubClasses.OptionChoices tempChoice2 = new SubClasses.OptionChoices();
                tempChoice1.OptionDetails = mySubclassData[52].Split('|').ToList();
                tempChoice1.Options = mySubclassData[53].Split('|').ToList();
                tempChoice1.OptionSelections = mySubclassData[54].Split('|').ToList();
                tempListChoices.Add(tempChoice1);
                tempChoice2.OptionDetails = mySubclassData[55].Split('|').ToList();
                tempChoice2.Options = mySubclassData[56].Split('|').ToList();
                tempChoice2.OptionSelections = mySubclassData[57].Split('|').ToList();                
                tempListChoices.Add(tempChoice2);
                tempSubclass.ListOptions = tempListChoices;
                tempSubclass.PP = Convert.ToBoolean(mySubclassData[58]);
                main.listSubClasses.Add(tempSubclass);
                foreach (Classes tempClass in main.listclassMain)
                {
                    if (tempClass.Subclasses[0] == tempSubclass.SubClass)
                        tempClass.Subclass = tempSubclass;
                }
            }
            x++;
            #endregion

            #region Build Data
            mainLoadName = "Loading Builds...";
            tempExcel.SetSheet(sheets[x]);
            for (int i = 2; i < (itemCounts[x] + 2); i++)
            {
                double percentage = ((double)i / (double)17) * 100.0;
                string row = i.ToString();
                List<string> myBuildData = tempExcel.GetRangeValue("A" + row, "J" + row);
                Builds tempBuild = new Builds();
                tempBuild.Build = myBuildData[0];
                Thread.Sleep(1);
                worker.ReportProgress((int)percentage, String.Format("Processing " + tempBuild.Build));
                tempBuild.Subclass = myBuildData[1];
                tempBuild.Description = myBuildData[2];
                tempBuild.Feat = myBuildData[3];
                tempBuild.HumanFeat = myBuildData[4];
                tempBuild.Skills = myBuildData[5].Split('|').ToList();
                tempBuild.Atwills = myBuildData[6].Split('|').ToList();
                tempBuild.Encounter = myBuildData[7];
                tempBuild.Daily = myBuildData[8];
                tempBuild.Option = myBuildData[9];
                main.listBuilds.Add(tempBuild);
            }
            x++;
            #endregion

            #region Deities Data
            mainLoadName = "Loading Deities...";
            tempExcel.SetSheet(sheets[x]);
            for (int i = 2; i < (itemCounts[x] + 2); i++)
            {
                double percentage = ((double)i / (double)86) * 100.0;
                string row = i.ToString();
                List<string> myDeityData = tempExcel.GetRangeValue("A" + row, "H" + row);
                Deities tempDeity = new Deities();
                tempDeity.Deity = myDeityData[0];
                Thread.Sleep(1);
                worker.ReportProgress((int)percentage, String.Format("Processing " + tempDeity.Deity));
                tempDeity.Setting = myDeityData[1];
                tempDeity.Image = "/DND4eCharacterGenerator;component/Assets/Images/Deities/" + myDeityData[0] + ".png";
                tempDeity.Domains = myDeityData[2].Split('|').ToList();
                tempDeity.Description = myDeityData[3];
                tempDeity.DomainDescriptions = myDeityData[4].Split('|').ToList();
                tempDeity.ShortDescription = myDeityData[5];
                tempDeity.Alignment = myDeityData[6];
                tempDeity.Laws = myDeityData[7].Split('|').ToList();
                main.listDeities.Add(tempDeity);
            }
            x++;
            #endregion

            #region Race Data
            mainLoadName = "Loading Races...";
            tempExcel.SetSheet(sheets[x]);
            for (int i = 2; i < (itemCounts[x] + 2); i++)
            {
                double percentage = ((double)i / (double)47) * 100.0;
                string row = i.ToString();
                List<string> myRaceData = tempExcel.GetRangeValue("A" + row, "AE" + row);
                Races tempRace = new Races();
                tempRace.Race = myRaceData[0];
                Thread.Sleep(1);
                worker.ReportProgress((int)percentage, String.Format("Processing " + tempRace.Race));
                tempRace.Size = myRaceData[1];
                tempRace.Speed = Convert.ToInt16(myRaceData[2]);
                tempRace.SpeedType = myRaceData[3];
                tempRace.Vision = myRaceData[4];
                tempRace.ShortDescription = myRaceData[5];
                tempRace.Description = myRaceData[6].Split('|').ToList();
                tempRace.HeightFeet = myRaceData[7];
                tempRace.HeightCM = myRaceData[8];
                tempRace.WeightLBS = myRaceData[9];
                tempRace.WeightKG = myRaceData[10];
                tempRace.Source = myRaceData[11];
                tempRace.Image = "/DND4eCharacterGenerator;component/Assets/Images/Races/" + myRaceData[0] +".PNG";
                tempRace.SubRaces = myRaceData[12].Split('|').ToList();
                tempRace.Traits = myRaceData[13].Split('|').ToList();
                tempRace.Abilities = myRaceData[14].Split('|').ToList();
                List<int> defints = new List<int>();
                defints.Add(Convert.ToInt16(myRaceData[15]));
                defints.Add(Convert.ToInt16(myRaceData[16]));
                defints.Add(Convert.ToInt16(myRaceData[17]));
                tempRace.Defences = defints;
                tempRace.Skills = myRaceData[18].Split('|').ToList();
                tempRace.Resistances = myRaceData[19].Split('|').ToList();
                tempRace.Powers = myRaceData[20].Split('|').ToList();
                tempRace.Languages = myRaceData[21].Split('|').ToList();
                tempRace.Feats = myRaceData[22].Split('|').ToList();
                tempRace.Headers = myRaceData[23].Split('|').ToList();
                tempRace.Bodies = myRaceData[24].Split('|').ToList();
                tempRace.Physical = myRaceData[25];
                tempRace.Playing = myRaceData[26];
                tempRace.Adventure = myRaceData[27];
                tempRace.MaleNames = myRaceData[28].Split('|').ToList();
                tempRace.FemaleNames = myRaceData[29].Split('|').ToList();
                tempRace.Age = myRaceData[30];
                main.listRaces.Add(tempRace);
            }
            x++;
            #endregion

            #region Language Data
            mainLoadName = "Loading Languages...";
            tempExcel.SetSheet(sheets[x]);
            //Languages data
            for (int i = 2; i < (itemCounts[x] + 2); i++)
            {
                double percentage = ((double)i / (double)22) * 100.0;
                string row = i.ToString();
                List<string> myLanguageData = tempExcel.GetRangeValue("A" + row, "C" + row);
                Languages tempLanguage = new Languages();
                tempLanguage.Language = myLanguageData[0];
                Thread.Sleep(1);
                worker.ReportProgress((int)percentage, String.Format("Processing " + tempLanguage.Language));
                tempLanguage.Setting = myLanguageData[1];
                tempLanguage.Description = myLanguageData[2];
                tempLanguage.Image = "/DND4eCharacterGenerator;component/Assets/Images/Languages/" + myLanguageData[0] + ".png";
                main.listLanguages.Add(tempLanguage);
            }
            x++;
            #endregion
            tempExcel.Close();
            mainLoadName = "Loading Complete!";
        }        

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
    }
}