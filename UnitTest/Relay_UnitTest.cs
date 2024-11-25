

namespace Knv.MRLY240314.UnitTest
{
    using System;
    using System.Threading;
    using Knv.MRLY240314.IO;
    using NUnit.Framework;

    [TestFixture]
    internal class Relay_UnitTest
    { 


        [Test]
        public void Check()
        {
            var tester = new E8782A_CardTester();
            var con = new Connection();

            con.Open("COM11");

            string name = con.WhoIs();
            Assert.AreEqual("MRLY240314.FW", name);
            con.SetFpgaBypass(true);

            tester.MakeTestSteps();

            Console.WriteLine("Test Start");

            foreach (var caseItem in tester.Steps)
            {
                string chainState = caseItem.GetStringOfRelayChain();
                con.SetChain(chainState);
                Thread.Sleep(20);
                caseItem.Measured = con.MeasureResistance();
            }

            for (int i = 0; i< tester.Steps.Count; i+= 2)
            {
                string restult = $"{tester.Steps[i].RelayName}; {tester.Steps[i].Measured}; {tester.Steps[i+1].Measured}";
                Console.WriteLine(restult);
            }

            Console.WriteLine("Test Completed");
            con.Close();
        }
    }
}
