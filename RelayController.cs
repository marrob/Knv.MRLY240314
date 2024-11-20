using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knv.MRLY240314
{

    public class RelayController
    {
        private readonly byte[] relayBytes;
        private readonly int relayCount = 55 * 8;

        public RelayController()
        {
            if (relayCount <= 0)
                throw new ArgumentException("Relay count must be greater than zero.");


            if (relayCount % 8 != 0)
                throw new ArgumentException("Rely count must be div by 8");

            relayBytes = new byte[relayCount / 8]; // Bájtszám kiszámítása
        }

        // Relé állapot beállítása
        public void SetRelayState(int index, bool state)
        {
            if (index < 0 || index >= relayCount)
                throw new IndexOutOfRangeException($"Relay index {index} is out of range (0-{relayCount - 1}).");

            int byteIndex = index / 8;
            int bitIndex = index % 8;

            if (state)
                relayBytes[byteIndex] |= (byte)(1 << bitIndex); // Bekapcsolás
            else
                relayBytes[byteIndex] &= (byte)~(1 << bitIndex); // Kikapcsolás
        }

        // Relé állapot lekérdezése
        public bool GetRelayState(int index)
        {
            if (index < 0 || index >= relayCount)
                throw new IndexOutOfRangeException($"Relay index {index} is out of range (0-{relayCount - 1}).");

            int byteIndex = index / 8;
            int bitIndex = index % 8;
            return (relayBytes[byteIndex] & (1 << bitIndex)) != 0;
        }

        // Az összes relé állapotának hexa stringgé alakítása
        public string ToHexString()
        {
            return BitConverter.ToString(relayBytes).Replace("-", "");
        }

        // Az összes relé állapotának törlése (alaphelyzetbe állítás)
        public void Reset()
        {
            Array.Clear(relayBytes, 0, relayBytes.Length);
        }
    }
}
