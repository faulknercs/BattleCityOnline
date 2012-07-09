using System;
using System.Collections.Generic;

namespace BattleCity.GameLib
{
    public class MapGenerator
    {
        public MapGenerator()
        {
            objectInit();
        }

        private void objectInit()
        {
            //initialize mapInfo
            for (int i = 0; i < map.Length; i++)
                map[i] = new char[19];
            //initialize elementsInfo
            char[][] element = new[]
                                   {
                                       new[]{ 'E','C','C' },
                                       new[]{ 'E','C','E' },
                                       new[]{ 'E','C','E' }
                                   };
            listOfStaticElements.Add(element);
            element = new[]
                                   {
                                        new[]{ 'E','E','E' },
                                        new[]{ 'C','C','C' },
                                        new[]{ 'E','E','E' }
                                   };
            listOfStaticElements.Add(element);
            element = new[]
                                   {
                                        new[]{ 'E','E','E' },
                                        new[]{ 'E','C','C' },
                                        new[]{ 'E','E','E' }
                                   };
            listOfStaticElements.Add(element);
            element = new[]
                                   {
                                        new[]{ 'E','C','E' },
                                        new[]{ 'C','C','C' },
                                        new[]{ 'E','C','E' }
                                   };
            listOfStaticElements.Add(element);
            element = new[]
                                   {
                                        new[]{ 'E','E','E' },
                                        new[]{ 'E','C','C' },
                                        new[]{ 'E','C','E' }
                                   };
            listOfStaticElements.Add(element);
        }

        /// <summary>
        /// E - Empty
        /// T - Tank
        /// B - Brick
        /// C - Concrete
        /// W - Water
        /// F - Forest
        /// O - Base
        /// </summary>

        MapObject[][] map = new MapObject[20][];
        static List<char[][]> listOfStaticElements = new List<char[][]>();
        static Random rnd = new Random();

        #region Map Generator By Mode

        /// <summary>
        /// Classical mode (one team defends its base, another one attacks trying to destroy the base)
        /// </summary>
        public MapObject[][] generateCLASSIC_Map()
        {
            while (true)
            {
                makeConcreteMap();

                //clearing space for base
                map[0][9] = 'E';

                if (rnd.Next(0, 2) == 0) addWaterOnMap(); //Water on map 50%
                if (isMapGood()) break;
            }
            //adding base
            map[0][9] = 'O';
            //adding bricks
            if (map[0][9 - 1].Equals('E')) map[0][9 - 1] = 'B';
            if (map[0][9 + 1].Equals('E')) map[0][9 + 1] = 'B';
            for (int i = 8; i <= 10; i++) if (map[1][i].Equals('E')) map[1][i] = 'B';
            addBricksOnMap();
            addForestOnMap();
            return map;
        }

        /// <summary>
        /// Team deathmatch (two teams attacking each other) without bases
        /// </summary>
        public MapObject[][] generateTDM_Map()
        {
            while (true)
            {
                makeConcreteMap();

                if (rnd.Next(0, 2) == 0) addWaterOnMap(); //Water on map 50%
                if (isMapGood()) break;
            }
            addBricksOnMap();
            addForestOnMap();
            return map;
        }

        /// <summary>
        /// Team deathmatch with bases (both teams have their own base)
        /// </summary>
        public MapObject[][] generateTDMB_Map()
        {
            while (true)
            {
                makeConcreteMap();

                //clearing space for base
                map[0][9] = 'E';
                map[19][9] = 'E';

                if (rnd.Next(0, 2) == 0) addWaterOnMap(); //Water on map 50%
                if (isMapGood()) break;
            }
            //adding base
            map[0][9] = 'O';
            map[19][9] = 'O';

            //adding bricks
            if (map[0][9 - 1].Equals('E')) map[0][9 - 1] = 'B';
            if (map[0][9 + 1].Equals('E')) map[0][9 + 1] = 'B';
            if (map[19][9 - 1].Equals('E')) map[19][9 - 1] = 'B';
            if (map[19][9 + 1].Equals('E')) map[19][9 + 1] = 'B';
            for (int i = 8; i <= 10; i++)
            {
                if (map[1][i].Equals('E')) map[1][i] = 'B';
                if (map[18][i].Equals('E')) map[18][i] = 'B';
            }
            addBricksOnMap();
            addForestOnMap();
            return map;
        }

