using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text.RegularExpressions;

    //https://stackoverflow.com/questions/32624800/swedish-ssn-regular-expression-reject-users-under-a-specific-age
namespace Garage3._0.Web.Validations;

public class CheckAgeAttribute : ValidationAttribute
{
    public bool IsOfAge(DateTime birthdate)
    {
        DateTime today = DateTime.Today;
        int minAge = -18;
        if (birthdate < today.AddYears(minAge))
            return true;
        else
            return false;
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        string RegExForValidation = @"^(?<date>\d{6}|\d{8})[-\s]?\d{4}$";
        string date = Regex.Match((string)value, RegExForValidation).Groups["date"].Value;
        DateTime dt;
        if (DateTime.TryParseExact(date, new[] { "yyMMdd", "yyyyMMdd" }, CultureInfo.InvariantCulture, DateTimeStyles.None, out dt))
        {
            if (IsOfAge(dt))
                return ValidationResult.Success;
            else
                return new ValidationResult("18 Years old at least");
        }
        return new ValidationResult("PersonNr is indicated by 10 eller 12 digits (yymmddnnnn eller yyyymmddnnnn)");
    }
}
