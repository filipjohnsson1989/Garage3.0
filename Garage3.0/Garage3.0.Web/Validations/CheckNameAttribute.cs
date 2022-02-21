using Garage3._0.Web.Models.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace Garage3._0.Web.Validations
{
    public class CheckNameAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            const string errorMessage = "First and last name has to be different.";

            if (value is string input)
            {
                var model = validationContext.ObjectInstance as MemberCreateViewModel;

                if (model != null)
                {
                    if (input != model.FirstName)
                        return ValidationResult.Success;
                    else
                        return new ValidationResult(errorMessage);
                }
            }
            return new ValidationResult(errorMessage);
        }
    }
}
