using CodePatterns_U1.Interfaces;
using CodePatterns_U1.Models;
using System;
using System.Collections.Generic;

namespace CodePatterns_U1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Mock-data
            List<ICustomer> customerList = new List<ICustomer>
            {
                new Customer {Name="Oskar", PhoneNumber=123, Email="oskar@oskar.se"},
                new Customer {Name="Lena", PhoneNumber=123, Email="lena@lena.se"},
                new Customer {Name="Ronja", PhoneNumber=123, Email="ronja@ronja.se"},
            };
            List<IAnimal> animalList = new List<IAnimal>
            {
               new Animal {AnimalName="Tuss", Owner="Oskar", IsCheckedIn=false },
               new Animal {AnimalName="Sune", Owner="Lena", IsCheckedIn=false },
               new Animal {AnimalName="Rufus", Owner="Ronja", IsCheckedIn=false },
               new Animal {AnimalName="Poppy", Owner="Lena", IsCheckedIn=false },
            };
            List<IExtraService> extraservicesList = new List<IExtraService>
            {
                new ExtraService {Name="Kloklippning", Price=100, Description="Vi klipper klorna på ditt djur."},
                new ExtraService {Name="Tvätt", Price=200, Description="Vi tvättar ditt djur."}
            };
            List<IReceipt> receiptsList = new List<IReceipt> { };

            //Öppnar menyn och skickar med all mockdata som motsvarar en "databas"
            IMenu menu = Factory.ShowMenu();
            menu.ChooseMenuAlternative(customerList, animalList, extraservicesList, receiptsList);
        }
    }
}
