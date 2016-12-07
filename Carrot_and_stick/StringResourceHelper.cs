using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carrot_and_stick
{
    public static class StringResourceHelper
    {
        public static string CapitalizeFirstLetter(string toCapitalize)
        {
            if (string.IsNullOrWhiteSpace(toCapitalize))
            {
                return toCapitalize;
            }

            char[] letters = toCapitalize.ToCharArray();
            letters[0] = char.ToUpper(letters[0]);
            return new string(letters);
        }
    }
}
