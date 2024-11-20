using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knv.MRLY240314
{


    public class CaseItem
    { 
        public string Name { get; set; }
        public List<E8287A> SwichedOnRelays { get; set; }
        public string Comment { get; set; }
        public double LowLimit { get; set; }
        public double HighLimit { get; set; }
        public double Value { get; set; }    
    }

    internal class CardTester
    {

       public List<CaseItem> CaseCollection { get; set; }

        public CardTester()
        {
            CaseCollection = new List<CaseItem>();

            CaseCollection.AddRange(
                new List<CaseItem>()
                {
                    new CaseItem()
                    {
                        Name = "RDG_I1-AB1_I1-K5-K1-AB1_R1-RDG_R1",
                        SwichedOnRelays = new List<E8287A>()
                        {
                            E8287A.RDG_I1,
                            E8287A.AB1_I1,
                            E8287A.K5,
                            E8287A.K1,
                            E8287A.AB1_R1,
                            E8287A.RDG_R1,
                        },
                        LowLimit = 0,
                        HighLimit = 10,
                        Value = 0
                    },

                    new CaseItem()
                    {
                        Name = "RDG_I2-AB2_I1-K6-K2-AB2_R1-RDG_R1",
                        SwichedOnRelays = new List<E8287A>()
                        {
                            E8287A.RDG_I1,
                            E8287A.AB1_I1,
                            E8287A.K6,
                            E8287A.K2,
                            E8287A.AB2_R1,
                            E8287A.RDG_R1,
                        },
                        LowLimit = 0,
                        HighLimit = 10,
                        Value = 0
                    },
                }
            );
        }
    }
}
