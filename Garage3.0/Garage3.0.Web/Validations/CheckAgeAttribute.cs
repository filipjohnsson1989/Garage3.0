using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Garage3._0.Web.Validations
{
    public class CheckAgeAttribute : ValidationAttribute
    {
        private readonly string min;
        public CheckAgeAttribute(string min)
        {
            this.min = min;
        }

        public override bool IsValid(object? value)
        {
            if (value is string personNr)
            {
                //Personnummer.Valid("191212121212");     // => True
                //Personnummer.Valid("121212+1212")       // => True
                //Personnummer.Valid("20121212-1212")     // => True

                string[] dateValues = { "191212121212", "121212+1212",
                              "20121212-1212"};
                string pattern = "MM-dd-yy";
                DateTime parsedDate;
                foreach (var dateValue in dateValues)
                {
                    if (DateTime.TryParseExact(dateValue, pattern, null,
                                              DateTimeStyles.None, out parsedDate))
                        Console.WriteLine("Converted '{0}' to {1:d}.",
                                          dateValue, parsedDate);
                    else
                        Console.WriteLine("Unable to convert '{0}' to a date and time.",
                                          dateValue);
                }


                //var date = personNr.Split('-');
                //var age = DateTime.TryParseExact(date);



            }
            return false;
        }

    }
}


