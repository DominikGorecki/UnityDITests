using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityDITests.Interfaces;

namespace UnityDITests.UnitTests
{
    // Normally we would mock up the class with something like Moq, but since we are testing DI itself, we need a concrete class to work with that we can inspect
    public class WorkingClassForUnitTests : IWorkingClass
    {
        private readonly IInjectedClass _injectedClass;
        private string name;
        private readonly List<char> _printedChars;

        public WorkingClassForUnitTests(IInjectedClass injectedClass)
        {
            _injectedClass = injectedClass;
            _printedChars = new List<char>();
        }

        public void PrintOutput()
        {
            // We don't need to see anything, but let's record what would print
            _printedChars.Add(_injectedClass.GetCurrentChar());
        }

        public void SetCustomIdentifier(string name)
        {
            // We don't need to really use this for our test--this was more for the console output
            throw new NotImplementedException();
        }

        public void SetInjectedClassChar(char c)
        {
            _injectedClass.SetRepeatChar(c);
        }

        public List<char> GetPrintedChars()
        {
            return _printedChars;
        }
    }
}
