
namespace Knv.MRLY240314
{
    using Knv.MRLY240314.Properties;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;



    /// <summary>
    /// A rlékártyán lévő egy relé teszjének a lírása.
    /// </summary>
    public class StepItem
    {

        public string RelayName { get; set; }
        public string CaseName { get; set; }
        public List<E8287A> SwichedOnRelays { get; set; }
        public string Description { get; set; }

        public bool Executed { get; set; }
        public string Result
        {
            get 
            {
                if (Executed)
                {
                    if (LowLimit <= Measured && Measured <= HighLimit)
                        return "PASSED";
                    else
                       return "FAILED";
                }
                else
                {
                    return "-";
                }
            }
        }
        public double LowLimit { get; set; }
        public double HighLimit { get; set; }
        public double Measured { get; set; }
        public string Unit { get; set; }




        /// <summary>
        /// 55db relémeghatjó ic-van (TPIC) ezt kövzevelenül elérjük a hw-val
        /// </summary>
        private readonly int relayCount = 55 * 8;
        byte[] relayBytes;

        /// <summary>
        /// Az állapothoz tartozó meghuzott relék állapotát adja visza, amit már a hardwernek lehet küldeni...
        /// 
        /// Az E8287A.K8 - a láncban az első TPIC D7-es pozicójában van, mivel a legisebb helyétérkűvel kezdjük siftelést ő kerül a legulsó indexre.
        /// E8287A.K8: 00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000080
        /// 
        /// RDG_R33 - a legutolsó TPIC- D0-ás poziciójában van
        /// E8287A.RDG_R33:01000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000
        /// 
        /// </summary>
        /// <returns></returns>
        public string GetStringOfRelayChain()
        {
            if (relayCount <= 0)
                throw new ArgumentException("Relay count must be greater than zero.");

            if (relayCount % 8 != 0)
                throw new ArgumentException("Relay count must be div by 8");

            relayBytes = new byte[relayCount / 8]; // Bájtszám kiszámítása

            foreach (var relay in SwichedOnRelays)
                SetRelayState(relay);

            return BitConverter.ToString(relayBytes).Replace("-", "");
        }

        // Relé állapot beállítása a bájttömbe
        private void SetRelayState(E8287A rly_index)
        {
            int index = (int)rly_index;

            if (index < 0 || index >= relayCount)
                throw new IndexOutOfRangeException($"Relay index {index} is out of range (0-{relayCount - 1}).");

            int byteIndex = index / 8;
            int bitIndex = index % 8;

            relayBytes[byteIndex] |= (byte)(1 << bitIndex);
        }
    }

    internal class E8782A_CardTester
    {
        public List<StepItem> Steps  { get; set; }
        public int GetCurrentTestPointer
        {
            get
            {
                return _caseIndex;
            }
        }
        public int _caseIndex = 0;
        public E8782A_CardTester()
        {
             Steps = new List<StepItem>();
        }

