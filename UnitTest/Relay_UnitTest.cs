

namespace Knv.MRLY240314.UnitTest
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
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

            Console.WriteLine("Test Start");
            foreach (var caseItem in tester.CaseCollection)
            {

                foreach (var relay in caseItem.SwichedOnRelays)
                    rc.SetRelayState((int)relay, true);

                var chainState = rc.ToHexString();
                con.SetChain(chainState);
                Thread.Sleep(500);
                caseItem.Value = con.GetOhms();

                Console.WriteLine($"{ caseItem.Name }: { caseItem.Value }");
                //Console.WriteLine(chainState);

                rc.Reset();
            }
            Console.WriteLine("Test Completed");
            con.Close();
        }
    }
}
