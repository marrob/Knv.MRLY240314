

namespace Knv.MRLY240314.UnitTest
{
    using System;
    using System.Threading;
    using NUnit.Framework;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using System.Diagnostics;

    [TestFixture]
    internal class E8782A_CardTester_UnitTest
    {
        [Test]
        public void CaseItem_K8()
        { 
            var ci = new StepItem()
            {
                SwichedOnRelays = new List<E8287A>
                {
                    E8287A.K8
                }
            };
            var result = ci.GetStringOfRelayChain();
            Assert.AreEqual("00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000080", result);
        }


        [Test]
        public void CaseItem_RDG_R33()
        {
            var ci = new StepItem()
            {
                SwichedOnRelays = new List<E8287A>
                {
                    E8287A.RDG_R33
                }
            };
            var result = ci.GetStringOfRelayChain();
            Assert.AreEqual("01000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000", result);
        }


        [Test]
        public void AsyncRunTest()
        {
            var ct = new E8782A_CardTester();
            AutoResetEvent  are = new AutoResetEvent(false);

            ct.MakeSteps();
            var rnd = new Random();

            Action runAction = () =>
            {
                StepItem ci;
                while ((ci = ct.NextStep()) != null)
                {
                    Console.WriteLine("Teszt Elek");
                    var value = rnd.Next(0, 1000);
                    ci.Measured = value;
                    Console.WriteLine($"A {ci.RelayName} - {ci.CaseName} végetért, eredménye: {ci.Measured}");
                }

                are.Set();
            };

            runAction.BeginInvoke(new AsyncCallback((IAresut) => { Console.WriteLine("Test Vege"); }), null);
            
           are.WaitOne();

        }
    }
}
