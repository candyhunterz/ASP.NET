using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaDataModel
{
    public class UniqueChoice : ValidationAttribute
    {
        HashSet<int> choices;

        public UniqueChoice()
        {
            choices = new HashSet<int>();
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                var choicesList = new[] { value.GetType().GetProperty("FirstChoiceOptionId").GetValue(value)
                        , value.GetType().GetProperty("SecondChoiceOptionId").GetValue(value)
                        , value.GetType().GetProperty("ThirdChoiceOptionId").GetValue(value)
                        , value.GetType().GetProperty("FourthChoiceOptionId").GetValue(value)
                };
               
                for (int i = 0; i < choicesList.Length; i++)
                {
                    if (choices.Contains((int)choicesList[i]))
                    {
                        choices.Clear();
                        return new ValidationResult("Cannot select duplicate options");
                    }
                    choices.Add((int)choicesList[i]);
                }
            }
            choices.Clear();
            return ValidationResult.Success;
        }
    }
}
