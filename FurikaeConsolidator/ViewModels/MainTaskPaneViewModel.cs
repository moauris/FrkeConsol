using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurikaeConsolidator.ViewModels
{
    public class MainTaskPaneViewModel
    {
        public MainTaskPaneViewModel()
        {

        }

        private bool _canStartSync;

        public bool CanStartSync
        {
            get { return _canStartSync; }
            set { _canStartSync = value; }
        }

        private _Worksheet _interlockInitial;

        public _Worksheet InterlockInitial
        {
            get { return _interlockInitial; }
            set { _interlockInitial = value; }
        }


    }
}
