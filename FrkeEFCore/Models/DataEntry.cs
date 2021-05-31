using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FrkeEFCore.Models
{
    public class DataEntry
    {
        [Key]
        public long EntryID { get; set; }

        [Required, 
        MaxLength(ErrorMessage = "Key length should not exceed 12.")]
        public string Key { get; set; }

        [Column(Order = 0, TypeName = "decimal(10, 2)")]
        public decimal Jan { get; set; }
        [Column(Order = 1, TypeName = "decimal(10, 2)")]
        public decimal Feb { get; set; }
        [Column(Order = 2, TypeName = "decimal(10, 2)")]
        public decimal Mar { get; set; }
        [Column(Order = 3, TypeName = "decimal(10, 2)")]
        public decimal Apr { get; set; }
        [Column(Order = 4, TypeName = "decimal(10, 2)")]
        public decimal May { get; set; }
        [Column(Order = 5, TypeName = "decimal(10, 2)")]
        public decimal Jun { get; set; }
        [Column(Order = 6, TypeName = "decimal(10, 2)")]
        public decimal Jul { get; set; }
        [Column(Order = 7, TypeName = "decimal(10, 2)")]
        public decimal Aug { get; set; }
        [Column(Order = 8, TypeName = "decimal(10, 2)")]
        public decimal Sep { get; set; }
        [Column(Order = 9, TypeName = "decimal(10, 2)")]
        public decimal Oct { get; set; }
        [Column(Order = 10, TypeName = "decimal(10, 2)")]
        public decimal Nov { get; set; }
        [Column(Order = 10, TypeName = "decimal(10, 2)")]
        public decimal Dec { get; set; }

        [NotMapped]
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
