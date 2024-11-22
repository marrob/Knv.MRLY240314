namespace Knv.MRLY240314
{

    /// <summary>
    /// Ventri Instruments Matrix kártyája
    /// </summary>
    static public class E8287aInfo
    {

        public const int RowsCount = 40;
        public const int InstrCount = 24;



        /// <summary>
        /// Minden sorhoz kapcsolódik egy AUX relé, ezek ebben alistában vannak...
        /// </summary>
        public static E8287A[] AuxRows = new E8287A[]
        {
            E8287A.AUX_R1,
            E8287A.AUX_R2,
            E8287A.AUX_R3,
            E8287A.AUX_R4,
            E8287A.AUX_R5,
            E8287A.AUX_R6,
            E8287A.AUX_R7,
            E8287A.AUX_R8,
            E8287A.AUX_R9,
            E8287A.AUX_R10,
            E8287A.AUX_R11,
            E8287A.AUX_R12,
            E8287A.AUX_R13,
            E8287A.AUX_R14,
            E8287A.AUX_R15,
            E8287A.AUX_R16,
            E8287A.AUX_R17,
            E8287A.AUX_R18,
            E8287A.AUX_R19,
            E8287A.AUX_R20,
            E8287A.AUX_R21,
            E8287A.AUX_R22,
            E8287A.AUX_R23,
            E8287A.AUX_R24,
            E8287A.AUX_R25,
            E8287A.AUX_R26,
            E8287A.AUX_R27,
            E8287A.AUX_R28,
            E8287A.AUX_R29,
            E8287A.AUX_R30,
            E8287A.AUX_R31,
            E8287A.AUX_R32,
            E8287A.AUX_R33,
            E8287A.AUX_R34,
            E8287A.AUX_R35,
            E8287A.AUX_R36,
            E8287A.AUX_R37,
            E8287A.AUX_R38,
            E8287A.AUX_R39,
            E8287A.AUX_R40,
        };

        /// <summary>
        /// ABUS1-et kapcsolja a listában szereplő sorokhoz
        /// </summary>
        public static E8287A[] Abus1Rows = new E8287A[] 
        {
            E8287A.AB1_R1,
            E8287A.AB1_R2,
            E8287A.AB1_R3,
            E8287A.AB1_R4,
            E8287A.AB1_R5,
            E8287A.AB1_R6,
            E8287A.AB1_R7,
            E8287A.AB1_R8,
            E8287A.AB1_R9,
            E8287A.AB1_R10,
            E8287A.AB1_R11,
            E8287A.AB1_R12,
            E8287A.AB1_R13,
            E8287A.AB1_R14,
            E8287A.AB1_R15,
            E8287A.AB1_R16,
            E8287A.AB1_R17,
            E8287A.AB1_R18,            
            E8287A.AB1_R19,
            E8287A.AB1_R20,
            E8287A.AB1_R21,
            E8287A.AB1_R22,
            E8287A.AB1_R23,
            E8287A.AB1_R24,
            E8287A.AB1_R25,
            E8287A.AB1_R26,
            E8287A.AB1_R27,
            E8287A.AB1_R28,
            E8287A.AB1_R29,
            E8287A.AB1_R30,          
            E8287A.AB1_R31,
            E8287A.AB1_R32,
            E8287A.AB1_R33,
            E8287A.AB1_R34,
            E8287A.AB1_R35,
            E8287A.AB1_R36,
            E8287A.AB1_R37,
            E8287A.AB1_R38,
            E8287A.AB1_R39,
            E8287A.AB1_R40,
        };

        /// <summary>
        /// ABUS2-et kapcsolja a listában szereplő sorokhoz
        /// </summary>
        public static E8287A[] Abus2Rows = new E8287A[]
        {
            E8287A.AB2_R1,
            E8287A.AB2_R2,
            E8287A.AB2_R3,
            E8287A.AB2_R4,
            E8287A.AB2_R5,
            E8287A.AB2_R6,
            E8287A.AB2_R7,
            E8287A.AB2_R8,
            E8287A.AB2_R9,
            E8287A.AB2_R10,
            E8287A.AB2_R11,
            E8287A.AB2_R12,
            E8287A.AB2_R13,
            E8287A.AB2_R14,
            E8287A.AB2_R15,
            E8287A.AB2_R16,
            E8287A.AB2_R17,
            E8287A.AB2_R18,
            E8287A.AB2_R19,
            E8287A.AB2_R20,
            E8287A.AB2_R21,
            E8287A.AB2_R22,
            E8287A.AB2_R23,
            E8287A.AB2_R24,
            E8287A.AB2_R25,
            E8287A.AB2_R26,
            E8287A.AB2_R27,
            E8287A.AB2_R28,
            E8287A.AB2_R29,
            E8287A.AB2_R30,
            E8287A.AB2_R31,
            E8287A.AB2_R32,
            E8287A.AB2_R33,
            E8287A.AB2_R34,
            E8287A.AB2_R35,
            E8287A.AB2_R36,
            E8287A.AB2_R37,
            E8287A.AB2_R38,
            E8287A.AB2_R39,
            E8287A.AB2_R40,
        };

        /// <summary>
        /// ABUS3-at kapcsolja a listában szereplő sorokhoz
        /// </summary>
        public static E8287A[] Abus3Rows = new E8287A[]
        {
            E8287A.AB3_R1,
            E8287A.AB3_R2,
            E8287A.AB3_R3,
            E8287A.AB3_R4,
            E8287A.AB3_R5,
            E8287A.AB3_R6,
            E8287A.AB3_R7,
            E8287A.AB3_R8,
            E8287A.AB3_R9,
            E8287A.AB3_R10,
            E8287A.AB3_R11,
            E8287A.AB3_R12,
            E8287A.AB3_R13,
            E8287A.AB3_R14,
            E8287A.AB3_R15,
            E8287A.AB3_R16,
            E8287A.AB3_R17,
            E8287A.AB3_R18,
            E8287A.AB3_R19,
            E8287A.AB3_R20,
            E8287A.AB3_R21,
            E8287A.AB3_R22,
            E8287A.AB3_R23,
            E8287A.AB3_R24,
            E8287A.AB3_R25,
            E8287A.AB3_R26,
            E8287A.AB3_R27,
            E8287A.AB3_R28,
            E8287A.AB3_R29,
            E8287A.AB3_R30,
            E8287A.AB3_R31,
            E8287A.AB3_R32,
            E8287A.AB3_R33,
            E8287A.AB3_R34,
            E8287A.AB3_R35,
            E8287A.AB3_R36,
            E8287A.AB3_R37,
            E8287A.AB3_R38,
            E8287A.AB3_R39,
            E8287A.AB3_R40,
        };

        /// <summary>
        /// ABUS4-at kapcsolja a listában szereplő sorokhoz
        /// </summary>
        public static E8287A[] Abus4Rows = new E8287A[]
        {
            E8287A.AB4_R1,
            E8287A.AB4_R2,
            E8287A.AB4_R3,
            E8287A.AB4_R4,
            E8287A.AB4_R5,
            E8287A.AB4_R6,
            E8287A.AB4_R7,
            E8287A.AB4_R8,
            E8287A.AB4_R9,
            E8287A.AB4_R10,
            E8287A.AB4_R11,
            E8287A.AB4_R12,
            E8287A.AB4_R13,
            E8287A.AB4_R14,
            E8287A.AB4_R15,
            E8287A.AB4_R16,
            E8287A.AB4_R17,
            E8287A.AB4_R18,
            E8287A.AB4_R19,
            E8287A.AB4_R20,
            E8287A.AB4_R21,
            E8287A.AB4_R22,
            E8287A.AB4_R23,
            E8287A.AB4_R24,
            E8287A.AB4_R25,
            E8287A.AB4_R26,
            E8287A.AB4_R27,
            E8287A.AB4_R28,
            E8287A.AB4_R29,
            E8287A.AB4_R30,
            E8287A.AB4_R31,
            E8287A.AB4_R32,
            E8287A.AB4_R33,
            E8287A.AB4_R34,
            E8287A.AB4_R35,
            E8287A.AB4_R36,
            E8287A.AB4_R37,
            E8287A.AB4_R38,
            E8287A.AB4_R39,
            E8287A.AB4_R40,
        };

        /// <summary>
        /// ABUS1-et kapcsolja a listában lévő instrument sorhoz
        /// </summary>
        public static E8287A[] Abus1Instr = new E8287A[]
        {
            E8287A.AB1_I1,
            E8287A.AB1_I2,
            E8287A.AB1_I3,
            E8287A.AB1_I4,
            E8287A.AB1_I5,
            E8287A.AB1_I6,
            E8287A.AB1_I7,
            E8287A.AB1_I8,
            E8287A.AB1_I9,
            E8287A.AB1_I10,
            E8287A.AB1_I11,
            E8287A.AB1_I12,
            E8287A.AB1_I13,
            E8287A.AB1_I14,
            E8287A.AB1_I15,
            E8287A.AB1_I16,
            E8287A.AB1_I17,
            E8287A.AB1_I18,
            E8287A.AB1_I19,
            E8287A.AB1_I20,
            E8287A.AB1_I21,
            E8287A.AB1_I22,
            E8287A.AB1_I23,
            E8287A.AB1_I24
        };

        /// <summary>
        /// ABUS2-őt kapcsolja a listában lévő instrument sorhoz
        /// </summary>
        public static E8287A[] Abus2Instr = new E8287A[]
        {
            E8287A.AB2_I1,
            E8287A.AB2_I2,
            E8287A.AB2_I3,
            E8287A.AB2_I4,
            E8287A.AB2_I5,
            E8287A.AB2_I6,
            E8287A.AB2_I7,
            E8287A.AB2_I8,
            E8287A.AB2_I9,
            E8287A.AB2_I10,
            E8287A.AB2_I11,
            E8287A.AB2_I12,
            E8287A.AB2_I13,
            E8287A.AB2_I14,
            E8287A.AB2_I15,
            E8287A.AB2_I16,
            E8287A.AB2_I17,
            E8287A.AB2_I18,
            E8287A.AB2_I19,
            E8287A.AB2_I20,
            E8287A.AB2_I21,
            E8287A.AB2_I22,
            E8287A.AB2_I23,
            E8287A.AB2_I24
        };

        /// <summary>
        /// ABUS3-őt kapcsolja a listában lévő instrument sorhoz
        /// </summary>
        public static E8287A[] Abus3Instr = new E8287A[]
        {
            E8287A.AB3_I1,
            E8287A.AB3_I2,
            E8287A.AB3_I3,
            E8287A.AB3_I4,
            E8287A.AB3_I5,
            E8287A.AB3_I6,
            E8287A.AB3_I7,
            E8287A.AB3_I8,
            E8287A.AB3_I9,
            E8287A.AB3_I10,
            E8287A.AB3_I11,
            E8287A.AB3_I12,
            E8287A.AB3_I13,
            E8287A.AB3_I14,
            E8287A.AB3_I15,
            E8287A.AB3_I16,
            E8287A.AB3_I17,
            E8287A.AB3_I18,
            E8287A.AB3_I19,
            E8287A.AB3_I20,
            E8287A.AB3_I21,
            E8287A.AB3_I22,
            E8287A.AB3_I23,
            E8287A.AB3_I24
        };


        /// <summary>
        /// ABUS4-et kapcsolja a listában lévő instrument sorhoz
        /// </summary>
        public static E8287A[] Abus4Instr = new E8287A[]
        {
            E8287A.AB4_I1,
            E8287A.AB4_I2,
            E8287A.AB4_I3,
            E8287A.AB4_I4,
            E8287A.AB4_I5,
            E8287A.AB4_I6,
            E8287A.AB4_I7,
            E8287A.AB4_I8,
            E8287A.AB4_I9,
            E8287A.AB4_I10,
            E8287A.AB4_I11,
            E8287A.AB4_I12,
            E8287A.AB4_I13,
            E8287A.AB4_I14,
            E8287A.AB4_I15,
            E8287A.AB4_I16,
            E8287A.AB4_I17,
            E8287A.AB4_I18,
            E8287A.AB4_I19,
            E8287A.AB4_I20,
            E8287A.AB4_I21,
            E8287A.AB4_I22,
            E8287A.AB4_I23,
            E8287A.AB4_I24
        };


        /// <summary>
        /// Miden sorhoz tartozik egy Diag relé ami a csatlakozó vagy az ellenállás mérő között vált
        /// Alaphelyzetben a RDG_R[1..40] relék a sort a csatlakozóra kapcsolják.
        /// </summary>
        public static E8287A[] DiagRows = new E8287A[]
        {
            E8287A.RDG_R1,
            E8287A.RDG_R2,
            E8287A.RDG_R3,
            E8287A.RDG_R4,
            E8287A.RDG_R5,
            E8287A.RDG_R6,
            E8287A.RDG_R7,
            E8287A.RDG_R8,
            E8287A.RDG_R9,
            E8287A.RDG_R10,
            E8287A.RDG_R11,
            E8287A.RDG_R12,
            E8287A.RDG_R13,
            E8287A.RDG_R14,
            E8287A.RDG_R15,
            E8287A.RDG_R16,
            E8287A.RDG_R17,
            E8287A.RDG_R18,
            E8287A.RDG_R19,
            E8287A.RDG_R20,
            E8287A.RDG_R21,
            E8287A.RDG_R22,
            E8287A.RDG_R23,
            E8287A.RDG_R24,    
            E8287A.RDG_R25,
            E8287A.RDG_R26,
            E8287A.RDG_R27,
            E8287A.RDG_R28,
            E8287A.RDG_R29,
            E8287A.RDG_R30,
            E8287A.RDG_R31,
            E8287A.RDG_R32,
            E8287A.RDG_R33,
            E8287A.RDG_R34,
            E8287A.RDG_R35,
            E8287A.RDG_R36,
            E8287A.RDG_R37,
            E8287A.RDG_R38,
            E8287A.RDG_R39,
            E8287A.RDG_R40,
        };



        /// <summary>
        /// Miden instrument sorhoz tartozik egy Diag relé ami a csatlakozó vagy az ellenállás mérő között vált
        /// Alaphelyzetben a RDG_I[1..24] relék a sort a csatlakozóra kapcsolják.
        /// </summary>
        public static E8287A[] DiagInstr = new E8287A[]
        {
            E8287A.RDG_I1,
            E8287A.RDG_I2,
            E8287A.RDG_I3,
            E8287A.RDG_I4,
            E8287A.RDG_I5,
            E8287A.RDG_I6,
            E8287A.RDG_I7,
            E8287A.RDG_I8,
            E8287A.RDG_I9,
            E8287A.RDG_I10,
            E8287A.RDG_I11,
            E8287A.RDG_I12,
            E8287A.RDG_I13,
            E8287A.RDG_I14,
            E8287A.RDG_I15,
            E8287A.RDG_I16,
            E8287A.RDG_I17,
            E8287A.RDG_I18,
            E8287A.RDG_I19,
            E8287A.RDG_I20,
            E8287A.RDG_I21,
            E8287A.RDG_I22,
            E8287A.RDG_I23,
            E8287A.RDG_I24
        };

        /// <summary>
        /// 
        /// Minden Aux sorhoz tartozik egy választó relé ami alaphelyzetben a csatalakozóra kapcsolja az Aux reléket.
        /// Aktiválva az ADG_R[1..40]-reléket a diagnosztikai buszhoz kapcsolja 
        /// </summary>
        public static E8287A[] DiagAux = new E8287A[]
        {
            E8287A.ADG_R1,
            E8287A.ADG_R2,
            E8287A.ADG_R3,
            E8287A.ADG_R4,
            E8287A.ADG_R5,
            E8287A.ADG_R6,
            E8287A.ADG_R7,
            E8287A.ADG_R8,
            E8287A.ADG_R9,
            E8287A.ADG_R10,
            E8287A.ADG_R11,
            E8287A.ADG_R12,
            E8287A.ADG_R13,
            E8287A.ADG_R14,
            E8287A.ADG_R15,
            E8287A.ADG_R16,
            E8287A.ADG_R17,
            E8287A.ADG_R18,
            E8287A.ADG_R19,
            E8287A.ADG_R20,
            E8287A.ADG_R21,
            E8287A.ADG_R22,
            E8287A.ADG_R23,
            E8287A.ADG_R24,
            E8287A.ADG_R25,
            E8287A.ADG_R26,
            E8287A.ADG_R27,
            E8287A.ADG_R28,
            E8287A.ADG_R29,
            E8287A.ADG_R30,
            E8287A.ADG_R31,
            E8287A.ADG_R32,
            E8287A.ADG_R33,
            E8287A.ADG_R34,
            E8287A.ADG_R35,
            E8287A.ADG_R36,
            E8287A.ADG_R37,
            E8287A.ADG_R38,
            E8287A.ADG_R39,
            E8287A.ADG_R40,
        };



    }


    /// <summary>
    /// A kárytán szereplő relék címei, az értékek NEM modosíthatóak
    /// 55 * 8 db 
    /// </summary>
    public enum E8287A
    {
        //--- U6 ---
        K8 = 439, //MSB
        K7 = 438,
        K6 = 437,
        K5 = 436,
        K4 = 435,
        K3 = 434,
        K2 = 433,
        K1 = 432, //LSB

        //--- U1_UUT ---
        UUT_I8 = 423,
        UUT_I7 = 422,
        UUT_I6 = 421,
        UUT_I5 = 420,
        UUT_I4 = 419,
        UUT_I3 = 418,
        UUT_I2 = 417,
        UUT_I1 = 416,

        //--- U2_UUT ---
        UUT_I16 = 415,
        UUT_I15 = 414,
        UUT_I14 = 413,
        UUT_I13 = 412,
        UUT_I12 = 411,
        UUT_I11 = 410,
        UUT_I10 = 409,
        UUT_I9 = 408,

        //--- U3_UUT ---
        UUT_I24 = 407,
        UUT_I23 = 406,
        UUT_I22 = 405,
        UUT_I21 = 404,
        UUT_I20 = 403,
        UUT_I19 = 402,
        UUT_I18 = 401,
        UUT_I17 = 400,

        //--- U1_AUX ---
        AUX_R8 = 399,
        AUX_R7 = 398,
        AUX_R6 = 397,
        AUX_R5 = 396,
        AUX_R4 = 395,
        AUX_R3 = 394,
        AUX_R2 = 393,
        AUX_R1 = 392,

        //--- U2_AUX ---
        AUX_R16 = 391,
        AUX_R15 = 390,
        AUX_R14 = 389,
        AUX_R13 = 388,
        AUX_R12 = 387,
        AUX_R11 = 386,
        AUX_R10 = 385,
        AUX_R9 = 384,

        //--- U3_AUX ---
        AUX_R24 = 383,
        AUX_R23 = 382,
        AUX_R22 = 381,
        AUX_R21 = 380,
        AUX_R20 = 379,
        AUX_R19 = 378,
        AUX_R18 = 377,
        AUX_R17 = 376,

        //--- U4_AUX ---
        AUX_R32 = 375,
        AUX_R31 = 374,
        AUX_R30 = 373,
        AUX_R29 = 372,
        AUX_R28 = 371,
        AUX_R27 = 370,
        AUX_R26 = 369,
        AUX_R25 = 368,

        //--- U5_AUX ---
        AUX_R40 = 367,
        AUX_R39 = 366,
        AUX_R38 = 365,
        AUX_R37 = 364,
        AUX_R36 = 363,
        AUX_R35 = 362,
        AUX_R34 = 361,
        AUX_R33 = 360,

        //--- U1_ABI1 ---
        AB1_I8 = 359,
        AB1_I7 = 358,
        AB1_I6 = 357,
        AB1_I5 = 356,
        AB1_I4 = 355,
        AB1_I3 = 354,
        AB1_I2 = 353,
        AB1_I1 = 352,

        //--- U2_ABI1 ---
        AB1_I16 = 351,
        AB1_I15 = 350,
        AB1_I14 = 349,
        AB1_I13 = 348,
        AB1_I12 = 347,
        AB1_I11 = 346,
        AB1_I10 = 345,
        AB1_I9 = 344,

        //--- U3_ABI1 ---
        AB1_I24 = 343,
        AB1_I23 = 342,
        AB1_I22 = 341,
        AB1_I21 = 340,
        AB1_I20 = 339,
        AB1_I19 = 338,
        AB1_I18 = 337,
        AB1_I17 = 336,

        //--- U1_AB1 ---
        AB1_R8 = 335,
        AB1_R7 = 334,
        AB1_R6 = 333, 
        AB1_R5 = 332,
        AB1_R4 = 331,
        AB1_R3 = 330,
        AB1_R2 = 329,
        AB1_R1 = 328,

        //--- U2_AB1 ---
        AB1_R16 = 327,
        AB1_R15 = 326,
        AB1_R14 = 325,
        AB1_R13 = 324,
        AB1_R12 = 323,
        AB1_R11 = 322,
        AB1_R10 = 321,
        AB1_R9 = 320,

        //--- U3_AB1 ---
        AB1_R24 = 319,
        AB1_R23 = 318,
        AB1_R22 = 317,
        AB1_R21 = 316,
        AB1_R20 = 315,
        AB1_R19 = 314,
        AB1_R18 = 313,
        AB1_R17 = 312,

        //--- U4_AB1 ---
        AB1_R32 = 311,
        AB1_R31 = 310,
        AB1_R30 = 309,
        AB1_R29 = 308,
        AB1_R28 = 307,
        AB1_R27 = 306,
        AB1_R26 = 305,
        AB1_R25 = 304,

        //--- U5_AB1 ---
        AB1_R40 = 303,
        AB1_R39 = 302,
        AB1_R38 = 301,
        AB1_R37 = 300,
        AB1_R36 = 299,
        AB1_R35 = 298,
        AB1_R34 = 297,
        AB1_R33 = 296,

        //--- U1_ABI2 ---
        AB2_I8 = 295,
        AB2_I7 = 294,
        AB2_I6 = 293,
        AB2_I5 = 292,
        AB2_I4 = 291,
        AB2_I3 = 290,
        AB2_I2 = 289,
        AB2_I1 = 288,

        //--- U2_ABI2 ---
        AB2_I16 = 287,
        AB2_I15 = 286,
        AB2_I14 = 285,
        AB2_I13 = 284,
        AB2_I12 = 283,
        AB2_I11 = 282,
        AB2_I10 = 281,
        AB2_I9 = 280,

        //--- U3_ABI2 ---
        AB2_I24 = 279,
        AB2_I23 = 278,
        AB2_I22 = 277,
        AB2_I21 = 276,
        AB2_I20 = 275,
        AB2_I19 = 274,
        AB2_I18 = 273,
        AB2_I17 = 272,

        //--- U1_AB2 ---
        AB2_R8 = 271,
        AB2_R7 = 270,
        AB2_R6 = 269,
        AB2_R5 = 268,
        AB2_R4 = 267,
        AB2_R3 = 266,
        AB2_R2 = 265,
        AB2_R1 = 264,

        //--- U2_AB2 ---
        AB2_R16 = 263,
        AB2_R15 = 262,
        AB2_R14 = 261,
        AB2_R13 = 260,
        AB2_R12 = 259,
        AB2_R11 = 258,
        AB2_R10 = 257,
        AB2_R9 = 256,

        //--- U3_AB2 ---
        AB2_R24 = 255,
        AB2_R23 = 254,
        AB2_R22 = 253,
        AB2_R21 = 252,
        AB2_R20 = 251,
        AB2_R19 = 250,
        AB2_R18 = 249,
        AB2_R17 = 248,

        //--- U4_AB2 ---
        AB2_R32 = 247,
        AB2_R31 = 246,
        AB2_R30 = 245,
        AB2_R29 = 244,
        AB2_R28 = 243,
        AB2_R27 = 242,
        AB2_R26 = 241,
        AB2_R25 = 240,

        //--- U5_AB2 ---
        AB2_R40 = 239,
        AB2_R39 = 238,
        AB2_R38 = 237,
        AB2_R37 = 236,
        AB2_R36 = 235,
        AB2_R35 = 234,
        AB2_R34 = 233,
        AB2_R33 = 232,


        //--- U1_ABI3 ---
        AB3_I8 = 231,
        AB3_I7 = 230,
        AB3_I6 = 229,
        AB3_I5 = 228,
        AB3_I4 = 227,
        AB3_I3 = 226,
        AB3_I2 = 225,
        AB3_I1 = 224,

        //--- U2_ABI3 ---
        AB3_I16 = 223,
        AB3_I15 = 222,
        AB3_I14 = 221,
        AB3_I13 = 220,
        AB3_I12 = 219,
        AB3_I11 = 218,
        AB3_I10 = 217,
        AB3_I9 = 216,

        //--- U3_ABI3 ---
        AB3_I24 = 215,
        AB3_I23 = 214,
        AB3_I22 = 213,
        AB3_I21 = 212,
        AB3_I20 = 211,
        AB3_I19 = 210,
        AB3_I18 = 209,
        AB3_I17 = 208,

        //--- U1_AB3 ---
        AB3_R8 = 207,
        AB3_R7 = 206,
        AB3_R6 = 205,
        AB3_R5 = 204,
        AB3_R4 = 203,
        AB3_R3 = 202,
        AB3_R2 = 201,
        AB3_R1 = 200,

        //--- U2_AB3 ---
        AB3_R16 = 199,
        AB3_R15 = 198,
        AB3_R14 = 197,
        AB3_R13 = 196,
        AB3_R12 = 195,
        AB3_R11 = 194,
        AB3_R10 = 193,
        AB3_R9 = 192,

        //--- U3_AB3 ---
        AB3_R24 = 191,
        AB3_R23 = 190,
        AB3_R22 = 189,
        AB3_R21 = 188,
        AB3_R20 = 187,
        AB3_R19 = 186,
        AB3_R18 = 185,
        AB3_R17 = 184,

        //--- U4_AB3 ---
        AB3_R32 = 183,
        AB3_R31 = 182,
        AB3_R30 = 181,
        AB3_R29 = 180,
        AB3_R28 = 179,
        AB3_R27 = 178,
        AB3_R26 = 177,
        AB3_R25 = 176,

        //--- U5_AB3 ---
        AB3_R40 = 175,
        AB3_R39 = 174,
        AB3_R38 = 173,
        AB3_R37 = 172,
        AB3_R36 = 171,
        AB3_R35 = 170,
        AB3_R34 = 169,
        AB3_R33 = 168,


        //--- U1_ABI4 ---
        AB4_I8 = 167,
        AB4_I7 = 166,
        AB4_I6 = 165,
        AB4_I5 = 164,
        AB4_I4 = 163,
        AB4_I3 = 162,
        AB4_I2 = 161,
        AB4_I1 = 160,

        //--- U2_ABI4 ---
        AB4_I16 = 159,
        AB4_I15 = 158,
        AB4_I14 = 157,
        AB4_I13 = 156,
        AB4_I12 = 155,
        AB4_I11 = 154,
        AB4_I10 = 153,
        AB4_I9 = 152,

        //--- U3_ABI4 ---
        AB4_I24 = 151,
        AB4_I23 = 150,
        AB4_I22 = 149,
        AB4_I21 = 148,
        AB4_I20 = 147,
        AB4_I19 = 146,
        AB4_I18 = 145,
        AB4_I17 = 144,

        //--- U1_AB4 ---
        AB4_R8 = 143,
        AB4_R7 = 142,
        AB4_R6 = 141,
        AB4_R5 = 140,
        AB4_R4 = 139,
        AB4_R3 = 138,
        AB4_R2 = 137,
        AB4_R1 = 136,

        //--- U2_AB4 ---
        AB4_R16 = 135,
        AB4_R15 = 134,
        AB4_R14 = 133,
        AB4_R13 = 132,
        AB4_R12 = 131,
        AB4_R11 = 130,
        AB4_R10 = 129,
        AB4_R9 = 128,

        //--- U3_AB4 ---
        AB4_R24 = 127,
        AB4_R23 = 126,
        AB4_R22 = 125,
        AB4_R21 = 124,
        AB4_R20 = 123,
        AB4_R19 = 122,
        AB4_R18 = 121,
        AB4_R17 = 120,

        //--- U4_AB4 ---
        AB4_R32 = 119,
        AB4_R31 = 118,
        AB4_R30 = 117,
        AB4_R29 = 116,
        AB4_R28 = 115,
        AB4_R27 = 114,
        AB4_R26 = 113,
        AB4_R25 = 112,

        //--- U5_AB4 ---
        AB4_R40 = 111,
        AB4_R39 = 110,
        AB4_R38 = 109,
        AB4_R37 = 108,
        AB4_R36 = 107,
        AB4_R35 = 106,
        AB4_R34 = 105,
        AB4_R33 = 104,

        //--- U1_RDGI ---
        RDG_I8 = 103,
        RDG_I7 = 102,
        RDG_I6 = 101,
        RDG_I5 = 100,
        RDG_I4 = 99,
        RDG_I3 = 98,
        RDG_I2 = 97,
        RDG_I1 = 96,

        //--- U2_RDGI ---
        RDG_I16 = 95,
        RDG_I15 = 94,
        RDG_I14 = 93,
        RDG_I13 = 92,
        RDG_I12 = 91,
        RDG_I11 = 90,
        RDG_I10 = 89,
        RDG_I9  = 88,

        //--- U3_RDGI ---
        RDG_I24 = 87,
        RDG_I23 = 86,
        RDG_I22 = 85,
        RDG_I21 = 84,
        RDG_I20 = 83,
        RDG_I19 = 82,
        RDG_I18 = 81,
        RDG_I17 = 80,

        //--- U1_ADG ---
        ADG_R8 = 79,
        ADG_R7 = 78, 
        ADG_R6 = 77,
        ADG_R5 = 76,
        ADG_R4 = 75,
        ADG_R3 = 74,
        ADG_R2 = 73,
        ADG_R1 = 72,

        //--- U2_ADG ---
        ADG_R16 = 71,
        ADG_R15 = 70,
        ADG_R14 = 69,
        ADG_R13 = 68,
        ADG_R12 = 67,
        ADG_R11 = 66,
        ADG_R10 = 65,
        ADG_R9 = 64,

        //--- U3_ADG ---
        ADG_R24 = 63,
        ADG_R23 = 62,
        ADG_R22 = 61, 
        ADG_R21 = 60,
        ADG_R20 = 59,
        ADG_R19 = 58,
        ADG_R18 = 57,
        ADG_R17 = 56,

        //--- U4_ADG ---
        ADG_R32 = 55,
        ADG_R31 = 54,
        ADG_R30 = 53,
        ADG_R29 = 52,
        ADG_R28 = 51,
        ADG_R27 = 50,
        ADG_R26 = 49,
        ADG_R25 = 48,

        //--- U5_ADG ---
        ADG_R40 = 47, 
        ADG_R39 = 46,
        ADG_R38 = 45,
        ADG_R37 = 44,
        ADG_R36 = 43,
        ADG_R35 = 42,
        ADG_R34 = 41,
        ADG_R33 = 40,

        //--- U1_RDG ---
        RDG_R8 = 39,
        RDG_R7 = 38,
        RDG_R6 = 37,
        RDG_R5 = 36,
        RDG_R4 = 35,
        RDG_R3 = 34,
        RDG_R2 = 33,
        RDG_R1 = 32,

        //--- U2_RDG ---
        RDG_R16 = 31,
        RDG_R15 = 30,
        RDG_R14 = 29,
        RDG_R13 = 28,
        RDG_R12 = 27,
        RDG_R11 = 26,
        RDG_R10 = 25,
        RDG_R9 = 24,

        //--- U3_RDG ---
        RDG_R24 = 23,
        RDG_R23 = 22, 
        RDG_R22 = 21,
        RDG_R21 = 20,
        RDG_R20 = 19,
        RDG_R19 = 18,
        RDG_R18 = 17,
        RDG_R17 = 16,

        //--- U4_RDG ---
        RDG_R32 = 15,
        RDG_R31 = 14,
        RDG_R30 = 13,
        RDG_R29 = 12,
        RDG_R28 = 11,
        RDG_R27 = 10,
        RDG_R26 = 9,
        RDG_R25 = 8,

        //--- U5_RDG ---
        RDG_R40 = 7,
        RDG_R39 = 6,
        RDG_R38 = 5,
        RDG_R37 = 4,
        RDG_R36 = 3,
        RDG_R35 = 2,
        RDG_R34 = 1,
        RDG_R33 = 0,
    };
}
