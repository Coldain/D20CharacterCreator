using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD4e.Assets.Scripts.Model
{
    class Experience_Manager
    {
        #region Properties
        #endregion

        #region Constructors
        public Experience_Manager()
        {
        }
        #endregion

        #region Methods
        public void LevelSelect(int desiredLevel)
        {

        }

        public void ExperienceSelect()
        {

        }
         
        public int SetLevel(int level)
        {
            switch (level)
            {
                case 2:
                    return 1000;
                case 3:
                    return 2250;
                case 4:
                    return 3750;
                case 5:
                    return 5500;
                case 6:
                    return 7500;                 
                case 7:
                    return 10000;
                case 8:
                    return 13000;
                case 9:
                    return 16500;
                case 10:
                    return 20500;
                case 11:
                    return 26000;
                case 12:
                    return 32000;
                case 13:
                    return 39000;
                case 14:
                    return 47000;
                case 15:
                    return 57000;
                case 16:
                    return 69000;
                case 17:
                    return 83000;
                case 18:
                    return 99000;
                case 19:
                    return 119000;
                case 20:
                    return 143000;
                case 21:
                    return 175000;
                case 22:
                    return 210000;
                case 23:
                    return 255000;
                case 24:
                    return 310000;
                case 25:
                    return 375000;
                case 26:
                    return 450000;
                case 27:
                    return 550000;
                case 28:
                    return 675000;
                case 29:
                    return 825000;
                case 30:
                    return 1000000;
                default:
                    return 0;
            }
        }

        public void CheckLevel(int tempExperience)
        {
            int tempLevel = 1;
            int[] requiredExperience = { 1000, 2250, 3750 };
            foreach (int value in requiredExperience)
            {
                if (tempExperience >= requiredExperience[value] && tempExperience < requiredExperience[value + 1])
                {
                    tempLevel = requiredExperience[value];
                }
                else if (tempExperience < requiredExperience[0])
                {
                    tempLevel = 1;
                }
                else if (tempExperience > requiredExperience[requiredExperience.Length - 1])
                {
                    tempLevel = 30;
                }
            }

            //if (tempLevel != currentCharacter.Level)
            //{
            //    currentCharacter.Level = tempLevel;
            //}
        }

        #endregion
    }
}
