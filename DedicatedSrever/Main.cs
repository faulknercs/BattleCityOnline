using System;

namespace BattleCity.DedicatedSrever
{
    internal class Server
    {
        private static void Main()
        {
            Console.Write(Message.welcome());
            Console.Write(Message.help());
            getCmd();
        }

        private static string localName = "";

        private static void getCmd()
        {
            while (true)
            {
                Console.Write("> ");
                string answer = cmdParser(Console.ReadLine());
                if (answer != null)
                {
                    if (answer.Equals("quit"))
                        break;
                }
            }
        }

        private static string cmdParser(string cmd)
        {
            string[] cmdParams = cmd.Split(' ');
            switch (cmdParams[0].Replace(" ", "").ToLower())
            {
                case "":
                    Console.Write(Message.help());
                    break;
                case "start":
                    Console.Write(Message.error("Cmd is not available now"));
                    break;
                case "help":
                    Console.Write(Message.helpList());
                    break;
                case "hello":
                    Console.Write(Message.hello(localName));
                    break;
                case "name":
                    if (cmdParams.Length > 1 && (cmdParams[1] = cmdParams[1].Replace(" ", "")).Length > 0)
                        localName = cmdParams[1];
                    Console.Write(Message.hello(localName));
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
    }
}