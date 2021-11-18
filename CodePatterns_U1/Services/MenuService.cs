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
            Console.WriteLine("1. Registrera ny kund ");
            Console.WriteLine("2. Registrera djur ");
            Console.WriteLine("3. Se registrerade kunder ");
            Console.WriteLine("4. Se registrerade djur ");
            Console.WriteLine("5. Vilka djur tillhör vilka kunder");
            Console.WriteLine("6. Anmäl att ett djur är inlämnat ");
            Console.WriteLine("7. Anmäl att ett djur är hämtat");
            Console.WriteLine("8. Se nuvarande inlämnade djur samt ägare till dessa");
            Console.WriteLine("9. Koppla extratjänster till ett djur");
            Console.WriteLine("");

            Console.WriteLine("Välj ditt val genom att skriva en siffra nedan:");

            try
            {
                //validera input
                var input = Console.ReadLine();

                var validation = Factory.Validate();
                if (validation.ValidateMenuChoise(input))
                {
                    switch (input)
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
                            ShowList.ShowAnimals(animalList);

                            ReloadMenu(custList, animalList, exServiceList, receiptsList);
                            break;

                        case "5":
                            //Se vilka djur som tillhör vilka kunder
                            ShowList.ShowAnimalsWithOwners(animalList, custList);

                            ReloadMenu(custList, animalList, exServiceList, receiptsList);
                            break;

                        case "6":
                            //Checka in ett djur
                            var checkinAnimal = Factory.CreateAnimal();
                            checkinAnimal.CheckInAnimal(animalList);

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
                            receipt.AddExtraServiceToAnimal(receipt, exServiceList, animalList, receiptsList);

                            ReloadMenu(custList, animalList, exServiceList, receiptsList);
                            break;

                        default:
                            Console.WriteLine("Du skrev in fel, testa igen!");
                            ReloadMenu(custList, animalList, exServiceList, receiptsList);
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Du måste skriva in en siffra mellan 1 och 9.");
                    ReloadMenu(custList, animalList, exServiceList, receiptsList);
                }
            }
            catch
            {
                Console.WriteLine("Hoppsan, någonting gick visst fel. Testa igen.");
                ReloadMenu(custList, animalList, exServiceList, receiptsList);
            }
        }

        public void ReloadMenu(List<ICustomer> custList, List<IAnimal> animalList, List<IExtraService> exServiceList, List<IReceipt> receiptsList)
        {
            //För att ladda om menyn efter ett menyval så att inte applikationen dör.
            Console.ReadLine();
            ChooseMenuAlternative(custList, animalList, exServiceList, receiptsList);
        }
    }
}