        /// <summary>
        /// Deathmatch (every player fights for himself) without bases
        /// </summary>
        public MapObject[][] generateDM_Map()
        {
            while (true)
            {
                makeConcreteMap();

                if (rnd.Next(0, 2) == 0) addWaterOnMap(); //Water on map 50%
                if (isMapGood()) break;
            }
            addBricksOnMap();
            addForestOnMap();
            return map;
        }

        #endregion Map Generator By Mode

        #region Methods

        /// <summary>
        /// Is element proper to current position
        /// </summary>
        /// <param name="map">Current Map</param>
        /// <param name="x">Current X</param>
        /// <param name="y">Current Y</param>
        /// <returns>true - map is good</returns>
        private bool isEmptyBox(char[][] map, int x, int y)
        {
            if (map[x - 1][y - 1] == 'E' && map[x - 1][y] == 'E' && map[x - 1][y + 1] == 'E')
                if (map[x][y - 1] == 'E' && map[x][y] == 'E' && map[x][y + 1] == 'E')
                    if (map[x + 1][y - 1] == 'E' && map[x + 1][y] == 'E' && map[x + 1][y + 1] == 'E')
                        return true;
            return false;
        }

        private bool isMapGood()
        {
            bool foundEmpty = true;
            const char check = 'T';
            //initialize
            char[][] tmpMap = new char[22][];
            for (int i = 0; i < tmpMap.Length; i++)
                tmpMap[i] = new char[21];
            //Setting each element to 'c'
            foreach (char[] t in tmpMap)
                for (int j = 0; j < t.Length; j++)
                    t[j] = 'C';
            //Adding map to tmpMap
            for (int i = 0; i < map.Length; i++)
                for (int j = 0; j < map[i].Length; j++)
                    tmpMap[i + 1][j + 1] = map[i][j];

            //Check if 'C' in middle line
            bool concreteBreak = false;
            for (int i = 1; i < tmpMap.Length - 1; i++)
            {
                if (tmpMap[i][10].Equals('C'))
                    concreteBreak = true;
            }
            if (!concreteBreak)
                return false;
            //Check Concrete blocks count
            int concreteCount = 0;
            for (int i = 1; i <= 9; i++)
                for (int j = 1; j <= 10; j++)
                    if (tmpMap[i][j].Equals('C'))
                        concreteCount++;
            if (concreteCount < 25 || concreteCount > 35)
                return false;

            //Getting random element with 'E'
            int x = rnd.Next(5, 16);
            int y = rnd.Next(5, 16);
            if (!tmpMap[x][y].Equals('E'))
                while (!tmpMap[x][y].Equals('E'))
                {
                    x = rnd.Next(0, 20);
                    y = rnd.Next(0, 21);
                }
            tmpMap[x][y] = check;
            //Setting to check every Close 'E' to check, added before
            while (foundEmpty)
            {
                foundEmpty = false;
                for (int i = 1; i < tmpMap.Length - 1; i++)
                {
                    for (int j = 1; j < tmpMap[i].Length - 1; j++)
                    {
                        if (tmpMap[i][j].Equals(check))
                        {
                            if (tmpMap[i - 1][j].Equals('E'))
                            {
                                tmpMap[i - 1][j] = check;
                                foundEmpty = true;
                            }
                            if (tmpMap[i + 1][j].Equals('E'))
                            {
                                tmpMap[i + 1][j] = check;
                                foundEmpty = true;
                            }
                            if (tmpMap[i][j - 1].Equals('E'))
                            {
                                tmpMap[i][j - 1] = check;
                                foundEmpty = true;
                            }
                            if (tmpMap[i][j + 1].Equals('E'))
                            {
                                tmpMap[i][j + 1] = check;
                                foundEmpty = true;
                            }
                        }
                    }
                }
            }
            foreach (char[] t in tmpMap)
                for (int j = 0; j < t.Length; j++)
                {
                    if (t[j].Equals('E'))
                        foundEmpty = true;
                }
            return !foundEmpty;
        }

