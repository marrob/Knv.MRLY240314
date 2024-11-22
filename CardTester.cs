
namespace Knv.MRLY240314
{
    using System;
    using System.Collections.Generic;

    public class CaseItem
    { 
        public string RelayName { get; set; }
        public string CaseName { get; set; }
        public List<E8287A> SwichedOnRelays { get; set; }
        public string Comment { get; set; }
        public double LowLimit { get; set; }
        public double HighLimit { get; set; }
        public double Value { get; set; }    
    }

    internal class CardTester
    {
        public List<CaseItem> Cases  { get; set; }

        public CardTester()
        {
             Cases = new List<CaseItem>();
        }

        public void MakeTestCases()
        {

            //K1 - Close
            Cases.Add(new CaseItem()
            {
                RelayName = $"K1",
                CaseName = "Close",
                SwichedOnRelays = new List<E8287A>()
                {
                    E8287A.RDG_I1,
                    E8287A.AB1_I1,
                    E8287A.K5,
                    E8287A.K1,
                    E8287A.AB1_R1,
                    E8287A.RDG_R1,
                }
            });

            //K1 - Open
            Cases.Add(new CaseItem()
            {
                RelayName = $"K1",
                CaseName = "Open",
                SwichedOnRelays = new List<E8287A>()
                {
                    E8287A.RDG_I1,
                    E8287A.AB1_I1,
                    E8287A.K5,
                    E8287A.AB1_R1,
                    E8287A.RDG_R1,
                }
            });

            //K2 - Close
            Cases.Add(new CaseItem()
            {
                RelayName = $"K2",
                CaseName = "Close",
                SwichedOnRelays = new List<E8287A>()
                {
                    E8287A.RDG_I1,
                    E8287A.AB2_I1,
                    E8287A.K6,
                    E8287A.K2,
                    E8287A.AB2_R1,
                    E8287A.RDG_R1,
                }
            });

            //K2 - Open
            Cases.Add(new CaseItem()
            {
                RelayName = $"K2",
                CaseName = "Open",
                SwichedOnRelays = new List<E8287A>()
                {
                    E8287A.RDG_I1,
                    E8287A.AB2_I1,
                    E8287A.K6,
                    E8287A.AB2_R1,
                    E8287A.RDG_R1,
                }
            });

            //K3 - Close
            Cases.Add(new CaseItem()
            {
                RelayName = $"K3",
                CaseName = "Close",
                SwichedOnRelays = new List<E8287A>()
                {
                    E8287A.RDG_I1,
                    E8287A.AB3_I1,
                    E8287A.K7,
                    E8287A.K3,
                    E8287A.AB3_R1,
                    E8287A.RDG_R1,
                }
            });

            //K3 - Open
            Cases.Add(new CaseItem()
            {
                RelayName = $"K3",
                CaseName = "Open",
                SwichedOnRelays = new List<E8287A>()
                {
                    E8287A.RDG_I1,
                    E8287A.AB3_I1,
                    E8287A.K7,
                    E8287A.AB3_R1,
                    E8287A.RDG_R1,
                }
            });

            //K4 - Close
            Cases.Add(new CaseItem()
            {
                RelayName = $"K4",
                CaseName = "Close",
                SwichedOnRelays = new List<E8287A>()
                {
                    E8287A.RDG_I1,
                    E8287A.AB4_I1,
                    E8287A.K8,
                    E8287A.K4,
                    E8287A.AB4_R1,
                    E8287A.RDG_R1,
                }
            });

            //K4 - Open
            Cases.Add(new CaseItem()
            {
                RelayName = $"K4",
                CaseName = "Open",
                SwichedOnRelays = new List<E8287A>()
                {
                    E8287A.RDG_I1,
                    E8287A.AB4_I1,
                    E8287A.K8,
                    E8287A.AB4_R1,
                    E8287A.RDG_R1,
                }
            });


            //K5 - Close
            Cases.Add(new CaseItem()
            {
                RelayName = $"K5",
                CaseName = "Close",
                SwichedOnRelays = new List<E8287A>()
                {
                    E8287A.RDG_I1,
                    E8287A.AB1_I1,
                    E8287A.K5,
                    E8287A.K1,
                    E8287A.AB1_R1,
                    E8287A.RDG_R1,
                }
            });

            //K5 - Open
            Cases.Add(new CaseItem()
            {
                RelayName = $"K5",
                CaseName = "Open",
                SwichedOnRelays = new List<E8287A>()
                {
                    E8287A.RDG_I1,
                    E8287A.AB1_I1,
                    E8287A.K1,
                    E8287A.AB1_R1,
                    E8287A.RDG_R1,
                }
            });

            //K6 - Close
            Cases.Add(new CaseItem()
            {
                RelayName = $"K6",
                CaseName = "Close",
                SwichedOnRelays = new List<E8287A>()
                {
                    E8287A.RDG_I1,
                    E8287A.AB2_I1,
                    E8287A.K6,
                    E8287A.K2,
                    E8287A.AB2_R1,
                    E8287A.RDG_R1,
                }
            });

            //K6 - Open
            Cases.Add(new CaseItem()
            {
                RelayName = $"K6",
                CaseName = "Open",
                SwichedOnRelays = new List<E8287A>()
                {
                    E8287A.RDG_I1,
                    E8287A.AB2_I1,
                    E8287A.K2,
                    E8287A.AB2_R1,
                    E8287A.RDG_R1,
                }
            });

            //K7 - Close
            Cases.Add(new CaseItem()
            {
                RelayName = $"K7",
                CaseName = "Close",
                SwichedOnRelays = new List<E8287A>()
                {
                    E8287A.RDG_I1,
                    E8287A.AB3_I1,
                    E8287A.K7,
                    E8287A.K3,
                    E8287A.AB3_R1,
                    E8287A.RDG_R1,
                }
            });

            //K7 - Open
            Cases.Add(new CaseItem()
            {
                RelayName = $"K7",
                CaseName = "Open",
                SwichedOnRelays = new List<E8287A>()
                {
                    E8287A.RDG_I1,
                    E8287A.AB3_I1,
                    E8287A.K3,
                    E8287A.AB3_R1,
                    E8287A.RDG_R1,
                }
            });

            //K8 - Close
            Cases.Add(new CaseItem()
            {
                RelayName = $"K8",
                CaseName = "Close",
                SwichedOnRelays = new List<E8287A>()
                {
                    E8287A.RDG_I1,
                    E8287A.AB4_I1,
                    E8287A.K8,
                    E8287A.K4,
                    E8287A.AB4_R1,
                    E8287A.RDG_R1,
                }
            });

            //K8 - Open
            Cases.Add(new CaseItem()
            {
                RelayName = $"K8",
                CaseName = "Open",
                SwichedOnRelays = new List<E8287A>()
                {
                    E8287A.RDG_I1,
                    E8287A.AB4_I1,
                    E8287A.K4,
                    E8287A.AB4_R1,
                    E8287A.RDG_R1,
                }
            });

            //--- AB1_R 1..40 ---
            for (int row = 0; row < E8287aInfo.RowsCount; row++)
            {
                Cases.Add(new CaseItem()
                {
                    RelayName = $"AB1_R{row}",
                    CaseName = "Close",
                    SwichedOnRelays = new List<E8287A>()
                    {
                        E8287A.RDG_I1,
                        E8287A.AB1_I1,
                        E8287A.K5,
                        E8287A.K1,
                        E8287aInfo.Abus1Rows[row],
                        E8287aInfo.DiagRows[row],
                    }
                });

                Cases.Add(new CaseItem()
                {
                    RelayName = $"AB1_R{row}",
                    CaseName = "Open",
                    SwichedOnRelays = new List<E8287A>()
                    {
                        E8287A.RDG_I1,
                        E8287A.AB1_I1,
                        E8287A.K5,
                        E8287A.K1,
                        E8287aInfo.DiagRows[row],
                    }
                });
            }

            //--- AB2_R 1..40 ---
            for (int row = 0; row < E8287aInfo.RowsCount; row++)
            {
                Cases.Add(new CaseItem()
                {
                    RelayName = $"AB2_R{row}",
                    CaseName = "Close",
                    SwichedOnRelays = new List<E8287A>()
                    {
                        E8287A.RDG_I1,
                        E8287A.AB2_I1,
                        E8287A.K6,
                        E8287A.K2,
                        E8287aInfo.Abus2Rows[row],
                        E8287aInfo.DiagRows[row],
                    }
                });


                Cases.Add(new CaseItem()
                {
                    RelayName = $"AB2_R{row}",
                    CaseName = "Open",
                    SwichedOnRelays = new List<E8287A>()
                    {
                        E8287A.RDG_I1,
                        E8287A.AB2_I1,
                        E8287A.K6,
                        E8287A.K2,
                        E8287aInfo.DiagRows[row],
                    }
                });
            }

            //--- AB3_R 1..40 ---
            for (int row = 0; row < E8287aInfo.RowsCount; row++)
            {
                Cases.Add(new CaseItem()
                {
                    RelayName = $"AB3_R{row}",
                    CaseName = "Close",
                    SwichedOnRelays = new List<E8287A>()
                    {
                        E8287A.RDG_I1,
                        E8287A.AB3_I1,
                        E8287A.K7,
                        E8287A.K3,
                        E8287aInfo.Abus3Rows[row],
                        E8287aInfo.DiagRows[row],
                    }
                });

                Cases.Add(new CaseItem()
                {
                    RelayName = $"AB3_R{row}",
                    CaseName = "Open",
                    SwichedOnRelays = new List<E8287A>()
                    {
                        E8287A.RDG_I1,
                        E8287A.AB3_I1,
                        E8287A.K7,
                        E8287A.K3,
                        E8287aInfo.DiagRows[row],
                    }
                });
            }

            //--- AB4_R 1..40 ---
            for (int row = 0; row < E8287aInfo.RowsCount; row++)
            {
                Cases.Add(new CaseItem()
                {
                    RelayName = $"AB4_R{row}",
                    CaseName = "Close",
                    SwichedOnRelays = new List<E8287A>()
                    {
                        E8287A.RDG_I1,
                        E8287A.AB4_I1,
                        E8287A.K8,
                        E8287A.K4,
                        E8287aInfo.Abus4Rows[row],
                        E8287aInfo.DiagRows[row],
                    }
                });

                Cases.Add(new CaseItem()
                {
                    RelayName = $"AB4_R{row}",
                    CaseName = "Close",
                    SwichedOnRelays = new List<E8287A>()
                    {
                        E8287A.RDG_I1,
                        E8287A.AB4_I1,
                        E8287A.K8,
                        E8287A.K4,
                        E8287aInfo.DiagRows[row],
                    }
                });
            }

            //--- AUX_R 1..40 ---
            for (int row = 0; row < E8287aInfo.InstrCount; row++)
            {
                Cases.Add(new CaseItem()
                {
                    RelayName = $"AUX_R{row}",
                    CaseName = "Close",
                    SwichedOnRelays = new List<E8287A>()
                    {
                        E8287A.RDG_I1,
                        E8287A.AB1_I1,
                        E8287A.K5,
                        E8287A.K1,
                        E8287aInfo.Abus1Rows[row],
                        E8287aInfo.AuxRows[row],
                        E8287aInfo.DiagAux[row]
                    }
                });

                Cases.Add(new CaseItem()
                {
                    RelayName = $"AUX_R{row}",
                    CaseName = "Open",
                    SwichedOnRelays = new List<E8287A>()
                    {
                        E8287A.RDG_I1,
                        E8287A.AB1_I1,
                        E8287A.K5,
                        E8287A.K1,
                        E8287aInfo.Abus1Rows[row],
                        E8287aInfo.DiagAux[row]
                    }
                });
            }

            //--- AB1_I 1..24 ---
            for (int row = 0; row < E8287aInfo.InstrCount; row++)
            {
                Cases.Add(new CaseItem()
                {
                    RelayName = $"AB1_I{row}",
                    CaseName = "Close",
                    SwichedOnRelays = new List<E8287A>()
                    {
                        E8287aInfo.DiagInstr[row],
                        E8287aInfo.Abus1Instr[row],
                        E8287A.K5,
                        E8287A.K1,
                        E8287A.AB1_R1,
                        E8287A.RDG_R1
                    }
                });

                Cases.Add(new CaseItem()
                {
                    RelayName = $"AB1_I{row}",
                    CaseName = "Open",
                    SwichedOnRelays = new List<E8287A>()
                    {
                        E8287aInfo.DiagInstr[row],
                        E8287A.K5,
                        E8287A.K1,
                        E8287A.AB1_R1,
                        E8287A.RDG_R1
                    }
                });
            }

            //--- AB2_I 1..24 ---
            for (int row = 0; row < E8287aInfo.InstrCount; row++)
            {
                Cases.Add(new CaseItem()
                {
                    RelayName = $"AB2_I{row}",
                    CaseName = "Close",
                    SwichedOnRelays = new List<E8287A>()
                    {
                        E8287aInfo.DiagInstr[row],
                        E8287aInfo.Abus2Instr[row],
                        E8287A.K6,
                        E8287A.K2,
                        E8287A.AB2_R1,
                        E8287A.RDG_R1
                    }
                });

                Cases.Add(new CaseItem()
                {
                    RelayName = $"AB2_I{row}",
                    CaseName = "Open",
                    SwichedOnRelays = new List<E8287A>()
                    {
                        E8287aInfo.DiagInstr[row],
                        E8287A.K6,
                        E8287A.K2,
                        E8287A.AB2_R1,
                        E8287A.RDG_R1
                    }
                });
            }

            //--- AB3_I 1..24 ---
            for (int row = 0; row < E8287aInfo.InstrCount; row++)
            {
                Cases.Add(new CaseItem()
                {
                    RelayName = $"AB3_I{row}",
                    CaseName = "Close",
                    SwichedOnRelays = new List<E8287A>()
                    {
                        E8287aInfo.DiagInstr[row],
                        E8287aInfo.Abus3Instr[row],
                        E8287A.K7,
                        E8287A.K3,
                        E8287A.AB3_R1,
                        E8287A.RDG_R1
                    }
                });

                Cases.Add(new CaseItem()
                {
                    RelayName = $"AB3_I{row}",
                    CaseName = "Open",
                    SwichedOnRelays = new List<E8287A>()
                    {
                        E8287aInfo.DiagInstr[row],
                        E8287A.K7,
                        E8287A.K3,
                        E8287A.AB3_R1,
                        E8287A.RDG_R1
                    }
                });
            }

            //--- AB4_I 1..24 ---
            for (int row = 0; row < E8287aInfo.InstrCount; row++)
            {
                Cases.Add(new CaseItem()
                {
                    RelayName = $"AB4_I{row}",
                    CaseName = "Close",
                    SwichedOnRelays = new List<E8287A>()
                    {
                        E8287aInfo.DiagInstr[row],
                        E8287aInfo.Abus4Instr[row],
                        E8287A.K8,
                        E8287A.K4,
                        E8287A.AB4_R1,
                        E8287A.RDG_R1
                    }
                });

                Cases.Add(new CaseItem()
                {
                    RelayName = $"AB4_I{row}",
                    CaseName = "Open",
                    SwichedOnRelays = new List<E8287A>()
                    {
                        E8287aInfo.DiagInstr[row],
                        E8287A.K8,
                        E8287A.K4,
                        E8287A.AB4_R1,
                        E8287A.RDG_R1
                    }
                });
            }
        }
    }
}
