

namespace Knv.MRLY240314.UnitTest
{
    using System;
    using System.Threading;
    using Knv.MRLY240314.IO;
    using NUnit.Framework;
    using System.Collections.Generic;

    [TestFixture]
    internal class Relay_UnitTest
    {

        string SERIAL_PORT = "COM11";

        /// <summary>
        /// INST1 - AB4 - ROW8
        /// </summary>
        [Test]
        public void L3_M4_HI()
        {
            var con = new Connection();
            con.Open(SERIAL_PORT);
            string name = con.WhoIs();
            Assert.AreEqual("MRLY240314.FW", name);
            con.SetFpgaBypass(true);

            var si = new StepItem()
            {
                SwichedOnRelays = new List<E8287A>
                {
                    E8287A.RDG_I1,
                    E8287A.AB4_I1,
                    E8287A.K8,
                    E8287A.K4,
                    E8287A.AB4_R8,
                    E8287A.RDG_R8,
                }
            };
            con.SetChain(si.GetStringOfRelayChain());
            Thread.Sleep(20);
            si.Measured = con.MeasureResistance();
            con.SetChain(new StepItem().GetStringOfRelayChain());
        }

        /// <summary>
        /// INST2 - AB3 - ROW10
        /// </summary>
        [Test]
        public void L3_M4_LO()
        {
            var con = new Connection();
            con.Open(SERIAL_PORT);
            string name = con.WhoIs();
            Assert.AreEqual("MRLY240314.FW", name);
            con.SetFpgaBypass(true);
            var si = new StepItem()
            {
                SwichedOnRelays = new List<E8287A>
                {
                    E8287A.RDG_I2,
                    E8287A.AB3_I2,
                    E8287A.K7,
                    E8287A.K3,
                    E8287A.AB3_R10,
                    E8287A.RDG_R10,
                }
            };
            con.SetChain(si.GetStringOfRelayChain());
            Thread.Sleep(20);
            si.Measured = con.MeasureResistance();
            con.SetChain(new StepItem().GetStringOfRelayChain());
        }

        /// <summary>
        /// INST1 - AB2 - ROW1
        /// </summary>
        [Test]
        public void M1_L2_HI()
        {
            var con = new Connection();
            con.Open(SERIAL_PORT);
            string name = con.WhoIs();
            Assert.AreEqual("MRLY240314.FW", name);
            con.SetFpgaBypass(true);
            var si = new StepItem()
            {
                SwichedOnRelays = new List<E8287A>
                {
                    E8287A.RDG_I1,
                    E8287A.AB2_I1,
                    E8287A.K6,
                    E8287A.K2,
                    E8287A.AB2_R1,
                    E8287A.RDG_R1,
                }
            };
            con.SetChain(si.GetStringOfRelayChain());
            Thread.Sleep(20);
            si.Measured = con.MeasureResistance();
            con.SetChain(new StepItem().GetStringOfRelayChain());
        }

        /// <summary>
        /// INST2 - AB1 - ROW2
        /// </summary>
        [Test]
        public void M1_L2_LO()
        {
            var con = new Connection();
            con.Open(SERIAL_PORT);
            string name = con.WhoIs();
            Assert.AreEqual("MRLY240314.FW", name);
            con.SetFpgaBypass(true);
            var si = new StepItem()
            {
                SwichedOnRelays = new List<E8287A>
                {
                    E8287A.RDG_I2,
                    E8287A.AB1_I2,
                    E8287A.K5,
                    E8287A.K1,
                    E8287A.AB1_R2,
                    E8287A.RDG_R2,
                }
            };
            con.SetChain(si.GetStringOfRelayChain());
            Thread.Sleep(20);
            si.Measured = con.MeasureResistance();
            con.SetChain(new StepItem().GetStringOfRelayChain());
        }


        /// <summary>
        /// INST1 - AB2 - ROW3
        /// </summary>
        [Test]
        public void M1_M2_HI()
        {
            var con = new Connection();
            con.Open(SERIAL_PORT);
            string name = con.WhoIs();
            Assert.AreEqual("MRLY240314.FW", name);
            con.SetFpgaBypass(true);
            var si = new StepItem()
            {
                SwichedOnRelays = new List<E8287A>
                {
                    E8287A.RDG_I1,
                    E8287A.AB2_I1,
                    E8287A.K6,
                    E8287A.K2,
                    E8287A.AB2_R3,
                    E8287A.RDG_R3,
                }
            };
            con.SetChain(si.GetStringOfRelayChain());
            Thread.Sleep(20);
            si.Measured = con.MeasureResistance();
            con.SetChain(new StepItem().GetStringOfRelayChain());
        }


