using CodePatterns_U1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodePatterns_U1.Services
{
    public class ValidationService : IValidation
    {
        //Försök konvertera till en int, kontrollera sedan att siffran är mellan 1 och 9.
        public bool ValidateMenuChoise(string input)
        {
            try
            {
                int convertedInput = Convert.ToInt32(input);
                if(convertedInput <= 9 && convertedInput >= 1)
                {
                    return true;
                }
            }
            catch { }
            return false;
        }

        //Telefonnr måste vara siffror. Mellan 5 och 15 siffror långt
        bool IValidation.ValidatePhoneNumber(string input)
        {
            try
            {
                long convertedInput = Convert.ToInt64(input);
                
                if (input.Length >= 5 && input.Length <= 15)
                {
                    return true;
                }
            }
            catch { }
            return false;
        }
    }
}
