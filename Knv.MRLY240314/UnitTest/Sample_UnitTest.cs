using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Threading;

namespace Knv.Sample.NUnit
{
    [TestFixture]
    internal class Sample_UnitTest
    {
        bool _ResourceIsBusy ;

        /// <summary>
        /// Ez minden teszt előt 1x biztos lefut
        /// Valamilyen erőforrás lefoglalásához jó
        /// </summary>
        [SetUp]
        public void TestSetup()
        {
            
            _ResourceIsBusy = true;
            Console.WriteLine($"SampleTimoeoutTest.TestSetup.{_ResourceIsBusy} ");
        }

        /// <summary>
        /// 
        /// </summary>
        [TearDown]
        public void TestCleanUp()
        {
            _ResourceIsBusy = false;
            Console.WriteLine($"SampleTimoeoutTest.TestCleanUp.{_ResourceIsBusy} ");
        }

        [Test]
        public void AddTwoNumber()
        {
            Assert.AreEqual(2, 1 + 1);
        }

        [TestCase(5, 1, Description = "arg1 > arg2 ?")]
        [TestCase(6, 2, Description = "arg1 > arg2 ?")]
        public void Arguments(int arg1, int arg2)
        {
            Assert.IsTrue(arg1 > arg2);
        }

        [Test]
        public void SampleTimoeoutTest()
        {
            var wait = new AutoResetEvent(false);

            Action asyncMethod = () =>
            {
                Thread.Sleep(900);
            };

            AsyncCallback cpltCallback = (itfAr) =>
            {
                Console.WriteLine("SampleTimoeoutTest.Complete.");
                wait.Set();
            };

           var result = asyncMethod.BeginInvoke(cpltCallback, null);


            if (!wait.WaitOne(TimeSpan.FromSeconds(1)))
                Assert.Fail("Timeout");

            if (result is Exception)
                Assert.Fail((result as Exception).Message);

        }


        [Test]
        public void CatchAnException()
        {
            Assert.Throws<ArgumentException>(() =>{ 

                throw new ArgumentException("Hupsss");
            });

            Assert.Throws<ArgumentException>(() => {

                throw new NotImplementedException();
            });
        }

        [Test]
        public void GetTestDirectory()
        {
            Console.WriteLine(TestContext.CurrentContext.TestDirectory);

            Console.WriteLine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));
        }

        [Test]
        public void EventRisedTest()
        {

            var met = new MockEventTest();

            var isRised = false;
            met.DemoEvent += (o, str) =>
            {
                isRised = true;
            };

            met.RiseDemoEvent();
            Assert.IsTrue(isRised);
        }

        class MockEventTest
        {
            public event EventHandler<string> DemoEvent;

            public void RiseDemoEvent()
            {
                DemoEvent?.Invoke(this, "Hello, World!");
            }
        
        }




        //https://learn.microsoft.com/en-us/dotnet/api/system.stathreadattribute?view=net-7.0
        [Test] 
        [Apartment(ApartmentState.STA)] //Indicates that the COM threading model for an application is single-threaded apartment
        public void SingleThreaded()
        {


        }


    }
}
