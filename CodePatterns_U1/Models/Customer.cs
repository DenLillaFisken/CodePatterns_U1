using CodePatterns_U1.Interfaces;
using CodePatterns_U1.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodePatterns_U1.Models
{
    public class Customer : ICustomer
    {
        public string Name { get; set; }
        public long PhoneNumber { get; set; }
        public string Email { get; set; }
        public List<IAnimal> Animals { get; set; }

        //Registersra en kund
        public void RegisterCustomer(ICustomer cust, List<ICustomer> custlist)
        {
            var validation = Factory.Validate();

            Console.WriteLine("Ange namn: ");
            cust.Name = Console.ReadLine();

            Console.WriteLine("Ange telefonnummer: ");
            string phoneNumber = Console.ReadLine();
            //Validera telefonnr
            if (validation.ValidatePhoneNumber(phoneNumber))
            {
                cust.PhoneNumber = Convert.ToInt64(phoneNumber);
                Console.WriteLine("Ange mailadress: ");
                cust.Email = Console.ReadLine();

                //Lägg till i lista/spara i "db"
                custlist.Add(cust);

                Console.WriteLine($"{cust.Name} är nu registrerad.");
            }
            else
            {
                Console.WriteLine("Felaktigt telefonnummer!");
                RegisterCustomer(cust, custlist);
            } 
        }

        //Kontrollera om kunden/ägaren är registrerad
        bool ICustomer.SeeIfOwnerExists(string customer, List<ICustomer> custList)
        {
            foreach (ICustomer cust in custList)
            {
                if (cust.Name == customer)
                {
                    return true;
                }
            }
            return false;
        }
        //Hämtar en specifik kund baserat på namn
        public ICustomer GetCustomer(string name, List<ICustomer> custList)
        {
            foreach (ICustomer cust in custList)
            {
                if (cust.Name == name)
                {
                    return cust;
                }
            }
            return null;
        }
    }
}
