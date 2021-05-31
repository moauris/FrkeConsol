using System;
using System.Collections.Generic;
using System.Text;

namespace FrkeEFCore.Models
{
    public class DataEntry
    {
        
        public long EntryID { get; set; }

        public string Key { get; set; }

        public decimal Jan { get; set; }
        public decimal Feb { get; set; }
        public decimal Mar { get; set; }
        public decimal Apr { get; set; }
        public decimal May { get; set; }
        public decimal Jun { get; set; }
        public decimal Jul { get; set; }
        public decimal Aug { get; set; }
        public decimal Sep { get; set; }
        public decimal Oct { get; set; }
        public decimal Nov { get; set; }
        public decimal Dec { get; set; }

        public decimal this[int index]
        {
            get
            {
                switch (index)
                {
                    case 1: return Jan;
                    case 2: return Feb;
                    case 3: return Mar;
                    case 4: return Apr;
                    case 5: return May;
                    case 6: return Jun;
                    case 7: return Jul;
                    case 8: return Aug;
                    case 9: return Sep;
                    case 10: return Oct;
                    case 11: return Nov;
                    case 12: return Dec;
                    default:
                        return default(decimal);
                }
            }
        }
    }
}
