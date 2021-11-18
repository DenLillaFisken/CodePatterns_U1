using CodePatterns_U1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodePatterns_U1.Models
{
    public class Receipt : IReceipt
    {
        public int Price { get; set; } = 250;
        public List<IExtraService> ExtraServices { get; set; }
        public IAnimal Animal { get; set; }

        //Lägg till en extratjänst till ett registrerat djur
        public void AddExtraServiceToAnimal(IReceipt receipt, List<IExtraService> exserviceList, List<IAnimal> animalList, List<IReceipt> receiptList)
        {
            //Välj vilket djur det gäller
            Console.WriteLine("Skriv namnet på djuret som ska ha extratjänsten: ");
            string animalName = Console.ReadLine();

            //Kontrollera om djuret finns registerat
            var animal = Factory.CreateAnimal();
            if (animal.CheckAnimalExists(animalName, animalList))
            {
                //Hämta extratjänsten som ska läggas till
                var extraService = Factory.CreateExtraService();
                extraService = extraService.PickExtraService(exserviceList);
                
                //Om djuret finns, kontrollera om det redan finns ett kvitto skapat för det redan.
                if (receipt.CheckIfAnimalHasReceipt(receiptList, animalName))
                {
                    receipt = GetReceipt(receiptList, animalName);
                    receipt.ExtraServices.Add(extraService);
                }
                else
                {
                    receipt.Animal = animal.GetAnimal(animalName, animalList);
                    List<IExtraService> newList = new List<IExtraService>();
                    receipt.ExtraServices = newList;
                    receipt.ExtraServices.Add(extraService);
                    receiptList.Add(receipt);
                } 
            }
            else
            {
                Console.WriteLine("Djuret du uppgav fanns inte, vänligen börja om.");
            }     
        }

        //Räknar ut den totala kostnaden på kvittot
        public int CalculateTotalPrice(List<IExtraService> serviceList, int baseCost)
        {
            int extraServiceCost = 0;
            if (serviceList != null)
            {
                foreach (IExtraService e in serviceList)
                {
                    extraServiceCost += e.Price;
                }
                int totalAmount = baseCost + extraServiceCost;
                return totalAmount;
            }
            return 0;
        }

        //Skriver ut kvittot i consolen
        public void ShowReceipt(List<IReceipt> receiptlist, string animalName)
        {

            Console.WriteLine("KVITTO");
            Console.WriteLine($"Djur: {animalName}");

            foreach (IReceipt r in receiptlist)
            {
                if (r.Animal.AnimalName == animalName)
                {
                    foreach (IExtraService e in r.ExtraServices)
                    {
                        Console.WriteLine($"Extratjänster: {e.Name}....... kostnad: {e.Price}");
                    }
                   
                    Console.WriteLine($"Baskostnad: {r.Price}");
                    //skicka lista till calculateTotalPrice -> få tillbaks total kostnad
                    int cost = CalculateTotalPrice(r.ExtraServices, r.Price);
                    Console.WriteLine($"Total kostnad: {cost}");
                }
            }        
        }

        //Kontrollera om djuret redan har ett kvitto registrerat på sig
        bool IReceipt.CheckIfAnimalHasReceipt(List<IReceipt> receiptlist, string animal)
        {
            foreach (IReceipt r in receiptlist)
            {
                if(r.Animal.AnimalName == animal)
                {
                    return true;
                }
            }
            return false;
        }

        //Hämta kvitto för specifikt djur
        public IReceipt GetReceipt(List<IReceipt> receiptlist, string animal)
        {
            foreach (IReceipt r in receiptlist)
            {
                if (r.Animal.AnimalName == animal)
                {
                    return r;
                }
            }
            return null;
        }
    }
}
