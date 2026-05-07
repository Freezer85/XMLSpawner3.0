using System;

namespace Server.Engines.XmlSpawner2
{
    [Serializable]
    public class QueryAuthPosition : TransferMessage
    {
        // Flag per attivare/disattivare i log (default: disattivato)
        public static bool EnableLogs = false;

        public QueryAuthPosition()
        {
        }

        // Helper per logging controllato dal flag EnableLogs
        public static void Log(string message)
        {
            if (EnableLogs)
            {
                Console.WriteLine("[QueryAuthPosition] " + message);
            }
        }
    }

    [Serializable]
    public class ReturnAuthPosition : TransferMessage
    {
        public int X;
        public int Y;
        public int Z;
        public int Map;

        public ReturnAuthPosition()
        {
        }

        public ReturnAuthPosition(int x, int y, int z, int map)
        {
            X = x; Y = y; Z = z; Map = map;
        }
    }
}
