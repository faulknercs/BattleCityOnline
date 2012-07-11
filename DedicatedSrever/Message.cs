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

        private static string[,] commandList = new[,]
                                             {
                                                 {"help", "show list of possible cmd's"},
                                                 {"start", "open BCO game window"},
                                                 {"quit", "close console window"},
                                                 {"name","get your name"},
                                                 {"name <name>","set your name (try to choose unique name)"}
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