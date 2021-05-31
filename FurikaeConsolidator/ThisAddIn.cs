using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Excel = Microsoft.Office.Interop.Excel;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Tools.Excel;
using Microsoft.Office.Tools;
using System.Windows.Forms;
using FurikaeConsolidator.ViewModels;
using System.Diagnostics;
using System.IO;

namespace FurikaeConsolidator
{
    public partial class ThisAddIn
    {
        private MyTaskPaneContent content;
        private CustomTaskPane myTaskPane;
        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            #region InitializeDebugFeatures
            string logName = DateTime.Now.ToString("yyyyMMdd_HHmmss") + "_furikae.log";
            Debug.Listeners.Add(new TextWriterTraceListener(logName));

            

            #endregion
            content = new MyTaskPaneContent();
            myTaskPane = CustomTaskPanes.Add(content, "My Task Pane");
            myTaskPane.DockPosition = Office.MsoCTPDockPosition.msoCTPDockPositionRight;
            myTaskPane.Width = 455;

            myTaskPane.Visible = false;
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
        }

        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }
        
        #endregion
    }
}
