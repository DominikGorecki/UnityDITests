using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityDITests.Interfaces;

namespace UnityDITests
{
    public class InjectedClass : IInjectedClass
    {
        private char activeChar;

        public char GetCurrentChar()
        {
            return activeChar;
        }

        public void SetRepeatChar(char c)
        {
            activeChar = c;
        }
    }
}