        /// <summary>
        /// A kártáyn lévő relékhez tartozó tesztestesetek létrehozása.
        /// Alapvetően minden relét nyitott és zárt állásban tesztülnk
        /// Több relét is meg kell húzni egy relé teszteléséshez...
        /// </summary>
        public void MakeSteps()
        {
            Steps.Clear();

            //K1 - Close
            Steps.Add(new StepItem()
            {
                RelayName = $"K1",
                CaseName = "Close",
                Unit = "OHM",
                LowLimit = Settings.Default.CloseLowLimit,
                HighLimit = Settings.Default.CloseHighLimit,
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
            Steps.Add(new StepItem()
            {
                RelayName = $"K1",
                CaseName = "Open",
                Unit = "OHM",
                LowLimit = Settings.Default.BypassResistorLowLimit,
                HighLimit = Settings.Default.BypassResistorHighLimit,
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
            Steps.Add(new StepItem()
            {
                RelayName = $"K2",
                CaseName = "Close",
                Unit = "OHM",
                LowLimit = Settings.Default.CloseLowLimit,
                HighLimit = Settings.Default.CloseHighLimit,
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
            Steps.Add(new StepItem()
            {
                RelayName = $"K2",
                CaseName = "Open",
                Unit = "OHM",
                LowLimit = Settings.Default.BypassResistorLowLimit,
                HighLimit = Settings.Default.BypassResistorHighLimit,
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
            Steps.Add(new StepItem()
            {
                RelayName = $"K3",
                CaseName = "Close",
                Unit = "OHM",
                LowLimit = Settings.Default.CloseLowLimit,
                HighLimit = Settings.Default.CloseHighLimit,
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
            Steps.Add(new StepItem()
            {
                RelayName = $"K3",
                CaseName = "Open",
                Unit = "OHM",
                LowLimit = Settings.Default.BypassResistorLowLimit,
                HighLimit = Settings.Default.BypassResistorHighLimit,
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
            Steps.Add(new StepItem()
            {
                RelayName = $"K4",
                CaseName = "Close",
                Unit = "OHM",
                LowLimit = Settings.Default.CloseLowLimit,
                HighLimit = Settings.Default.CloseHighLimit,
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
            Steps.Add(new StepItem()
            {
                RelayName = $"K4",
                CaseName = "Open",
                Unit = "OHM",
                LowLimit = Settings.Default.BypassResistorLowLimit,
                HighLimit = Settings.Default.BypassResistorHighLimit,
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
            Steps.Add(new StepItem()
            {
                RelayName = $"K5",
                CaseName = "Close",  
                Unit = "OHM",
                LowLimit = Settings.Default.CloseLowLimit,
                HighLimit = Settings.Default.CloseHighLimit,
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
            Steps.Add(new StepItem()
            {
                RelayName = $"K5",
                CaseName = "Open",
                Unit = "OHM",
                LowLimit = Settings.Default.OpenLowLimit,
                HighLimit = Settings.Default.OpenHighLimit,
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
            Steps.Add(new StepItem()
            {
                RelayName = $"K6",
                CaseName = "Close",
                Unit = "OHM",
                LowLimit = Settings.Default.CloseLowLimit,
                HighLimit = Settings.Default.CloseHighLimit,
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
            Steps.Add(new StepItem()
            {
                RelayName = $"K6",
                CaseName = "Open",
                Unit = "OHM",
                LowLimit = Settings.Default.OpenLowLimit,
                HighLimit = Settings.Default.OpenHighLimit,
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
            Steps.Add(new StepItem()
            {
                RelayName = $"K7",
                CaseName = "Close",
                Unit = "OHM",
                LowLimit = Settings.Default.CloseLowLimit,
                HighLimit = Settings.Default.CloseHighLimit,
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
            Steps.Add(new StepItem()
            {
                RelayName = $"K7",
                CaseName = "Open",
                Unit = "OHM",
                LowLimit = Settings.Default.OpenLowLimit,
                HighLimit = Settings.Default.OpenHighLimit,
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
            Steps.Add(new StepItem()
            {
                RelayName = $"K8",
                CaseName = "Close",
                Unit = "OHM",
                LowLimit = Settings.Default.CloseLowLimit,
                HighLimit = Settings.Default.CloseHighLimit,
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
            Steps.Add(new StepItem()
            {
                RelayName = $"K8",
                CaseName = "Open",
                Unit = "OHM",
                LowLimit = Settings.Default.OpenLowLimit,
                HighLimit = Settings.Default.OpenHighLimit,
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
                Steps.Add(new StepItem()
                {
                    RelayName = $"AB1_R{row + 1}",
                    CaseName = "Close",
                    Unit = "OHM",
                    LowLimit = Settings.Default.CloseLowLimit,
                    HighLimit = Settings.Default.CloseHighLimit,
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

                Steps.Add(new StepItem()
                {
                    RelayName = $"AB1_R{row + 1}",
                    CaseName = "Open",
                    Unit = "OHM",
                    LowLimit = Settings.Default.OpenLowLimit,
                    HighLimit = Settings.Default.OpenHighLimit,
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
                Steps.Add(new StepItem()
                {
                    RelayName = $"AB2_R{row + 1}",
                    CaseName = "Close",
                    Unit = "OHM",
                    LowLimit = Settings.Default.CloseLowLimit,
                    HighLimit = Settings.Default.CloseHighLimit,
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

                Steps.Add(new StepItem()
                {
                    RelayName = $"AB2_R{row + 1}",
                    CaseName = "Open",
                    Unit = "OHM",
                    LowLimit = Settings.Default.OpenLowLimit,
                    HighLimit = Settings.Default.OpenHighLimit,
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
                Steps.Add(new StepItem()
                {
                    RelayName = $"AB3_R{row + 1}",
                    CaseName = "Close",
                    Unit = "OHM",
                    LowLimit = Settings.Default.CloseLowLimit,
                    HighLimit = Settings.Default.CloseHighLimit,
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

                Steps.Add(new StepItem()
                {
                    RelayName = $"AB3_R{row + 1}",
                    CaseName = "Open",
                    Unit = "OHM",
                    LowLimit = Settings.Default.OpenLowLimit,
                    HighLimit = Settings.Default.OpenHighLimit,
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
                Steps.Add(new StepItem()
                {
                    RelayName = $"AB4_R{row + 1}",
                    CaseName = "Close",
                    Unit = "OHM",
                    LowLimit = Settings.Default.CloseLowLimit,
                    HighLimit = Settings.Default.CloseHighLimit,
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

                Steps.Add(new StepItem()
                {
                    RelayName = $"AB4_R{row + 1}",
                    CaseName = "Open",
                    Unit = "OHM",
                    LowLimit = Settings.Default.OpenLowLimit,
                    HighLimit = Settings.Default.OpenHighLimit,
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
            for (int row = 0; row < E8287aInfo.RowsCount; row++)
            {
                Steps.Add(new StepItem()
                {
                    RelayName = $"AUX_R{row + 1}",
                    CaseName = "Close",
                    Unit = "OHM",
                    LowLimit = Settings.Default.CloseLowLimit,
                    HighLimit = Settings.Default.CloseHighLimit,
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

                Steps.Add(new StepItem()
                {
                    RelayName = $"AUX_R{row + 1}",
                    CaseName = "Open",
                    Unit = "OHM",
                    LowLimit = Settings.Default.OpenLowLimit,
                    HighLimit = Settings.Default.OpenHighLimit,
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
                Steps.Add(new StepItem()
                {
                    RelayName = $"AB1_I{row + 1}",
                    CaseName = "Close",
                    Unit = "OHM",
                    LowLimit = Settings.Default.CloseLowLimit,
                    HighLimit = Settings.Default.CloseHighLimit,
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

                Steps.Add(new StepItem()
                {
                    RelayName = $"AB1_I{row + 1}",
                    CaseName = "Open",
                    Unit = "OHM",
                    LowLimit = Settings.Default.OpenLowLimit,
                    HighLimit = Settings.Default.OpenHighLimit,
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
                Steps.Add(new StepItem()
                {
                    RelayName = $"AB2_I{row + 1}",
                    CaseName = "Close",
                    Unit = "OHM",
                    LowLimit = Settings.Default.CloseLowLimit,
                    HighLimit = Settings.Default.CloseHighLimit,
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

                Steps.Add(new StepItem()
                {
                    RelayName = $"AB2_I{row + 1}",
                    CaseName = "Open",
                    Unit = "OHM",
                    LowLimit = Settings.Default.OpenLowLimit,
                    HighLimit = Settings.Default.OpenHighLimit,
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
                Steps.Add(new StepItem()
                {
                    RelayName = $"AB3_I{row + 1}",
                    CaseName = "Close",
                    Unit = "OHM",
                    LowLimit = Settings.Default.CloseLowLimit,
                    HighLimit = Settings.Default.CloseHighLimit,
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

                Steps.Add(new StepItem()
                {
                    RelayName = $"AB3_I{row + 1}",
                    CaseName = "Open",
                    Unit = "OHM",
                    LowLimit = Settings.Default.OpenLowLimit,
                    HighLimit = Settings.Default.OpenHighLimit,
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
                Steps.Add(new StepItem()
                {
                    RelayName = $"AB4_I{row + 1}",
                    CaseName = "Close",
                    Unit = "OHM",
                    LowLimit = Settings.Default.CloseLowLimit,
                    HighLimit = Settings.Default.CloseHighLimit,
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

                Steps.Add(new StepItem()
                {
                    RelayName = $"AB4_I{row + 1}",
                    CaseName = "Open",
                    Unit = "OHM",
                    LowLimit = Settings.Default.OpenLowLimit,
                    HighLimit = Settings.Default.OpenHighLimit,
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



        public void Reset()
        {
            foreach (var item in Steps)
            {
                item.Measured = 0;
                item.Executed = false;
                _caseIndex = 0;
            }
        }

        public StepItem NextStep()
        {
            StepItem retval = null;
            if (_caseIndex < Steps.Count)
            {
                string realyChain = Steps[_caseIndex].GetStringOfRelayChain();
                Steps[_caseIndex].Executed = true;
                retval = Steps[_caseIndex];
                _caseIndex++;
            }
            else
            {
                retval = null;
            }

            return retval;
        }

        /// <summary>
        /// CSV LOG készítése
        /// </summary>
        /// <param name="directory">Ide készül a log fájl</param>
        /// <param name="dt">Log Startja</param>
        /// <param name="card_id">A kártya egyedi azonosítója</param>
        /// <param name="parameterLines">Ezt a részt hozzáfűzi a log végéhez </param>
        /// <returns></returns>
        public string MakeCsvReport(string directory, DateTime dt, string card_id, string test_result, List<string> parameterLines)
        {
            var lines = new List<string>();
            lines.Add($"Relay__Case;Measured;Unit;Low..High Limit;Result;Executed");
            foreach (var step in Steps)
               lines.Add($"{step.RelayName}__{step.CaseName};{step.Measured:F3};{step.Unit};{step.LowLimit}..{step.HighLimit};{step.Result};{step.Executed}");
            lines.Add($"---END---");

            lines.Add("---PARAMETERS---");
            foreach (var paramLine in parameterLines)
                lines.Add(paramLine);

            if (!File.Exists(directory))
                Directory.CreateDirectory(directory);

            var fileName = $"{card_id}_{dt:yyyy}{dt:MM}{dt:dd}_{dt:HH}{dt:mm}{dt:ss}_{test_result}.csv";
            using (var file = new StreamWriter($"{directory}\\{fileName}", true, Encoding.ASCII))
                lines.ForEach(file.WriteLine);

            return $"{directory}\\{fileName}";
        }
    }
}
