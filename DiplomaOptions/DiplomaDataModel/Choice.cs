using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaDataModel
{
    [UniqueChoice]
    public class Choice
    {
        [Key]
        public int ChoiceId { get; set; }

        [ForeignKey("YearTerm")]
        public int? YearTermId { get; set; }

        [ForeignKey("YearTermId")]
        public virtual YearTerm YearTerm { get; set; }

        [MaxLength(9)]
        [RegularExpression(@"(A00)[1-9]{6}", ErrorMessage = "Invalid Student ID")]
        [DisplayName("Student ID")]
        public string StudentId { get; set; }

        [MaxLength(40)]
        [Required(ErrorMessage = "First name is required")]
        [DisplayName("First Name")]
        public string StudentFirstName { get; set; }

        [MaxLength(40)]
        [Required(ErrorMessage = "Last name is required")]
        [DisplayName("Last Name")]
        public string StudentLastName { get; set; }

        [Column(Order = 0)]
        [UIHint("OptionDropDown")]
        [ForeignKey("FirstOption")]
        [DisplayName("1st Choice")]
        public int? FirstChoiceOptionId { get; set; }
        [ForeignKey("FirstChoiceOptionId")]
        public virtual Option FirstOption { get; set; }


        [Column(Order = 1)]
        [UIHint("OptionDropDown")]
        [ForeignKey("SecondOption")]
        [DisplayName("2nd Choice")]
        public int? SecondChoiceOptionId { get; set; }
        [ForeignKey("SecondChoiceOptionId")]
        public virtual Option SecondOption { get; set; }


        [Column(Order = 2)]
        [UIHint("OptionDropDown")]
        [ForeignKey("ThirdOption")]
        [DisplayName("3rd Choice")]
        public int? ThirdChoiceOptionId { get; set; }
        [ForeignKey("ThirdChoiceOptionId")]
        public virtual Option ThirdOption { get; set; }

        [Column(Order = 3)]
        [UIHint("OptionDropDown")]
        [ForeignKey("FourthOption")]
        [DisplayName("4th Choice")]
        public int? FourthChoiceOptionId { get; set; }
        [ForeignKey("FourthChoiceOptionId")]
        public virtual Option FourthOption { get; set; }

        private DateTime _SelectionDate = DateTime.MinValue;

        [ScaffoldColumn(false)]
        [DataType(DataType.DateTime)]
        [DisplayName("Selection Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime SelectionDate
        {
            get
            {
                return (_SelectionDate == DateTime.MinValue) ? DateTime.Now : _SelectionDate;
            }
            set { _SelectionDate = value; }
        }
    }
}

