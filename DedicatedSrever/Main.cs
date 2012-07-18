using System;
using System.Threading;
using BattleCity.GameLib;

namespace BattleCity.DedicatedSrever
{
    internal class Server
    {
        private static void Main()
        {
            mode = new GameMode(GameMode.Mode.CLASSIC);
            map = new Map(MapGenerator.generateCLASSIC_Map());
            cmdThread.Start();
        }

        private static Thread cmdThread = new Thread(o => getCmd());
        private static Thread gameThread = new Thread(o => getStarted(mode, map));
        public static string localName = "";
        public static GameMode mode;
        public static Map map;
        public static bool start;

        #region cmdThreading

        public static void getCmd()
        {
            Console.Write(Message.welcome());
            Console.Write(Message.help());
            while (true)
            {
                Console.Write("> ");
                string answer = cmdParser(Console.ReadLine());
                if (answer != null)
                    if (answer.Equals("quit"))
                        break;
            }
        }

        private static string cmdParser(string cmd)
        {
            string[] cmdParams = cmd.Split(' ');
            switch (cmdParams[0].Replace(" ", "").ToLower())
            {
                case "help":
                    Console.Write(Message.helpList());
                    break;
                case "hello":
                    Console.Write(Message.hello(localName));
                    break;
                case "start":
                    if (!start)
                    {
                        start = true;
                    }
                    break;
                case "stop":
                    if (start)
                    {
                        start = false;
                    }
                    break;
                case "set":
                    if (cmdParams.Length > 1 && (cmdParams[1] = cmdParams[1].Replace(" ", "")).Length > 0)
                        switch (cmdParams[1].Replace(" ", "").ToLower())
                        {
                            case "name":
                                if (cmdParams.Length > 2 && (cmdParams[2] = cmdParams[2].Replace(" ", "")).Length > 0)
                                {
                                    localName = cmdParams[2];
                                    Console.Write(Message.hello(localName));
                                }
                                break;
                            case "mode":
                                switch (cmdParams[2].Replace(" ", "").ToLower())
                                {
                                    case "classic":
                                        mode = new GameMode(GameMode.Mode.CLASSIC);
                                        map = new Map(MapGenerator.generateCLASSIC_Map());
                                        break;
                                    case "dm":
                                        mode = new GameMode(GameMode.Mode.DM);
                                        map = new Map(MapGenerator.generateDM_Map());
                                        break;
                                    case "tdm":
                                        mode = new GameMode(GameMode.Mode.TDM);
                                        map = new Map(MapGenerator.generateTDM_Map());
                                        break;
                                    case "tdmb":
                                        mode = new GameMode(GameMode.Mode.TDMB);
                                        map = new Map(MapGenerator.generateTDMB_Map());
                                        break;
                                }
                                Console.Write(Message.mode());
                                break;
                            case "map":
                                Console.Write(Message.map());
                                break;
                            default:
                                Console.Write(string.Format("{0}{1}",
                                                            Message.error("No such cmd."),
                                                            Message.help()));
                                break;
                        }
                    break;
                case "get":
                    if (cmdParams.Length > 1 && (cmdParams[1] = cmdParams[1].Replace(" ", "")).Length > 0)
                        switch (cmdParams[1].Replace(" ", "").ToLower())
                        {
                            case "name":
                                Console.Write(Message.hello(localName));
                                break;
                            case "mode":
                                Console.Write(!mode.Equals(null) ? Message.mode() : Message.error("Mode is not setted"));
                                break;
                            case "map":
                                Console.Write(!map.Equals(null) ? Message.map() : Message.error("Set mode before"));
                                break;
                            default:
                                Console.Write(string.Format("{0}{1}",
                                                            Message.error("No such cmd."),
                                                            Message.help()));
                                break;
                        }
                    break;
                case "quit":
                    return "quit";
                default:
                    Console.Write(string.Format("{0}{1}",
                                                Message.error("No such cmd."),
                                                Message.help()));
                    break;
            }
            return null;
        }

        #endregion cmdThreading

        #region gameThreding

        private static void getStarted(GameMode mode, Map map)
        {
        }

        #endregion gameThreding
    }
}