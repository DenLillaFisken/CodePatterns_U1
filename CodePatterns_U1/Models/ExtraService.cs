using CodePatterns_U1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodePatterns_U1.Models
{
    public class ExtraService : IExtraService
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }


        //Lägg till en extratjänst till ett registrerat djur
        public void AddExtraServiceToAnimal(IReceipt receipt, List<IExtraService> exserviceList, List<IAnimal> animalList, List<IReceipt> receiptList)
        {
            var output = Factory.CreateOutputService();
            var input = Factory.CreateInputService();

            //Välj vilket djur det gäller
            output.ShowOutput("Skriv namnet på djuret som ska ha extratjänsten: ");
            string animalName = input.GetInput();

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
                    receipt = receipt.GetReceipt(receiptList, animalName);
                    if (receipt.ExtraServices == null)
                    {
                        //skapa en lista
                        List<IExtraService> newlist = new List<IExtraService>();
                        receipt.ExtraServices = newlist;
                    }
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
                output.ShowOutput($"Du har lagt till tjänsten {extraService.Name}");
            }
            else
            {
                output.ShowOutput("Djuret du uppgav fanns inte, vänligen börja om.");
            }
        }
        public IExtraService PickExtraService(List<IExtraService> exserviceList)
        {
            var output = Factory.CreateOutputService();
            var input = Factory.CreateInputService();

            ShowExtraServices(exserviceList);

            output.ShowOutput("Välj från listan ovan vilken extratjänst du vill lägga till (skriv numret från listan)");
            var choise = 0;
            try
            {
                choise = Convert.ToInt32(input.GetInput());
            }
            catch
            {
                output.ShowOutput("Du måste välja från listan.");
            }

            return exserviceList[choise - 1];
        }

        public void ShowExtraServices(List<IExtraService> exserviceList)
        {
            var output = Factory.CreateOutputService();
            int count = 1;
            foreach (IExtraService e in exserviceList)
            {
                output.ShowOutput($"{count}. {e.Name} kostnad: {e.Price}, beskrivning: {e.Description}");
                count++;
            }
        }
    }
}
