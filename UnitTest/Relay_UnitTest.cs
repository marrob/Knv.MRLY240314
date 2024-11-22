

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
        public void SetOneRelyByController()
        {
            TestContext.WriteLine("TestContex: Hello World");
            Console.WriteLine("Console: Hello World");
            var rc = new RelayController();
            rc.SetRelayState((int)E8287A.K8, true);
            TestContext.WriteLine(rc.ToHexString());
            Assert.AreEqual("00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000080", rc.ToHexString());
        }

        [Test]
        public void SetTwoRelyByController()
        {
            var e8287A = new E8287A[128];
        }


        [Test]
        public void Check()
        {
            var tester = new CardTester();
            var rc = new RelayController();
            var con = new Connection();

            con.Open("COM11");

            string name = con.WhoIs();
            Assert.AreEqual("MRLY240314.FW", name);
            con.SetFpgaBypass(true);

            tester.MakeTestCases();

            Console.WriteLine("Test Start");

            foreach (var caseItem in tester.Cases)
            {
                foreach (var relay in caseItem.SwichedOnRelays)
                    rc.SetRelayState((int)relay, true);

                var chainState = rc.ToHexString();
                con.SetChain(chainState);
                Thread.Sleep(20);
                caseItem.Value = con.GetOhms();

            
                rc.Reset();
            }



            for (int i = 0; i< tester.Cases.Count; i+= 2)
            {
                string restult = $"{tester.Cases[i].RelayName}; {tester.Cases[i].Value}; {tester.Cases[i+1].Value}";
                Console.WriteLine(restult);
            }


             

            Console.WriteLine("Test Completed");
            con.Close();
        }
    }
}
