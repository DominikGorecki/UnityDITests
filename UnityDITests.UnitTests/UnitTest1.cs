using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Unity;
using UnityDITests.Interfaces;

namespace UnityDITests.UnitTests
{
    [TestClass]
    public class UnityUnitTests 
    {
        [TestMethod]
        public void TestDIWithOutSpecifyingLifetimeManagment()
        {
            // ARRANGE
            IUnityContainer unityContainer = new UnityContainer();
            unityContainer.RegisterType<IWorkingClass, WorkingClassForUnitTests>();
            unityContainer.RegisterType<IInjectedClass, InjectedClass>();

            var workingClass1 = unityContainer.Resolve<WorkingClassForUnitTests>();
            var workingClass2 = unityContainer.Resolve<WorkingClassForUnitTests>();

            // If we are getting a new instance of injectedClass everytime we resolve, then 
            // class1 will only have 'x's, otherwise it will have 'o's.
            workingClass1.SetInjectedClassChar('x');
            workingClass2.SetInjectedClassChar('o');

            // ACT
            for (var i = 0; i < 10; i++)
            {
                workingClass1.PrintOutput();
                workingClass2.PrintOutput();
            }

            // ASSERT
            Assert.IsTrue(workingClass1.GetPrintedChars().All(c => c == 'x'));
            Assert.IsTrue(workingClass2.GetPrintedChars().All(c => c == 'o'));
        }
    }
}