        /// <summary>
        /// INST2 - AB1 - ROW2
        /// </summary>
        [Test]
        public void M1_M2_LO()
        {
            var con = new Connection();
            con.Open(SERIAL_PORT);
            string name = con.WhoIs();
            Assert.AreEqual("MRLY240314.FW", name);
            con.SetFpgaBypass(true);
            var si = new StepItem()
            {
                SwichedOnRelays = new List<E8287A>
                {
                    E8287A.RDG_I2,
                    E8287A.AB1_I2,
                    E8287A.K5,
                    E8287A.K1,
                    E8287A.AB1_R2,
                    E8287A.RDG_R2,
                }
            };
            con.SetChain(si.GetStringOfRelayChain());
            Thread.Sleep(20);
            si.Measured = con.MeasureResistance();
            con.SetChain(new StepItem().GetStringOfRelayChain());
        }


        /// <summary>
        /// INST1 - AB2 - ROW8
        /// </summary>
        [Test]
        public void M3_L3_HI()
        {
            var con = new Connection();
            con.Open(SERIAL_PORT);
            string name = con.WhoIs();
            Assert.AreEqual("MRLY240314.FW", name);
            con.SetFpgaBypass(true);
            var si = new StepItem()
            {
                SwichedOnRelays = new List<E8287A>
                {
                    E8287A.RDG_I1,
                    E8287A.AB2_I1,
                    E8287A.K6,
                    E8287A.K2,
                    E8287A.AB2_R8,
                    E8287A.RDG_R8,
                }
            };
            con.SetChain(si.GetStringOfRelayChain());
            Thread.Sleep(20);
            si.Measured = con.MeasureResistance();
            con.SetChain(new StepItem().GetStringOfRelayChain());
        }

        /// <summary>
        /// INST2 - AB1 - ROW9
        /// </summary>
        [Test]
        public void M3_L3_LO()
        {
            var con = new Connection();
            con.Open(SERIAL_PORT);
            string name = con.WhoIs();
            Assert.AreEqual("MRLY240314.FW", name);
            con.SetFpgaBypass(true);
            var si = new StepItem()
            {
                SwichedOnRelays = new List<E8287A>
                {
                    E8287A.RDG_I2,
                    E8287A.AB1_I2,
                    E8287A.K5,
                    E8287A.K1,
                    E8287A.AB1_R9,
                    E8287A.RDG_R9,
                }
            };
            con.SetChain(si.GetStringOfRelayChain());
            Thread.Sleep(20);
            si.Measured = con.MeasureResistance();
            con.SetChain(new StepItem().GetStringOfRelayChain());
        }


        /// <summary>
        /// INST1 - AB1 - ROW1
        /// </summary>
        [Test]
        public void K1__Close()
        {
            var con = new Connection();
            con.Open(SERIAL_PORT);
            string name = con.WhoIs();
            Assert.AreEqual("MRLY240314.FW", name);
            con.SetFpgaBypass(true);
            var si = new StepItem()
            {
                SwichedOnRelays = new List<E8287A>
                {
                    E8287A.RDG_I1,
                    E8287A.AB1_I1,
                    E8287A.K5,
                    E8287A.K1,
                    E8287A.AB1_R1,
                    E8287A.RDG_R1,
                }
            };
            con.SetChain(si.GetStringOfRelayChain());
            Thread.Sleep(20);
            si.Measured = con.MeasureResistance();
            con.SetChain(new StepItem().GetStringOfRelayChain());
        }

        /// <summary>
        /// INST1 - AB2 - ROW1
        /// </summary>
        [Test]
        public void K2__Close()
        {
            var con = new Connection();
            con.Open(SERIAL_PORT);
            string name = con.WhoIs();
            Assert.AreEqual("MRLY240314.FW", name);
            con.SetFpgaBypass(true);
            var si = new StepItem()
            {
                SwichedOnRelays = new List<E8287A>
                {
                    E8287A.RDG_I1,
                    E8287A.AB2_I1,
                    E8287A.K6,
                    E8287A.K2,
                    E8287A.AB2_R1,
                    E8287A.RDG_R1,
                }
            };
            con.SetChain(si.GetStringOfRelayChain());
            Thread.Sleep(20);
            si.Measured = con.MeasureResistance();
            con.SetChain(new StepItem().GetStringOfRelayChain());
        }

