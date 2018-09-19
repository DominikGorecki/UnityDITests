using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityDITests.Interfaces
{
    public interface IWorkingClass
    {
        void PrintOutput();

        void SetCustomIdentifier(string name);

        void SetInjectedClassChar(char c);
    }
}
