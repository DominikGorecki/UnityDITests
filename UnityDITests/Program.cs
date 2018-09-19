using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Unity;
using Unity.Lifetime;
using UnityDITests.Interfaces;

namespace UnityDITests
{
    class Program
    {
        private readonly IUnityContainer _container;

        public Program(IUnityContainer unityContainer)
        {
            _container = unityContainer;
        }

        static void Main(string[] args)
        {
            IUnityContainer unitycontainer = new UnityContainer();
            // Since we are resolving a new instance for WorkingClass manually, we can 
            // get away with setting ContainerControlledLifetimeManager()
            unitycontainer.RegisterType<IWorkingClass, WorkingClass>(new ContainerControlledLifetimeManager());
            // Since we are relying on DI resolution to create a new instance for us everytime
            // we need it, don't use ContainerControlledLifetimeManager()
            //unitycontainer.RegisterType<IWorkingClass, WorkingClass>(new ContainerControlledLifetimeManager()); // UNCOMMET THIS TO SEE SHIT GO WRONG
            unitycontainer.RegisterType<IInjectedClass, InjectedClass>(new ContainerControlledTransientManager());

            var program = new Program(unitycontainer);
            program.UnityResolvedTest();
            //program.OneInjectedClass();
        }

        public void UnityResolvedTest()
        {
            var workingClass1 = _container.Resolve<WorkingClass>();
            var workingClass2 = _container.Resolve<WorkingClass>();

            DisplayWorkingClassInstances(workingClass1, workingClass2);

            Console.WriteLine("Notice one thread is writing 'x's and the other  'o's!!");
            Console.WriteLine("Okay you're done.. press any key to exit.");
            Console.ReadKey();
        }

        public void OneInjectedClass()
        {
            var injectedClass = new InjectedClass();

            var workingClass1 = new WorkingClass(injectedClass);
            var workingClass2 = new WorkingClass(injectedClass);

            DisplayWorkingClassInstances(workingClass1, workingClass2);

            Console.WriteLine("Notice both threads are writing 'o's!!");
            Console.WriteLine("Okay you're done.. press any key to exit.");
            Console.ReadKey();
        }

        private void DisplayWorkingClassInstances(IWorkingClass workingClass1, IWorkingClass workingClass2)
        {
            workingClass1.SetCustomIdentifier("1");
            workingClass2.SetCustomIdentifier("2");
            workingClass1.SetInjectedClassChar('x');
            workingClass2.SetInjectedClassChar('o');

            var thread1 = GetRepeatThreadForWorkingClass(workingClass1);
            var thread2 = GetRepeatThreadForWorkingClass(workingClass2);

            thread1.Start();
            thread2.Start();

            while(thread1.IsAlive || thread2.IsAlive) { }
 
        }
        private Thread GetRepeatThreadForWorkingClass(IWorkingClass workingClass)
        {
            return new Thread(() =>
            {
                for(var i = 0; i < 100; i ++)
                {
                    Thread.Sleep(50);
                    workingClass.PrintOutput();
                }
            });
        }
    }
}
