using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodePatterns_U1.Interfaces
{
    public interface IMenu
    {
        void ChooseMenuAlternative(List<ICustomer> custList, List<IAnimal> animalList, List<IExtraService> exServiceList, List<IReceipt> receiptsList);

        void ReloadMenu(List<ICustomer> custList, List<IAnimal> animalList, List<IExtraService> exServiceList, List<IReceipt> receiptsList);

    }
}
