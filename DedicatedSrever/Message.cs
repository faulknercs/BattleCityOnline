using BattleCity.GameLib;

namespace BattleCity.DedicatedSrever
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

        public static string helpList()
        {
            answer = string.Format("Usage: <cmd> [<param1>] [<param2>] ..{0}", newLine);
            for (int i = 0; i < commandList.Length / 2; i++)
                answer += string.Format("  {0} - {1}{2}", commandList[i, 0], commandList[i, 1], newLine);
            return answer;
        }

        public static string mode()
        {
            return string.Format("Current mode is : {0}{1}", Server.mode.mode, newLine);
        }

        public static string map()
        {
            answer = "";
            MapObject[][] map = Server.map.GetInternalForm();
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

        private static string[,] commandList = new[,]
                                             {
                                                 {"help", "show list of possible cmd's"},
                                                 {"hello", "great the server"},
                                                 {"quit", "close console window"},
                                                 {"start", "start game with current mode and map"},
                                                 {"stop", "stop game"},
                                                 {"set name <name>","set your name (try to choose unique name)"},
                                                 {"set mode 'classic'|'tdmb'|'tdm'|'dm'","setting new game mode"},
                                                 {"set map","chaging map according to current mode"},
                                                 {"get name","get your name"},
                                                 {"get mode","get current mode"},
                                                 {"get map","get current map"}
                                             };

        public static string hello(string name)
        {
            return name == ""
                ? string.Format("Who the hell are you?!{0}", newLine)
                : string.Format("Yea, HI, {0}! Welcome!{1}", name, newLine);
        }

        public static string error(string e)
        {
            return string.Format("Error: {0}{1}", e, newLine);
        }
    }
}