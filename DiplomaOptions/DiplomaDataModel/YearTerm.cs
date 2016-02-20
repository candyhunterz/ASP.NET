using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaDataModel
{
    public class YearTerm
    {

        [Key]
        [DisplayName("Year Term")]
        public int YearTermId { get; set; }
        public int Year { get; set; }
        [RegularExpression(@"[1-3]0")]
        public int Term { get; set; }
        public bool isDefault { get; set; }
    }
}
