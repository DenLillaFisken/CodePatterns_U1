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