        /// <summary>
        /// INST1 - AB3 - ROW1
        /// </summary>
        [Test]
        public void K3__Close()
        {
            var con = new Connection();
            con.Open(SERIAL_PORT);
            string name = con.WhoIs();
            Assert.AreEqual("MRLY240314.FW", name);
            con.SetFpgaBypass(true);
            var si = new StepItem()
            {
                SwichedOnRelays = new List<E8287A>
                {
                    E8287A.RDG_I1,
                    E8287A.AB3_I1,
                    E8287A.K7,
                    E8287A.K3,
                    E8287A.AB3_R1,
                    E8287A.RDG_R1,
                }
            };
            con.SetChain(si.GetStringOfRelayChain());
            Thread.Sleep(20);
            si.Measured = con.MeasureResistance();
            con.SetChain(new StepItem().GetStringOfRelayChain());
        }

        /// <summary>
        /// INST1 - AB4 - ROW1
        /// </summary>
        [Test]
        public void K4__Close()
        {
            var con = new Connection();
            con.Open(SERIAL_PORT);
            string name = con.WhoIs();
            Assert.AreEqual("MRLY240314.FW", name);
            con.SetFpgaBypass(true);
            var si = new StepItem()
            {
                SwichedOnRelays = new List<E8287A>
                {
                    E8287A.RDG_I1,
                    E8287A.AB4_I1,
                    E8287A.K8,
                    E8287A.K4,
                    E8287A.AB4_R1,
                    E8287A.RDG_R1,
                }
            };
            con.SetChain(si.GetStringOfRelayChain());
            Thread.Sleep(20);
            si.Measured = con.MeasureResistance();
            con.SetChain(new StepItem().GetStringOfRelayChain());
        }

        /// <summary>
        /// INST1 - AB1 - ROW33 - AUX33
        /// </summary>
        [Test]
        public void AUX_R33__Close()
        {
            var con = new Connection();
            con.Open(SERIAL_PORT);
            string name = con.WhoIs();
            Assert.AreEqual("MRLY240314.FW", name);
            con.SetFpgaBypass(true);
            var si = new StepItem()
            {
                SwichedOnRelays = new List<E8287A>
                {
                    E8287A.RDG_I1,
                    E8287A.AB1_I1,
                    E8287A.K5,
                    E8287A.K1,
                    E8287A.AB1_R33,
                    E8287A.AUX_R33,
                    E8287A.ADG_R33,
                }
            };
            con.SetChain(si.GetStringOfRelayChain());
            Thread.Sleep(20);
            si.Measured = con.MeasureResistance();
            con.SetChain(new StepItem().GetStringOfRelayChain());
        }


        /// <summary>
        /// INST1 - AB1 - ROW34 - AUX34
        /// </summary>
        [Test]
        public void AUX_R34__Close()
        {
            var con = new Connection();
            con.Open(SERIAL_PORT);
            string name = con.WhoIs();
            Assert.AreEqual("MRLY240314.FW", name);
            con.SetFpgaBypass(true);
            var si = new StepItem()
            {
                SwichedOnRelays = new List<E8287A>
                {
                    E8287A.RDG_I1,
                    E8287A.AB1_I1,
                    E8287A.K5,
                    E8287A.K1,
                    E8287A.AB1_R34,
                    E8287A.AUX_R34,
                    E8287A.ADG_R34,
                }
            };
            con.SetChain(si.GetStringOfRelayChain());
            Thread.Sleep(20);
            si.Measured = con.MeasureResistance();
            con.SetChain(new StepItem().GetStringOfRelayChain());
        }


        [Test]
        public void Check()
        {
            var tester = new E8782A_CardTester();
            var con = new Connection();

            con.Open(SERIAL_PORT);

            string name = con.WhoIs();
            Assert.AreEqual("MRLY240314.FW", name);
            con.SetFpgaBypass(true);

            tester.MakeSteps();

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
