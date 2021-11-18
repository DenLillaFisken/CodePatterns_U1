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
        public static void ShowAnimals(List<IAnimal> animallist)
        {
            foreach (IAnimal a in animallist)
            {
                Console.WriteLine(a.AnimalName);
            }
        }
        public static void ShowCustomers(List<ICustomer> custlist)
        {
            foreach (ICustomer cust in custlist)
            {
                Console.WriteLine(cust.Name);
            }
        }
        public static void ShowCheckedInAnimals(List<IAnimal> animallist, List<ICustomer> custlist)
        {
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
                ShowAnimalsWithOwners(newList, custlist);
            }
            else
            {
                Console.WriteLine("Det finns inga incheckade djur just nu.");
            }
                
        }
        public static void ShowAnimalsWithOwners(List<IAnimal> animallist, List<ICustomer> custlist)
        {
            foreach (IAnimal a in animallist)
            {
                foreach (ICustomer cust in custlist)
                {
                    if (a.Owner == cust.Name)
                    {
                        Console.WriteLine($"Djur: {a.AnimalName}, Ägare: {cust.Name} {cust.PhoneNumber} {cust.Email}");
                    }
                }
            }
        }
    }
}
