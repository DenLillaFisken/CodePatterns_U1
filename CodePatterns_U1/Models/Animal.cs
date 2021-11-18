using CodePatterns_U1.Interfaces;
using CodePatterns_U1.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodePatterns_U1.Models
{
    public class Animal : IAnimal
    {
        public string AnimalName { get; set; }
        public string Owner { get; set; }
        public bool IsCheckedIn { get; set; }

        //Kontrollera om det inskrivna djuret existerar i "db".
        public bool CheckAnimalExists(string animalName, List<IAnimal> animalList)
        {
            foreach (IAnimal a in animalList)
            {
                if (a.AnimalName == animalName)
                {
                    return true;
                }
            }
            return false;
        }

        //Ändrar status på ett djur till incheckad
        public void CheckInAnimal(List<IAnimal> animallist)
        { 
            Console.WriteLine("Ange djurets namn: ");
            string animalName = Console.ReadLine();

            //Kontrollera att djuret faktiskt finns registrerat
            if (CheckAnimalExists(animalName, animallist))
            {
                foreach (IAnimal a in animallist)
                {
                    if (a.AnimalName == animalName)
                    {
                        a.IsCheckedIn = true;
                        Console.WriteLine($"Du har checkat in {animalName}");
                    }
                }
            }
            else
            {
                Console.WriteLine("Djuret du angivit finns inte registrerat. Försök med ett annat namn eller registrera djuret.");
            }  
        }

        //Skriv in djurets namn och hämta/ändra info ur lista samt skapa kvitto
        public void CheckOutAnimal(List<IAnimal> animallist, List<IReceipt> receiptlist)
        {
            
            Console.WriteLine("Ange djurets namn: ");
            string animalName = Console.ReadLine();

            if (CheckAnimalExists(animalName, animallist))
            {
                //Status sätts till utcheckad (false)
                foreach (IAnimal a in animallist)
                {
                    if (a.AnimalName == animalName)
                    {
                        a.IsCheckedIn = false;

                        //Skicka kvitto
                        var createReceipt = Factory.CreateReceipt();
                        createReceipt.ShowReceipt(receiptlist, animalName);
                    }
                }
            }
            else
            {
                Console.WriteLine("Djuret du angivit finns inte registrerat. Försök med ett annat namn eller registrera djuret.");
            }
        }

        //Hämtar ett specifikt djur baserat på namn
        public IAnimal GetAnimal(string animalName, List<IAnimal> animalList)
        {
            foreach (IAnimal a in animalList)
            {
                if (animalName == a.AnimalName)
                {
                    return a;
                }
            }
            return null;
        }

        //Registrerar ett djur och kontrollerar att Ägare finns i listan redan.
        public void RegisterAnimal(IAnimal animal, List<IAnimal> animallist, List<ICustomer> custlist)
        {
            var custValidation = Factory.CreateCustomer();

            Console.WriteLine("Ange djurets namn: ");
            animal.AnimalName = Console.ReadLine();

            Console.WriteLine("Ange djurets Ägare: ");
            string owner = Console.ReadLine();

            //Kontrollera att kunden/ägaren finns i "db"
            if (custValidation.SeeIfOwnerExists(owner, custlist))
            {
                animal.Owner = owner;
                animallist.Add(animal);
            }
            else
            {
                Console.WriteLine("Ägaren existerar inte. Vänligen registrera ägare först!");
            }       
        }      
    }
}