        #region ADD : CONCRETE | BRICK | WATER | FOREST

        private void makeConcreteMap()
        {
            MapObject[][] partMap = new MapObject[10][];
            MapObject[][] halfMap = new MapObject[20][];
            for (int i = 0; i < partMap.Length; i++)
                partMap[i] = new MapObject[9];
            for (int i = 0; i < halfMap.Length; i++)
                halfMap[i] = new MapObject[9];

            //"clear" map
            for (int i = 0; i < partMap.Length; i++)
                for (int j = 0; j < partMap[i].Length; j++)
                {
                    partMap[i][j] = MapObject.Types.EMPTY;
                }

            #region Fill part of a map (1/4)

            for (int i = 1; i < partMap.Length - 1; i++)
                for (int j = 1; j < partMap[i].Length - 1; j++)
                    if (isEmptyBox(partMap, i, j))
                        if (rnd.Next(0, 4) == 0) //should be element be added
                        {
                            char[][] element = getRandomElementFromListOfStaticElements();
                            addConcreteStaticElementOnMap(partMap, element, i, j);
                        }

            #endregion Fill part of a map (1/4)

            #region Mirror of a part map (1/2) (LEFT PART OF MAP)

            for (int i = 0; i < partMap.Length; i++)
                for (int j = 0; j < partMap[i].Length; j++)
                {
                    halfMap[i][j] = partMap[i][j];
                    halfMap[halfMap.Length - 1 - i][j] = partMap[i][j];
                }

            #endregion Mirror of a part map (1/2) (LEFT PART OF MAP)

            #region Mirror of a part map (2/2) (FULL MAP)

            for (int i = 0; i < halfMap.Length; i++)
                for (int j = 0; j < halfMap[i].Length; j++)
                {
                    map[i][j] = halfMap[i][j];
                    map[i][map[i].Length - 1 - j] = halfMap[i][j];
                }

            #endregion Mirror of a part map (2/2) (FULL MAP)

            //adding middle line
            foreach (char[] t in map)
                t[9] = t[8].Equals('C') ? 'C' : 'E';
        }

        private void addConcreteStaticElementOnMap(char[][] map, char[][] element, int x, int y)
        {
            for (int i = 0; i < element.Length; i++)
                for (int j = 0; j < element[i].Length; j++)
                    map[x - 1 + i][y - 1 + j] = element[i][j];
        }

        private void addBricksOnMap()
        {
            for (int i = 0; i < map.Length; i++)
                for (int j = 0; j < map[i].Length; j++)
                    if (map[i][j].Equals('E') && rnd.Next(0, 4) == 0) //30% of Brick
                        map[i][j] = 'B';
        }

        private void addForestOnMap()
        {
            for (int i = 0; i < map.Length; i++)
                for (int j = 0; j < map[i].Length; j++)
                    if (map[i][j].Equals('E') && rnd.Next(0, 5) == 0)
                        map[i][j] = 'F';
        }

        private void addWaterOnMap()
        {
            for (int i = 0; i < map.Length; i++)
                for (int j = 0; j < map[i].Length; j++)
                    if (map[i][j].Equals('E') && rnd.Next(0, 16) == 0)
                        map[i][j] = 'W';
        }

        #endregion ADD : CONCRETE | BRICK | WATER | FOREST

        #region Element By Random

        private char[][] getRandomElementFromListOfStaticElements()
        {
            char[][] element = listOfStaticElements[rnd.Next(0, listOfStaticElements.Count)];
            int rotationAngle = rnd.Next(0, 5);
            for (int k = 0; k < rotationAngle; k++)
                element = rotateStaticElement(element);
            return element;
        }

        private char[][] rotateStaticElement(char[][] element)
        {
            char[][] tmp = new[] { new char[3], new char[3], new char[3] };
            for (int i = 0; i < element.Length; i++)
                for (int j = 0; j < element[i].Length; j++)
                    tmp[i][j] = element[2 - j][i];
            return tmp;
        }

        #endregion Element By Random

        #endregion Methods
    }
}