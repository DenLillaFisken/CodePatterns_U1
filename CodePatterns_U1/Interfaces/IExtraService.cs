using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodePatterns_U1.Interfaces
{
    public interface IExtraService
    {
        string Name { get; set; }
        int Price { get; set; }
        string Description { get; set; }

        void ShowExtraServices(List<IExtraService> exserviceList);
        IExtraService PickExtraService(List<IExtraService> exserviceList);
    }
}
