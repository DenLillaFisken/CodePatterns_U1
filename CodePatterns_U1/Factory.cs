using CodePatterns_U1.Interfaces;
using CodePatterns_U1.Models;
using CodePatterns_U1.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodePatterns_U1
{
    public class Factory
    {
        public static ICustomer CreateCustomer()
        {
            return new Customer();
        }
        public static IAnimal CreateAnimal()
        {
            return new Animal();
        }
        public static IExtraService CreateExtraService()
        {
            return new ExtraService();
        }
        public static IReceipt CreateReceipt()
        {
            return new Receipt();
        }

        public static IMenu ShowMenu()
        {
            return new MenuService();
        }
        public static IValidation Validate()
        {
            return new ValidationService();
        }
    }
}
