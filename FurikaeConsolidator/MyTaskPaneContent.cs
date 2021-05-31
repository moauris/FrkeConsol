using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FurikaeConsolidator.ViewModels;
using Excel = Microsoft.Office.Interop.Excel;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Tools.Excel;
using Microsoft.Office.Tools;
using Microsoft.Office.Interop.Excel;
using System.Diagnostics;

namespace FurikaeConsolidator
{
    public partial class MyTaskPaneContent : UserControl
    {
        public MyTaskPaneContent()
        {
            InitializeComponent();
            btn_StartSync.Enabled = false;
        }

        public LinkLabel lk { get => linkLabel6; }


        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Excel.Application app = Globals.ThisAddIn.Application;
            Excel.Workbooks wbks = app.Workbooks;
            Excel.Workbook wbk = wbks.Item[1];
            if (wbk == null)
            {
                MessageBox.Show("Workbook is null");
                return;
            }

            Excel._Worksheet ws = (Excel._Worksheet)wbk.ActiveSheet;
            ws.CheckIfInitial();
            ws.CheckIfInterlockUnified();
            linkLabel6.Text = "Started Event Handling";
            wbk.SheetActivate += MyTaskPaneContent_SheetActive;
        }

        private Color originalBackground;
        private Color highLightBackground = Color.Blue;

        private Color originalFont;
        private Color highLightFont = Color.White;


        private void MyTaskPaneContent_SheetActive(object Sh)
        {
            Excel._Worksheet sheet = (Excel._Worksheet)Sh;
            System.Windows.Forms.Label[] labels = new System.Windows.Forms.Label[]
            {
                label3, label4, label5, label6, label7
            };

            if (originalBackground == null || originalFont == null)
            {
                originalBackground = label3.BackColor;
                originalFont = label3.ForeColor;
            }

            if (sheet.CheckIfInitial())
            {
                Debug.Print("HL Sheet 1");
                HightlightLabels(labels, 0);
                btn_StartSync.Enabled = true;
                shtInitialData = Sh as _Worksheet;
            }
            else if (sheet.CheckIfInterlockUnified())
            {

                Debug.Print("HL Sheet 2");
                HightlightLabels(labels, 1);

                btn_StartSync.Enabled = false;
            }
            else
            {
                Debug.Print("HL No Sheet");
                HightlightLabels(labels);

                btn_StartSync.Enabled = false;
            }
        }

        private _Worksheet shtInitialData;

        /// <summary>
        /// Highlight the index specified label of an array of labels
        /// </summary>
        /// <param name="index">Zero-based label index</param>
        /// <param name="labels">Target collection of labels</param>
        private void HightlightLabels(System.Windows.Forms.Label[] labels, int index = -1)
        {
            for (int i = 0; i < labels.Length; i++)
            {
                labels[i].BackColor = i == index ? highLightBackground : originalBackground;
                labels[i].ForeColor = i == index ? highLightFont : originalFont;
            }
        }

        private void btn_StartSync_Click(object sender, EventArgs e)
        {
            //Sync AV as Key
            //Sync U:AF as monthes
            Excel.Range rng = shtInitialData.Range["AV5"];

            while (rng.Value as string != "")
            {
                Debug.Print($"The key is {rng.Value}");



                rng = rng.Offset[1, 0];
            }

        }
    }
}
