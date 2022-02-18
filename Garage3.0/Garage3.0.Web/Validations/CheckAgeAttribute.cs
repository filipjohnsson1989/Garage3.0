using System.ComponentModel.DataAnnotations;

namespace Garage3._0.Web.Validations
{
    public class CheckAgeAttribute : ValidationAttribute
    {
        private readonly int nr;
        public CheckAgeAttribute(int nr)
        {
            this.nr = nr;
        }

        public override bool IsValid(object? value)
        {
            if (value is int input)
            {
                var num = input;

                return num >= nr;
            }
            return false;
        }

    }
}
