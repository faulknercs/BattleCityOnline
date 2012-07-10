using System;
using System.Collections.Generic;
using System.Linq;

namespace BattleCity.GameLib
{
    public class MapGenerator
    {
        public MapGenerator()
        { objectInit(); }

        private void objectInit()
        {
            for (int i = 0; i < map.Length; i++) //initialize mapInfo
                map[i] = new MapObject[19];
            MapObject[][] element = new[] //initialize elementsInfo
                                        {
                                            new[]
                                                {
                                                    new MapObject(0, 0, MapObject.Types.EMPTY),
                                                    new MapObject(0, 1, MapObject.Types.CONCRETE),
                                                    new MapObject(0, 2, MapObject.Types.CONCRETE)
                                                },
                                            new[]
                                                {
                                                    new MapObject(1, 0, MapObject.Types.EMPTY),
                                                    new MapObject(1, 1, MapObject.Types.CONCRETE),
                                                    new MapObject(1, 2, MapObject.Types.EMPTY)
                                                },
                                            new[]
                                                {
                                                    new MapObject(2, 0, MapObject.Types.EMPTY),
                                                    new MapObject(2, 1, MapObject.Types.CONCRETE),
                                                    new MapObject(2, 2, MapObject.Types.EMPTY)
                                                }
                                        };
            listOfStaticElements.Add(element);
            element = new[]
                                   {
                                            new[]
                                                {
                                                    new MapObject(0, 0, MapObject.Types.EMPTY),
                                                    new MapObject(0, 1, MapObject.Types.EMPTY),
                                                    new MapObject(0, 2, MapObject.Types.EMPTY)
                                                },
                                            new[]
                                                {
                                                    new MapObject(1, 0, MapObject.Types.CONCRETE),
                                                    new MapObject(1, 1, MapObject.Types.CONCRETE),
                                                    new MapObject(1, 2, MapObject.Types.CONCRETE)
                                                },
                                            new[]
                                                {
                                                    new MapObject(2, 0, MapObject.Types.EMPTY),
                                                    new MapObject(2, 1, MapObject.Types.EMPTY),
                                                    new MapObject(2, 2, MapObject.Types.EMPTY)
                                                }
                                   };
            listOfStaticElements.Add(element);
            element = new[]
                                   {
                                            new[]
                                                {
                                                    new MapObject(0, 0, MapObject.Types.EMPTY),
                                                    new MapObject(0, 1, MapObject.Types.EMPTY),
                                                    new MapObject(0, 2, MapObject.Types.EMPTY)
                                                },
                                            new[]
                                                {
                                                    new MapObject(1, 0, MapObject.Types.EMPTY),
                                                    new MapObject(1, 1, MapObject.Types.CONCRETE),
                                                    new MapObject(1, 2, MapObject.Types.CONCRETE)
                                                },
                                            new[]
                                                {
                                                    new MapObject(2, 0, MapObject.Types.EMPTY),
                                                    new MapObject(2, 1, MapObject.Types.EMPTY),
                                                    new MapObject(2, 2, MapObject.Types.EMPTY)
                                                }
                                   };
            listOfStaticElements.Add(element);
            element = new[]
                                   {
                                            new[]
                                                {
                                                    new MapObject(0, 0, MapObject.Types.EMPTY),
                                                    new MapObject(0, 1, MapObject.Types.CONCRETE),
                                                    new MapObject(0, 2, MapObject.Types.EMPTY)
                                                },
                                            new[]
                                                {
                                                    new MapObject(1, 0, MapObject.Types.CONCRETE),
                                                    new MapObject(1, 1, MapObject.Types.CONCRETE),
                                                    new MapObject(1, 2, MapObject.Types.CONCRETE)
                                                },
                                            new[]
                                                {
                                                    new MapObject(2, 0, MapObject.Types.EMPTY),
                                                    new MapObject(2, 1, MapObject.Types.CONCRETE),
                                                    new MapObject(2, 2, MapObject.Types.EMPTY)
                                                }
                                   };
            listOfStaticElements.Add(element);
            element = new[]
                                   {
                                            new[]
                                                {
                                                    new MapObject(0, 0, MapObject.Types.EMPTY),
                                                    new MapObject(0, 1, MapObject.Types.EMPTY),
                                                    new MapObject(0, 2, MapObject.Types.EMPTY)
                                                },
                                            new[]
                                                {
                                                    new MapObject(1, 0, MapObject.Types.EMPTY),
                                                    new MapObject(1, 1, MapObject.Types.CONCRETE),
                                                    new MapObject(1, 2, MapObject.Types.CONCRETE)
                                                },
                                            new[]
                                                {
                                                    new MapObject(2, 0, MapObject.Types.EMPTY),
                                                    new MapObject(2, 1, MapObject.Types.CONCRETE),
                                                    new MapObject(2, 2, MapObject.Types.EMPTY)
                                                }
                                   };
            listOfStaticElements.Add(element);
        }

        MapObject[][] map = new MapObject[20][];
        static List<MapObject[][]> listOfStaticElements = new List<MapObject[][]>();
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
                map[0][9] = new MapObject(0, 9, MapObject.Types.EMPTY);

