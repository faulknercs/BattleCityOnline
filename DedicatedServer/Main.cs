using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using BattleCity.GameLib;
using BattleCity.GameLib.Generators;

namespace BattleCity.DedicatedServer
{
    internal class Server
    {
        private static void Main()
        {
            round = new Round(new GameMode(GameMode.Mode.CLASSIC), new Map(MapGenerator.GenerateMap(GameMode.Mode.CLASSIC)), new List<Player>());
            serverIP = SocketListener.getServerIP();
            serverPort = SocketListener.getServerPort();
            socketListener = new SocketListener();
            cmdThread.Start();
            connectionThread.Start();
        }

        private static Thread cmdThread = new Thread(o => getCmd());
        private static Thread connectionThread = new Thread(o => getConnection());
        private static SocketListener socketListener;

        public static Round round;
        public static IPAddress serverIP;
        public static int serverPort;

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
                        case "connect":
                            connect();
                            break;
                        case "help":
                            Console.Write(Message.helpList());
                            break;
                        case "quit":
                            return "quit";
                        case "start":
                            round.State = true;
                            break;
                        case "stop":
                            round.State = false;
                            break;
                        case "mode":
                            Console.Write(Message.getMode());
                            break;
                        case "map":
                            Console.Write(Message.getMap());
                            break;
                        case "players":
                            Console.Write(Message.getPlayerList());
                            break;
                        case "ip":
                            Console.Write(Message.getServerIP());
                            break;
                        case "port":
                            Console.Write(Message.getServerPort());
                            break;
                        default:
                            Console.Write(Message.help());
                            break;
                    }
                    break;
                case 2:
                    if (cmdParams[0].ToLower().Equals("set") && cmdParams[1].ToLower().Equals("map"))
                    {
                        round.Map = new Map(MapGenerator.GenerateMap(round.Mode.mode));
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
                                        round.Mode = new GameMode(GameMode.Mode.CLASSIC);
                                        round.Map = new Map(MapGenerator.GenerateMap(round.Mode.mode));
                                        break;
                                    case "dm":
                                        round.Mode = new GameMode(GameMode.Mode.DM);
                                        round.Map = new Map(MapGenerator.GenerateMap(round.Mode.mode));
                                        break;
                                    case "tdm":
                                        round.Mode = new GameMode(GameMode.Mode.TDM);
                                        round.Map = new Map(MapGenerator.GenerateMap(round.Mode.mode));
                                        break;
                                    case "tdmb":
                                        round.Mode = new GameMode(GameMode.Mode.TDMB);
                                        round.Map = new Map(MapGenerator.GenerateMap(round.Mode.mode));
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

        #region connectionThreading

        private static void getConnection()
        {
            while (true)
            {
                socketListener.getConnection();
            }
        }

        #endregion connectionThreading

        private static void connect()
        {
            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp); //Создаем основной сокет
            IPEndPoint Addr = new IPEndPoint(serverIP, serverPort); //"localhost" = 127.0.0.1
            s.Connect(Addr); //Коннектимся к срверу
            s.Close();
        }
    }
}