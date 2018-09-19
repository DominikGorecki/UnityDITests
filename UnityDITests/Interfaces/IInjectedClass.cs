using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityDITests.Interfaces
{
    public interface IInjectedClass
    {
        void SetRepeatChar(char c);

        char GetCurrentChar();
    }
}
