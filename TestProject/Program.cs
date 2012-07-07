using System;
using System.Collections.Generic;

namespace TestProject
{
    internal class Program
    {
        /// <summary>
        /// E - Empty
        /// T - Tank
        /// B - Brick
        /// C - Concrete
        /// W - Water
        /// F - Forest
        /// O - Base
        /// </summary>
        static char[][] map = new char[9][];
        static List<char[][]> staticElements = new List<char[][]>();
        private static Random rnd = new Random();

        private static void Main()
        {
            initialize();
            while (true)
            {
                clearMap(map);

                for (int i = 1; i < map.Length - 1; i++)
                    for (int j = 1; j < map[i].Length - 1; j++)
                    {
                        if (isEmptyBox(map, i, j))
                        {
                            char[][] element = staticElements[rnd.Next(0, staticElements.Count)];
                            int rotationAngle = rnd.Next(0, 5);
                            for (int k = 0; k < rotationAngle; k++)
                                element = rotateElement(element);
                            if (rnd.Next(0, 4) == 0) //should be element be added
                                addConcreteStaticElement(map, element, i, j);
                        }
                    }
                output(map);
                Console.ReadKey();
            }
        }

        private static void addConcreteStaticElement(char[][] map, char[][] element, int x, int y)
        {
            map[x - 1][y - 1] = element[0][0];
            map[x - 1][y] = element[0][1];
            map[x - 1][y + 1] = element[0][2];
            map[x][y - 1] = element[1][0];
            map[x][y] = element[1][1];
            map[x][y + 1] = element[1][2];
            map[x + 1][y - 1] = element[2][0];
            map[x + 1][y] = element[2][1];
            map[x + 1][y + 1] = element[2][2];
        }

        private static char[][] rotateElement(char[][] element)
        {
            char[][] tmp = new[] { new char[3], new char[3], new char[3] };
            for (int i = 0; i < element.Length; i++)
                for (int j = 0; j < element[i].Length; j++)
                    tmp[i][j] = element[2 - j][i];
            return tmp;
        }

        private static bool isEmptyBox(char[][] map, int x, int y)
        {
            if (map[x - 1][y - 1] == 'E' && map[x - 1][y] == 'E' && map[x - 1][y + 1] == 'E')
                if (map[x][y - 1] == 'E' && map[x][y] == 'E' && map[x][y + 1] == 'E')
                    if (map[x + 1][y - 1] == 'E' && map[x + 1][y] == 'E' && map[x + 1][y + 1] == 'E')
                        return true;
            return false;
        }

        #region clearmap output initialize

        private static void initialize()
        {
            //initialize mapInfo
            for (int i = 0; i < map.Length; i++)
                map[i] = new char[10];
            //initialize elementsInfo
            char[][] element = new[]
                                   {
                                       new[]{ 'E','C','C' },
                                       new[]{ 'E','C','E' },
                                       new[]{ 'E','C','E' }
                                   };
            staticElements.Add(element);
            element = new[]
                                   {
                                        new[]{ 'E','E','E' },
                                        new[]{ 'C','C','C' },
                                        new[]{ 'E','E','E' }
                                   };
            staticElements.Add(element);
            element = new[]
                                   {
                                        new[]{ 'E','E','E' },
                                        new[]{ 'E','C','C' },
                                        new[]{ 'E','E','E' }
                                   };
            staticElements.Add(element);
            element = new[]
                                   {
                                        new[]{ 'E','C','E' },
                                        new[]{ 'C','C','C' },
                                        new[]{ 'E','C','E' }
                                   };
            staticElements.Add(element);
            element = new[]
                                   {
                                        new[]{ 'E','E','E' },
                                        new[]{ 'E','C','C' },
                                        new[]{ 'E','C','E' }
                                   };
            staticElements.Add(element);
        }

        private static void clearMap(char[][] map)
        {
            foreach (char[] t in map)
                for (int j = 0; j < t.Length; j++)
                    t[j] = 'E';
        }

        private static void output(char[][] map)
        {
            Console.Clear();
            foreach (char[] t in map)
            {
                foreach (char t1 in t)
                    Console.Write(t1 + " ");
                Console.WriteLine();
            }
        }

        #endregion clearmap output initialize
    }
}