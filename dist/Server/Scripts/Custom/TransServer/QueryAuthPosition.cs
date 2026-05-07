using System;
using System.IO;

namespace Server.Engines.XmlSpawner2
{
    [ Serializable ]
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

    [ Serializable ]
    public class QueryAuthPosition : TransferMessage
    {
        public QueryAuthPosition()
        {
        }

        [ TransferAccess( AccessLevel.Player ) ]
        public override TransferMessage ProcessMessage()
        {
            // prepare log
            string logDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory ?? ".", "Scripts", "Custom", "TransServer");
            string logFile = Path.Combine(logDir, "queryauth.log");
            try { Directory.CreateDirectory(logDir); } catch { }

            TransferServer.AuthEntry auth = TransferServer.GetAuthEntry(this);
            try
            {
                File.AppendAllText(logFile, string.Format("{0} [INFO]: QueryAuthPosition invoked. AuthenticationID={1}{2}", DateTime.Now, this.AuthenticationID, Environment.NewLine));
            }
            catch { }

            if (auth == null || auth.User == null)
            {
                string emsg = "No authentication entry found for this session";
                try { File.AppendAllText(logFile, string.Format("{0} [WARN]: QueryAuthPosition result: ErrorMessage: {1}{2}", DateTime.Now, emsg, Environment.NewLine)); } catch { }
                return new ErrorMessage(emsg);
            }

            try
            {
                int x = auth.User.Location.X;
                int y = auth.User.Location.Y;
                int z = auth.User.Location.Z;
                int map = auth.User.Map.MapID;

                try { File.AppendAllText(logFile, string.Format("{0} [INFO]: QueryAuthPosition result: ReturnAuthPosition X={1} Y={2} Z={3} Map={4} User={5}{6}", DateTime.Now, x, y, z, map, auth.User != null ? auth.User.Name : "<null>", Environment.NewLine)); } catch { }

                return new ReturnAuthPosition(x, y, z, map);
            }
            catch (Exception e)
            {
                string emsg = "Failed to read authenticated player position: " + e.Message;
                try { File.AppendAllText(logFile, string.Format("{0} [ERROR]: QueryAuthPosition exception: {1}{2}", DateTime.Now, emsg, Environment.NewLine)); } catch { }
                return new ErrorMessage(emsg);
            }
        }
    }
}