                if (rnd.Next(0, 2).Equals(0)) addWaterOnMap(); //Water on map 50%
                if (isMapGood()) break;
            }
            //adding base
            map[0][9] = new MapObject(0, 9, MapObject.Types.BASE);
            //adding bricks
            map[0][9 - 1] = new MapObject(0, 9 - 1, MapObject.Types.BRICK);
            map[0][9 + 1] = new MapObject(0, 9 + 1, MapObject.Types.BRICK);
            for (int i = 8; i <= 10; i++)
                map[1][i] = new MapObject(1, i, MapObject.Types.BRICK);
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

                if (rnd.Next(0, 2).Equals(0)) addWaterOnMap(); //Water on map 50%
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
                map[0][9] = new MapObject(0, 9, MapObject.Types.EMPTY);
                map[19][9] = new MapObject(19, 9, MapObject.Types.EMPTY);

                if (rnd.Next(0, 2).Equals(0)) addWaterOnMap(); //Water on map 50%
                if (isMapGood()) break;
            }
            //adding base
            map[0][9] = new MapObject(0, 9, MapObject.Types.BASE);
            map[19][9] = new MapObject(19, 9, MapObject.Types.BASE);

            //adding bricks
            map[0][9 - 1] = new MapObject(0, 9 - 1, MapObject.Types.BRICK);
            map[0][9 + 1] = new MapObject(0, 9 + 1, MapObject.Types.BRICK);
            map[19][9 - 1] = new MapObject(19, 9 - 1, MapObject.Types.BRICK);
            map[19][9 + 1] = new MapObject(19, 9 + 1, MapObject.Types.BRICK);
            for (int i = 8; i <= 10; i++)
            {
                map[1][i] = new MapObject(1, i, MapObject.Types.BRICK);
                map[18][i] = new MapObject(18, 1, MapObject.Types.BRICK);
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

                if (rnd.Next(0, 2).Equals(0)) addWaterOnMap(); //Water on map 50%
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
        private bool isEmptyBox(MapObject[][] map, int x, int y)
        {
            if (map[x - 1][y - 1].Type.Equals(MapObject.Types.EMPTY) && map[x - 1][y].Type.Equals(MapObject.Types.EMPTY) && map[x - 1][y + 1].Type.Equals(MapObject.Types.EMPTY))
                if (map[x][y - 1].Type.Equals(MapObject.Types.EMPTY) && map[x][y].Type.Equals(MapObject.Types.EMPTY) && map[x][y + 1].Type.Equals(MapObject.Types.EMPTY))
                    if (map[x + 1][y - 1].Type.Equals(MapObject.Types.EMPTY) && map[x + 1][y].Type.Equals(MapObject.Types.EMPTY) && map[x + 1][y + 1].Type.Equals(MapObject.Types.EMPTY))
                        return true;
            return false;
        }

        private bool isMapGood()
        {
            //initialize
            MapObject[][] tmpMap = new MapObject[22][];
            for (int i = 0; i < tmpMap.Length; i++)
                tmpMap[i] = new MapObject[21];
            //Setting each element to 'c'
            for (int i = 0; i < tmpMap.Length; i++)
                for (int j = 0; j < tmpMap[i].Length; j++)
                    tmpMap[i][j] = new MapObject(i, j, MapObject.Types.CONCRETE);

            //Adding map to tmpMap
            for (int i = 0; i < map.Length; i++)
                for (int j = 0; j < map[i].Length; j++)
                    tmpMap[i + 1][j + 1] = new MapObject(i + 1, j + 1, map[i][j].Type);

            //Check if 'C' in middle line
            bool concreteBreak = false;
            for (int i = 3; i < tmpMap.Length - 3; i++)
            {
                if (tmpMap[i][10].Type.Equals(MapObject.Types.CONCRETE))
                    concreteBreak = true;
            }
            if (!concreteBreak)
                return false;
            //Check Concrete blocks count
            int concreteCount = 0;
            for (int i = 1; i <= 9; i++)
                for (int j = 1; j <= 10; j++)
                    if (tmpMap[i][j].Type.Equals(MapObject.Types.CONCRETE))
                        concreteCount++;
            if (concreteCount < 25 || concreteCount > 35)
                return false;

            //Getting random element with 'E'
            int x = rnd.Next(5, 16);
            int y = rnd.Next(5, 16);
            if (!tmpMap[x][y].Type.Equals(MapObject.Types.EMPTY))
                while (!tmpMap[x][y].Type.Equals(MapObject.Types.EMPTY))
                {
                    x = rnd.Next(0, 20);
                    y = rnd.Next(0, 21);
                }
            tmpMap[x][y].Type = MapObject.Types.TEMPORARY;
            //Setting to check every Close 'E' to check, added before
            bool foundEmpty = true;
            while (foundEmpty)
            {
                foundEmpty = false;
                for (int i = 1; i < tmpMap.Length - 1; i++)
                    for (int j = 1; j < tmpMap[i].Length - 1; j++)
                        if (tmpMap[i][j].Type.Equals(MapObject.Types.TEMPORARY))
                        {
                            if (tmpMap[i - 1][j].Type.Equals(MapObject.Types.EMPTY))
                            {
                                tmpMap[i - 1][j].Type = MapObject.Types.TEMPORARY;
                                foundEmpty = true;
                            }
                            if (tmpMap[i + 1][j].Type.Equals(MapObject.Types.EMPTY))
                            {
                                tmpMap[i + 1][j].Type = MapObject.Types.TEMPORARY;
                                foundEmpty = true;
                            }
                            if (tmpMap[i][j - 1].Type.Equals(MapObject.Types.EMPTY))
                            {
                                tmpMap[i][j - 1].Type = MapObject.Types.TEMPORARY;
                                foundEmpty = true;
                            }
                            if (tmpMap[i][j + 1].Type.Equals(MapObject.Types.EMPTY))
                            {
                                tmpMap[i][j + 1].Type = MapObject.Types.TEMPORARY;
                                foundEmpty = true;
                            }
                        }
            }
            foreach (MapObject[] t in tmpMap)
                foreach (MapObject t1 in t)
                    if (t1.Type.Equals(MapObject.Types.EMPTY))
                        foundEmpty = true;
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
                    partMap[i][j] = new MapObject(i, j, MapObject.Types.EMPTY);

            #region Fill part of a map (1/4)

            for (int i = 1; i < partMap.Length - 1; i++)
                for (int j = 1; j < partMap[i].Length - 1; j++)
                    if (isEmptyBox(partMap, i, j))
                        if (rnd.Next(0, 4).Equals(0)) //should be element be added
                        {
                            MapObject[][] element = getRandomElementFromListOfStaticElements();
                            addConcreteStaticElementOnMap(partMap, element, i, j);
                        }

            #endregion Fill part of a map (1/4)

            #region Mirror of a part map (1/2) (LEFT PART OF MAP)

            for (int i = 0; i < partMap.Length; i++)
                for (int j = 0; j < partMap[i].Length; j++)
                {
                    halfMap[i][j] = new MapObject(i, j, partMap[i][j].Type);
                    halfMap[halfMap.Length - 1 - i][j] = new MapObject(halfMap.Length - 1 - i, j, partMap[i][j].Type);
                }

            #endregion Mirror of a part map (1/2) (LEFT PART OF MAP)

            #region Mirror of a part map (2/2) (FULL MAP)

            for (int i = 0; i < halfMap.Length; i++)
                for (int j = 0; j < halfMap[i].Length; j++)
                {
                    map[i][j] = new MapObject(i, j, halfMap[i][j].Type);
                    map[i][map[i].Length - 1 - j] = new MapObject(i, map[i].Length - 1 - j, halfMap[i][j].Type);
                }

            #endregion Mirror of a part map (2/2) (FULL MAP)

            //adding middle line
            for (int i = 0; i < map.Length; i++)
            {
                MapObject[] t = map[i];
                t[9] = t[8].Type == MapObject.Types.CONCRETE
                           ? new MapObject(i, 9, MapObject.Types.CONCRETE)
                           : new MapObject(i, 9, MapObject.Types.EMPTY);
            }
        }

        private void addConcreteStaticElementOnMap(MapObject[][] map, MapObject[][] element, int x, int y)
        {
            for (int i = 0; i < element.Length; i++)
                for (int j = 0; j < element[i].Length; j++)
                    map[x - 1 + i][y - 1 + j] = new MapObject(x - 1 + i, y - 1 + j, element[i][j].Type);
        }

        private void addBricksOnMap()
        {
            foreach (MapObject t1 in map.SelectMany(t => t.Where(t1 => t1.Type.Equals(MapObject.Types.EMPTY) && rnd.Next(0, 4).Equals(0))))
                t1.Type = MapObject.Types.BRICK;
        }

        private void addForestOnMap()
        {
            foreach (MapObject t1 in from t in map from t1 in t where t1.Type.Equals(MapObject.Types.EMPTY) && rnd.Next(0, 5).Equals(0) select t1)
                t1.Type = MapObject.Types.FOREST;
        }

        private void addWaterOnMap()
        {
            foreach (MapObject t1 in from t in map from t1 in t where t1.Type.Equals(MapObject.Types.EMPTY) && rnd.Next(0, 16).Equals(0) select t1)
                t1.Type = MapObject.Types.WATER;
        }

        #endregion ADD : CONCRETE | BRICK | WATER | FOREST

        #region Element By Random

        private MapObject[][] getRandomElementFromListOfStaticElements()
        {
            MapObject[][] element = listOfStaticElements[rnd.Next(0, listOfStaticElements.Count)];
            int rotationAngle = rnd.Next(0, 5);
            for (int k = 0; k < rotationAngle; k++)
                element = rotateStaticElement(element);
            return element;
        }

        private MapObject[][] rotateStaticElement(MapObject[][] element)
        {
            MapObject[][] tmp = new[] { new MapObject[3], new MapObject[3], new MapObject[3] };
            for (int i = 0; i < element.Length; i++)
                for (int j = 0; j < element[i].Length; j++)
                    tmp[i][j] = element[2 - j][i];
            return tmp;
        }

        #endregion Element By Random

        #endregion Methods
    }
}