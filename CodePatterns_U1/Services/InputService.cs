using CodePatterns_U1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodePatterns_U1.Services
{
    public class InputService : Iinput
    {
        public string GetInput()
        {
            return Console.ReadLine();
        }
    }
}
