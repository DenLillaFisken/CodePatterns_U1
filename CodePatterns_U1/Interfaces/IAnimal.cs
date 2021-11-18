using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodePatterns_U1.Interfaces
{
    public interface IAnimal
    {
        string AnimalName { get; set; }
        string Owner { get; set; }
        bool IsCheckedIn { get; set; }

        void RegisterAnimal(IAnimal animal, List<IAnimal> animallist, List<ICustomer> custlist);
        void CheckOutAnimal(List<IAnimal> animallist, List<IReceipt> receiptlist);
        void CheckInAnimal(List<IAnimal> animallist);
        IAnimal GetAnimal(string animalName, List<IAnimal> animalList);
        bool CheckAnimalExists(string animalName, List<IAnimal> animalList);
    }
}
