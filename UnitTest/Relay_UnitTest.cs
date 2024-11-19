

namespace Knv.MRLY240314.UnitTest
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
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
    }
}
