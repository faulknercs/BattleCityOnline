using BattleCity.GameLib;

namespace BattleCity.DedicatedServer
{
    internal class Message
    {
        public static string newLine = "\n";
        private static string answer;

        public static string welcome()
        {
            return string.Format("Welcome to Battle City Online Server v1.0{0}", newLine);
        }

        public static string help()
        {
            return string.Format("'help' to get list of possible cmd's{0}", newLine);
        }

        public static string helpMode()
        {
            return string.Format("  Usage: set mode <classic|tdmb|tdm|dm>");
        }

        public static string helpList()
        {
            answer = string.Format("Usage: <cmd> [<param1>] [<param2>] ..{0}", newLine);
            for (int i = 0; i < commandList.Length / 2; i++)
                answer += string.Format("  {0} - {1}{2}", commandList[i, 0], commandList[i, 1], newLine);
            return answer;
        }

        public static string getMode()
        {
            return string.Format("Current mode is : {0}{1}", Server.round.Mode.mode, newLine);
        }

        public static string getMap()
        {
            answer = "";
            MapObject[][] map = Server.round.Map.GetInternalForm();
            for (int i = 0; i < 21; i++)
                answer += "X ";
            answer += newLine;
            foreach (MapObject[] mapLine in map)
            {
                answer += "X ";
                foreach (MapObject el in mapLine)
                    if (el.Type.Equals(MapObject.Types.CONCRETE))
                        answer += "X ";
                    else if (el.Type.Equals(MapObject.Types.WATER))
                        answer += "W ";
                    else if (el.Type.Equals(MapObject.Types.BASE))
                        answer += "O ";
                    else
                        answer += "  ";
                answer += "X " + newLine;
            }
            for (int i = 0; i < 21; i++)
                answer += "X ";
            return answer + newLine;
        }

        public static string getPlayerList()
        {
            answer = string.Format("Player count : {0}{1}", Server.round.PlayerList.Count, newLine);
            for (int i = 0; i < Server.round.PlayerList.Count; i++)
                answer += string.Format("{0} - {1}{2}", (i + 1), Server.round.PlayerList[i].Name, newLine);
            return answer;
        }

        public static string getServerIP()
        {
            return string.Format("Server IP : {0}{1}", Server.serverIP, newLine);
        }

        public static string getServerPort()
        {
            return string.Format("Server Port : {0}{1}", Server.serverPort, newLine);
        }

        private static string[,] commandList = new[,]
                                             {
                                                 {"help", "show list of possible cmd's"},
                                                 {"start", "start game with current mode and map"},
                                                 {"stop", "stop game"},
                                                 {"mode","get current mode"},
                                                 {"map","get current map"},
                                                 {"ip","get server ip"},
                                                 {"port","get server port"},
                                                 {"players","get list of connected players"},
                                                 {"set name <name>","set your name (try to choose unique name)"},
                                                 {"set mode <classic|tdmb|tdm|dm>","setting new game mode"},
                                                 {"set map","changing map according to current mode"},
                                                 {"quit", "close console window"}
                                             };
    }
}