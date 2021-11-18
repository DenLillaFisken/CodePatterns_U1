using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodePatterns_U1.Interfaces
{
    public interface IReceipt
    {
        int Price { get; set; }
        List<IExtraService> ExtraServices { get; set; }
        IAnimal Animal { get; set; }

        void AddExtraServiceToAnimal(IReceipt receipt, List<IExtraService> exserviceList, List<IAnimal> animalList, List<IReceipt> receiptList);
        public int CalculateTotalPrice(List<IExtraService> serviceList, int baseCost);
        bool CheckIfAnimalHasReceipt(List<IReceipt> receiptlist, string animal);
        void ShowReceipt(List<IReceipt> receiptlist, string animalName);
        IReceipt GetReceipt(List<IReceipt> receiptlist, string animal);
        void CreateBaseReceipt(List<IReceipt> receiptlist, string animal, List<IAnimal> animalList);

    }
}
