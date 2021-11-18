using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodePatterns_U1.Interfaces
{
    public interface IValidation
    {
        bool ValidateMenuChoise(string input);
        bool ValidatePhoneNumber(string input);
    }
}
