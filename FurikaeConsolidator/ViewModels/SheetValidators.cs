using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Tools.Excel;
using Microsoft.Office.Tools;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;

namespace FurikaeConsolidator.ViewModels
{
    public static class SheetValidators
    {
        private const string InitialTemplate = @"No.D = 削除/無効SLO用備考欄Service LineSLO Notes IDSLO Delegate Notes ID - 1SLO Delegate Notes ID - 2Rated/SharedProject CodeRated/Shared Svc Name (14文字以内)　Cost Driver NameDriver UnitsRate (JPY)Short DescriptionTypeProject CodeWork# (Oxxxx0)DPE Notes IDDPE Delagate Notes ID - 1DPE Delagate Notes ID - 2JanFebMarAprMayJunJulAugSepOctNovDecFYJanFebMarAprMayJunJulAugSepOctNovDecFYKeyLENB";

        private const string InitialUnifiedTemplate = @"No.D = 削除/無効SLO用備考欄Service LineSLO Notes IDSLO Delegate Notes ID - 1SLO Delegate Notes ID - 2Rated/SharedProject CodeRated/Shared Svc Name (14文字以内)　Cost Driver NameDriver UnitsRate (JPY)Short DescriptionTypeProject CodeWork# (Oxxxx0)DPE Notes IDDPE Delagate Notes ID - 1DPE Delagate Notes ID - 2JanFebMarAprMayJunJulAugSepOctNovDecFYJanFebMarAprMayJunJulAugSepOctNovDecFYKeyLENB";
        /// <summary>
        /// Checks if a worksheet is a valid Interlock Initial Data
        /// </summary>
        /// <param name="sheet"></param>
        /// <returns></returns>
        public static bool CheckIfInitial(this Excel._Worksheet sheet)
        {
            
            object[,] forms = sheet.Range["A4:AW4"].FormulaR1C1;
            Debug.Print("Checking if Sheet is Initial");

            bool templateMatch = forms.TwoDStringSerializer() == InitialTemplate;
            Debug.Print($"templateMatch: {templateMatch}");
            bool validSheetName = sheet.Name.Contains("Interlock Initial Data");

            Debug.Print($"validSheetName: {validSheetName}");

            Debug.Flush();
            return validSheetName && templateMatch;
        }
        public static bool CheckIfInterlockUnified(this Excel._Worksheet sheet)
        {
            object[,] forms = sheet.Range["A5:AW5"].FormulaR1C1;
            return forms.TwoDStringSerializer() == InitialUnifiedTemplate && sheet.Name.Contains("Interlock Data(統合スキーム)");
        }

        private static void WriteToFile(this Excel._Worksheet sheet)
        {
            object[,] forms = sheet.Range["A1:AW4"].FormulaR1C1;

            using (var sw = new StreamWriter("1234temp.txt", false, Encoding.UTF8))
            {
                sw.WriteLine(forms.TwoDStringSerializer());
                FileStream fs = sw.BaseStream as FileStream;
                MessageBox.Show("written to " + fs.Name);

            }
        }



        public static object[,] GetAtoAWRange(this Excel._Worksheet sheet, int rowStart, int rowEnd)
        {
            string address = $"A{rowStart}:AW{rowEnd}";
            object[,] forms = sheet.Range[address].FormulaR1C1;

            return forms;
        }

        public static string TwoDStringSerializer(this object[,] arry)
        {
            StringBuilder sb = new StringBuilder();
            foreach (object obj in arry)
            {
                sb.Append(obj.ToString());
            }
            return sb.ToString();
        }
    }
}
