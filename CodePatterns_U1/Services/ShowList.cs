using CodePatterns_U1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodePatterns_U1.Services
{
    public class ShowList
    {
        public static void ShowAnimals(List<IAnimal> animallist, bool showWithOwner)
        {
            var output = Factory.CreateOutputService();

            foreach (IAnimal a in animallist)
            {
                if (showWithOwner == true)
                {
                    output.ShowOutput($"Djur: {a.AnimalName}, Ägare: {a.Owner.Name} {a.Owner.PhoneNumber} {a.Owner.Email}");
                }
                else
                {
                    output.ShowOutput($"Animal name: {a.AnimalName}");
                }  
            }
        }
        public static void ShowCustomers(List<ICustomer> custlist)
        {
            var output = Factory.CreateOutputService();

            foreach (ICustomer cust in custlist)
            {
                output.ShowOutput($"Name: {cust.Name}, phonenumber: {cust.PhoneNumber}, email: {cust.Email}");
            }
        }
        public static void ShowCheckedInAnimals(List<IAnimal> animallist, List<ICustomer> custlist)
        {
            var output = Factory.CreateOutputService();

            List<IAnimal> newList = new List<IAnimal>();
            foreach (IAnimal a in animallist)
            {
                if (a.IsCheckedIn == true)
                {
                    newList.Add(a);
                }
            }
            if (newList.Count != 0)
            {
                ShowAnimals(newList, true);
            }
            else
            {
                output.ShowOutput("Det finns inga incheckade djur just nu.");
            }
                
        }
    }
}
