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
        public ICustomer Owner { get; set; }
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
        public void CheckInAnimal(List<IAnimal> animallist, List<IReceipt> receiptList)
        {
            var output = Factory.CreateOutputService();
            var input = Factory.CreateInputService();

            output.ShowOutput("Ange djurets namn: ");
            string animalName = input.GetInput();

            //Kontrollera att djuret faktiskt finns registrerat
            if (CheckAnimalExists(animalName, animallist))
            {
                foreach (IAnimal a in animallist)
                {
                    if (a.AnimalName == animalName)
                    {
                        a.IsCheckedIn = true;
                        //Skapa kvitto för detta djur om det inte redan finns ett
                        var receipt = Factory.CreateReceipt();
                        if (!receipt.CheckIfAnimalHasReceipt(receiptList, animalName))
                        {
                            receipt.CreateBaseReceipt(receiptList, animalName, animallist);
                        }

                        output.ShowOutput($"Du har checkat in {animalName}");
                    }
                }
            }
            else
            {
                output.ShowOutput("Djuret du angivit finns inte registrerat. Försök med ett annat namn eller registrera djuret.");
            }  
        }

        //Skriv in djurets namn och hämta/ändra info ur lista samt skapa kvitto
        public void CheckOutAnimal(List<IAnimal> animallist, List<IReceipt> receiptlist)
        {
            var output = Factory.CreateOutputService();
            var input = Factory.CreateInputService();

            output.ShowOutput("Ange djurets namn: ");
            string animalName = input.GetInput();

            if (CheckAnimalExists(animalName, animallist) && CheckIfAnimalIsCheckedIn(animalName, animallist))
            {
                //Status sätts till utcheckad (false)
                foreach (IAnimal a in animallist)
                {
                    //kontrollera om djuret redan är incheckat     
                    if (a.AnimalName == animalName)
                    {
                        a.IsCheckedIn = false;

                        //Skicka kvitto
                        var receipt = Factory.CreateReceipt();
                        receipt.ShowReceipt(receiptlist, animalName);
                        output.ShowOutput($"Du har checkat ut {animalName}");

                        //ta bort kvittot
                        receipt.RemoveReceipt(receiptlist, animalName);
                    }
                }
            }
            else
            {
                output.ShowOutput("Djuret du angivit finns inte registrerat eller är inte incheckat. Försök med ett annat namn eller registrera djuret.");
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

        //Registrerar ett djur (kopplar ihop med ägaren).
        public void RegisterAnimal(IAnimal animal, List<IAnimal> animallist, List<ICustomer> custlist)
        {
            var custValidation = Factory.CreateCustomer();
            var output = Factory.CreateOutputService();
            var input = Factory.CreateInputService();

            output.ShowOutput("Ange djurets namn: ");
            animal.AnimalName = input.GetInput();

            output.ShowOutput("Ange djurets Ägare: ");
            string owner = input.GetInput();

            //Kontrollera att kunden/ägaren finns i "db"
            if (custValidation.SeeIfOwnerExists(owner, custlist))
            {
                var validatedOwner = custValidation.GetCustomer(owner, custlist);
                //lägg till kund i djur-objektet
                animal.Owner = validatedOwner;
                animallist.Add(animal);

                //lägg till djuret i kund-objektet
                List<IAnimal> templist = new List<IAnimal>();
                validatedOwner.Animals = templist;
                validatedOwner.Animals.Add(animal);
                output.ShowOutput($"{animal.AnimalName} är nu registrerad.");
            }
            else
            {
                output.ShowOutput("Ägaren existerar inte. Vänligen registrera ägare först!");
            }       
        }

        public bool CheckIfAnimalIsCheckedIn(string animalName, List<IAnimal> animalList)
        {
            foreach (IAnimal a in animalList)
            {
                if (a.IsCheckedIn == true)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
