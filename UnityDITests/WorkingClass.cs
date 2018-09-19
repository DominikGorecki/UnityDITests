using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityDITests.Interfaces;

namespace UnityDITests
{
    public class WorkingClass : IWorkingClass
    {
        private readonly IInjectedClass _injectedClass;
        private string name;

        public WorkingClass(IInjectedClass injectedClass)
        {
            _injectedClass = injectedClass;
        }

        public void PrintOutput()
        {
            Console.WriteLine($"{name}-{_injectedClass.GetCurrentChar()}");
        }

        public void SetCustomIdentifier(string name)
        {
            this.name = name;
        }

        public void SetInjectedClassChar(char c)
        {
            _injectedClass.SetRepeatChar(c);
        }
    }
}
