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

        static char[][] partMap = new char[10][];
        static char[][] halfMap = new char[20][];

        static List<char[][]> staticElements = new List<char[][]>();
        private static Random rnd = new Random();

        private static void Main()
        {
            initialize();
            while (true)
            {
                clearMap(partMap);

                //Fill part of a map (1/4)
                for (int i = 1; i < partMap.Length - 1; i++)
                    for (int j = 1; j < partMap[i].Length - 1; j++)
                        if (isEmptyBox(partMap, i, j))
                            if (rnd.Next(0, 4) == 0) //should be element be added
                            {
                                char[][] element = getRandomElementToAddOnMap();
                                addConcreteStaticElementOnMap(partMap, element, i, j);
                            }
                //Mirror of a part map (1/2) (LEFT PART OF MAP)
                for (int i = 0; i < partMap.Length; i++)
                    for (int j = 0; j < partMap[i].Length; j++)
                    {
                        halfMap[i][j] = partMap[i][j];
                        halfMap[halfMap.Length - 1 - i][j] = partMap[i][j];
                    }
                output(halfMap);
                Console.ReadKey();
            }
        }

        private static char[][] getRandomElementToAddOnMap()
        {
            char[][] element = staticElements[rnd.Next(0, staticElements.Count)];
            int rotationAngle = rnd.Next(0, 5);
            for (int k = 0; k < rotationAngle; k++)
                element = rotateStaticElement(element);
            return element;
        }

        private static void addConcreteStaticElementOnMap(char[][] map, char[][] element, int x, int y)
        {
            for (int i = 0; i < element.Length; i++)
                for (int j = 0; j < element[i].Length; j++)
                    map[x - 1 + i][y - 1 + j] = element[i][j];
        }

        private static char[][] rotateStaticElement(char[][] element)
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
            for (int i = 0; i < partMap.Length; i++)
                partMap[i] = new char[9];
            for (int i = 0; i < halfMap.Length; i++)
                halfMap[i] = new char[9];
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