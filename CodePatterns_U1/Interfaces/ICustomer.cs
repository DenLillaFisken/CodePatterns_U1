using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodePatterns_U1.Interfaces
{
    public interface ICustomer
    {
        public string Name { get; set; }
        public long PhoneNumber { get; set; }
        public string Email { get; set; }
        public List<IAnimal> Animals { get; set; }

        void RegisterCustomer(ICustomer cust, List<ICustomer> custlist);
        bool SeeIfOwnerExists(string customer, List<ICustomer> custList);
        public ICustomer GetCustomer(string name, List<ICustomer> custList);
    }
}
