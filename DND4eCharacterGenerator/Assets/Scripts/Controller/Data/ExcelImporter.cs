using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DnD4e.Assets.Scripts.Controller.Data
{
    public class ExcelImporter
    {
        public int firstTime = 0;
        public static Microsoft.Office.Interop.Excel.Application excelApplication = new Microsoft.Office.Interop.Excel.Application();
        public static Microsoft.Office.Interop.Excel._Workbook excelWorkbook;
        public static Microsoft.Office.Interop.Excel.Worksheet currentSheet;
        string tempPath;

        public void Create()
        {
            tempPath = System.IO.Path.GetTempFileName();
            System.IO.File.WriteAllBytes(tempPath, Properties.Resources.ScrapeData);
            excelWorkbook = excelApplication.Workbooks.Open(tempPath);
            excelApplication.Visible = false;
        }

        public void SetSheet(string sheet)
        {
            currentSheet = excelWorkbook.Sheets[sheet];
        }

        public void Close()
        {
            excelWorkbook.Close(false, Missing.Value, Missing.Value);
            excelApplication.Quit();
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

        public string GetCellValue(int row, int column)
        {

            string currentValue = currentSheet.Cells[row, column].Value2.ToString();
            return currentValue;
        }

        public List<string> GetRangeValue(string rangeStart, string rangeEnd)
        {
            Microsoft.Office.Interop.Excel.Range currentRange = currentSheet.get_Range(rangeStart, rangeEnd);
            Object arr = currentRange.Value;
            List<string> myValues = new List<string>();
            foreach (object s in (Array)arr)
            {
                myValues.Add(Convert.ToString(s));
            }
            return myValues;
        }

        public List<int> GetRangeValueInt(string rangeStart, string rangeEnd)
        {
            Microsoft.Office.Interop.Excel.Range currentRange = currentSheet.get_Range(rangeStart, rangeEnd);
            Object arr = currentRange.Value;
            List<int> myValues = new List<int>();
            foreach (object s in (Array)arr)
            {
                if (IsNumber(s))
                {
                    myValues.Add(Convert.ToInt32(Convert.ToString(s)));
                }
                else
                {
                    myValues.Add(0);
                }
            }
            return myValues;
        }
    }
}
