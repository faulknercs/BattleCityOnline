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
            map = new Map(MapGenerator.generateMap(mode));
            cmdThread.Start();
        }

        private static Thread cmdThread = new Thread(o => getCmd());
        private static Thread gameThread = new Thread(o => getStarted(mode, map));
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
            switch (cmdParams.Length)
            {
                case 1:
                    switch (cmdParams[0].ToLower())
                    {
                        case "help":
                            Console.Write(Message.helpList());
                            break;
                        case "quit":
                            return "quit";
                        case "start":
                            //start a game
                            break;
                        case "stop":
                            //stop a game
                            break;
                        case "mode":
                            Console.Write(Message.getMode());
                            break;
                        case "map":
                            Console.Write(Message.getMap());
                            break;
                        default:
                            Console.Write(Message.help());
                            break;
                    }
                    break;
                case 2:
                    if (cmdParams[0].ToLower().Equals("set") && cmdParams[1].ToLower().Equals("map"))
                    {
                        map = new Map(MapGenerator.generateMap(mode));
                        Console.Write(Message.getMap());
                    }
                    else
                        Console.Write(Message.help());
                    break;
                case 3:
                    if (cmdParams[0].ToLower().Equals("set"))
                        switch (cmdParams[1].ToLower())
                        {
                            case "mode":
                                switch (cmdParams[2].ToLower())
                                {
                                    case "classic":
                                        mode = new GameMode(GameMode.Mode.CLASSIC);
                                        map = new Map(MapGenerator.generateMap(mode));
                                        break;
                                    case "dm":
                                        mode = new GameMode(GameMode.Mode.DM);
                                        map = new Map(MapGenerator.generateMap(mode));
                                        break;
                                    case "tdm":
                                        mode = new GameMode(GameMode.Mode.TDM);
                                        map = new Map(MapGenerator.generateMap(mode));
                                        break;
                                    case "tdmb":
                                        mode = new GameMode(GameMode.Mode.TDMB);
                                        map = new Map(MapGenerator.generateMap(mode));
                                        break;
                                    default:
                                        Console.Write(Message.help());
                                        break;
                                }
                                break;
                            default:
                                Console.Write(Message.help());
                                break;
                        }
                    break;
                default:
                    Console.Write(Message.help());
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