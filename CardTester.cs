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

                    //--- AB1_R1 ---
                    new CaseItem()
                    {
                        Name = "AB1_R1 Close",
                        SwichedOnRelays = new List<E8287A>()
                        {
                            E8287A.RDG_I1,
                            E8287A.AB1_I1,
                            E8287A.K5,
                            E8287A.K1,
                            E8287A.AB1_R1,
                            E8287A.RDG_R1
                        }
                    },

                    new CaseItem()
                    {
                        Name = "AB1_R1 Open",
                        SwichedOnRelays = new List<E8287A>()
                        {
                            E8287A.RDG_I1,
                            E8287A.AB1_I1,
                            E8287A.K5,
                            E8287A.K1,
                            E8287A.RDG_R1
                        }
                    },
                    
                    //--- AB1_R2 ---
                    new CaseItem()
                    {
                        Name = "AB1_R2 Close",
                        SwichedOnRelays = new List<E8287A>()
                        {
                            E8287A.RDG_I1,
                            E8287A.AB1_I1,
                            E8287A.K5,
                            E8287A.K1,
                            E8287A.AB1_R2,
                            E8287A.RDG_R2
                        }
                    },

                    new CaseItem()
                    {
                        Name = "AB1_R2 Open",
                        SwichedOnRelays = new List<E8287A>()
                        {
                            E8287A.RDG_I1,
                            E8287A.AB1_I1,
                            E8287A.K5,
                            E8287A.K1,
                            E8287A.RDG_R2
                        }
                    },
                                        
                    //--- AB1_R3 ---
                    new CaseItem()
                    {
                        Name = "AB1_R3 Close",
                        SwichedOnRelays = new List<E8287A>()
                        {
                            E8287A.RDG_I1,
                            E8287A.AB1_I1,
                            E8287A.K5,
                            E8287A.K1,
                            E8287A.AB1_R3,
                            E8287A.RDG_R3
                        }
                    },

                    new CaseItem()
                    {
                        Name = "AB1_R3 Open",
                        SwichedOnRelays = new List<E8287A>()
                        {
                            E8287A.RDG_I1,
                            E8287A.AB1_I1,
                            E8287A.K5,
                            E8287A.K1,
                            E8287A.RDG_R3
                        }
                    },

                                        
                    //--- AB1_R4 ---
                    new CaseItem()
                    {
                        Name = "AB1_R4 Close",
                        SwichedOnRelays = new List<E8287A>()
                        {
                            E8287A.RDG_I1,
                            E8287A.AB1_I1,
                            E8287A.K5,
                            E8287A.K1,
                            E8287A.AB1_R4,
                            E8287A.RDG_R4
                        }
                    },

                    new CaseItem()
                    {
                        Name = "AB1_R4 Open",
                        SwichedOnRelays = new List<E8287A>()
                        {
                            E8287A.RDG_I1,
                            E8287A.AB1_I1,
                            E8287A.K5,
                            E8287A.K1,
                            E8287A.RDG_R4
                        }
                    },
                         
                    //--- AB1_R5 ---
                    new CaseItem()
                    {
                        Name = "AB1_R5 Close",
                        SwichedOnRelays = new List<E8287A>()
                        {
                            E8287A.RDG_I1,
                            E8287A.AB1_I1,
                            E8287A.K5,
                            E8287A.K1,
                            E8287A.AB1_R5,
                            E8287A.RDG_R5
                        }
                    },

                    new CaseItem()
                    {
                        Name = "AB1_R5 Open",
                        SwichedOnRelays = new List<E8287A>()
                        {
                            E8287A.RDG_I1,
                            E8287A.AB1_I1,
                            E8287A.K5,
                            E8287A.K1,
                            E8287A.RDG_R5
                        }
                    },

                    //--- AB1_R6 ---
                    new CaseItem()
                    {
                        Name = "AB1_R6 Close",
                        SwichedOnRelays = new List<E8287A>()
                        {
                            E8287A.RDG_I1,
                            E8287A.AB1_I1,
                            E8287A.K5,
                            E8287A.K1,
                            E8287A.AB1_R6,
                            E8287A.RDG_R6
                        }
                    },

                    new CaseItem()
                    {
                        Name = "AB1_R6 Open",
                        SwichedOnRelays = new List<E8287A>()
                        {
                            E8287A.RDG_I1,
                            E8287A.AB1_I1,
                            E8287A.K5,
                            E8287A.K1,
                            E8287A.RDG_R6
                        }
                    },

                                       
                    //--- AB1_R7 ---
                    new CaseItem()
                    {
                        Name = "AB1_R7 Close",
                        SwichedOnRelays = new List<E8287A>()
                        {
                            E8287A.RDG_I1,
                            E8287A.AB1_I1,
                            E8287A.K5,
                            E8287A.K1,
                            E8287A.AB1_R7,
                            E8287A.RDG_R7
                        }
                    },

                    new CaseItem()
                    {
                        Name = "AB1_R7 Open",
                        SwichedOnRelays = new List<E8287A>()
                        {
                            E8287A.RDG_I1,
                            E8287A.AB1_I1,
                            E8287A.K5,
                            E8287A.K1,
                            E8287A.RDG_R6
                        }
                    },

                                       
                    //--- AB1_R8 ---
                    new CaseItem()
                    {
                        Name = "AB1_R8 Close",
                        SwichedOnRelays = new List<E8287A>()
                        {
                            E8287A.RDG_I1,
                            E8287A.AB1_I1,
                            E8287A.K5,
                            E8287A.K1,
                            E8287A.AB1_R8,
                            E8287A.RDG_R8
                        }
                    },

                    new CaseItem()
                    {
                        Name = "AB1_R8 Open",
                        SwichedOnRelays = new List<E8287A>()
                        {
                            E8287A.RDG_I1,
                            E8287A.AB1_I1,
                            E8287A.K5,
                            E8287A.K1,
                            E8287A.RDG_R8
                        }
                    },



                }
            );
        }
    }
}
