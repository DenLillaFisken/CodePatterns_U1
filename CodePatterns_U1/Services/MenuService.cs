using CodePatterns_U1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodePatterns_U1.Services
{
    public class MenuService : IMenu
    {
        public void ChooseMenuAlternative(List<ICustomer> custList, List<IAnimal> animalList, List<IExtraService> exServiceList, List<IReceipt> receiptsList)
        {
            var output = Factory.CreateOutputService();
            var input = Factory.CreateInputService();

            output.ShowOutput("1. Registrera ny kund ");
            output.ShowOutput("2. Registrera djur ");
            output.ShowOutput("3. Se registrerade kunder ");
            output.ShowOutput("4. Se registrerade djur ");
            output.ShowOutput("5. Vilka djur tillhör vilka kunder");
            output.ShowOutput("6. Anmäl att ett djur är inlämnat ");
            output.ShowOutput("7. Anmäl att ett djur är hämtat");
            output.ShowOutput("8. Se nuvarande inlämnade djur samt ägare till dessa");
            output.ShowOutput("9. Koppla extratjänster till ett djur");
            output.ShowOutput("");

            output.ShowOutput("Välj ditt val genom att skriva en siffra nedan:");

            try
            {
                //validera input
                var menuInput = input.GetInput();

                var validation = Factory.Validate();
                if (validation.ValidateMenuChoise(menuInput))
                {
                    switch (menuInput)
                    {
                        case "1":
                            //Registrera ny kund 
                            var customer = Factory.CreateCustomer();
                            customer.RegisterCustomer(customer, custList);

                            ReloadMenu(custList, animalList, exServiceList, receiptsList);
                            break;

                         case "2":
                            //Registrera nytt djur 
                            var animal = Factory.CreateAnimal();
                            animal.RegisterAnimal(animal, animalList, custList);

                            ReloadMenu(custList, animalList, exServiceList, receiptsList);
                            break;

                        case "3":
                            //Se vilka kunder som finns registrerade
                            ShowList.ShowCustomers(custList);

                            ReloadMenu(custList, animalList, exServiceList, receiptsList);
                            break;

                        case "4":
                            //Se vilka djur som finns registrerade
                            ShowList.ShowAnimals(animalList, false);

                            ReloadMenu(custList, animalList, exServiceList, receiptsList);
                            break;

                        case "5":
                            //Se vilka djur som tillhör vilka kunder
                            ShowList.ShowAnimals(animalList, true);

                            ReloadMenu(custList, animalList, exServiceList, receiptsList);
                            break;

                        case "6":
                            //Checka in ett djur
                            var checkinAnimal = Factory.CreateAnimal();
                            checkinAnimal.CheckInAnimal(animalList, receiptsList);

                            ReloadMenu(custList, animalList, exServiceList, receiptsList);
                            break;

                        case "7":
                            //Checka ut ett djur
                            var checkoutAnimal = Factory.CreateAnimal();
                            checkoutAnimal.CheckOutAnimal(animalList, receiptsList);

                            ReloadMenu(custList, animalList, exServiceList, receiptsList);
                            break;

                        case "8":
                            //Se vilka djur som är incheckade
                            ShowList.ShowCheckedInAnimals(animalList, custList);

                            ReloadMenu(custList, animalList, exServiceList, receiptsList);
                            break;

                        case"9":
                            //koppla extratjänster till ett djur
                            var receipt = Factory.CreateReceipt();
                            var extraService = Factory.CreateExtraService();

                            extraService.AddExtraServiceToAnimal(receipt, exServiceList, animalList, receiptsList);

                            ReloadMenu(custList, animalList, exServiceList, receiptsList);
                            break;

                        default:
                            output.ShowOutput("Du skrev in fel, testa igen!");
                            ReloadMenu(custList, animalList, exServiceList, receiptsList);
                            break;
                    }
                }
                else
                {
                    output.ShowOutput("Du måste skriva in en siffra mellan 1 och 9.");
                    ReloadMenu(custList, animalList, exServiceList, receiptsList);
                }
            }
            catch
            {
                output.ShowOutput("Hoppsan, någonting gick visst fel. Testa igen.");
                ReloadMenu(custList, animalList, exServiceList, receiptsList);
            }
        }

        public void ReloadMenu(List<ICustomer> custList, List<IAnimal> animalList, List<IExtraService> exServiceList, List<IReceipt> receiptsList)
        {
            //För att ladda om menyn efter ett menyval så att inte applikationen dör.

            Console.Clear();
            ChooseMenuAlternative(custList, animalList, exServiceList, receiptsList);
        }
    }
}
