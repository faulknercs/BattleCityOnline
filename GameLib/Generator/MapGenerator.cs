using System;
using System.Collections.Generic;
using System.Linq;

namespace BattleCity.GameLib.Generator
{
    // TODO: make it not static and abstract. create concrete generator classes
    public class MapGenerator
    {
        private static void objectInit()
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

        static MapObject[][] map = new MapObject[20][];
        static List<MapObject[][]> listOfStaticElements = new List<MapObject[][]>();
        static Random rnd = new Random();

        public static MapObject[][] generateMap(GameMode mode)
        {
            switch (mode.mode)
            {
                // Classical mode (one team defends its base, another one attacks trying to destroy the base)
                case GameMode.Mode.CLASSIC:
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
                    break;
                // Team deathmatch (two teams attacking each other) without bases
                case GameMode.Mode.TDM:
                    while (true)
                    {
                        makeConcreteMap();

                        if (rnd.Next(0, 2).Equals(0)) addWaterOnMap(); //Water on map 50%
                        if (isMapGood()) break;
                    }
                    addBricksOnMap();
                    addForestOnMap();
                    break;
                // Team deathmatch with bases (both teams have their own base)
                case GameMode.Mode.TDMB:
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
                    break;
                // Deathmatch (every player fights for himself) without bases
                case GameMode.Mode.DM:
                    while (true)
                    {
                        makeConcreteMap();

                        if (rnd.Next(0, 2).Equals(0)) addWaterOnMap(); //Water on map 50%
                        if (isMapGood()) break;
                    }
                    addBricksOnMap();
                    addForestOnMap();
                    break;
            }
            return map;
        }

        #region Methods

        /// <summary>
        /// Is element proper to current position
        /// </summary>
        /// <returns>true - box is good</returns>
        private static bool isEmptyBox(MapObject[][] map, int x, int y)
        {
            if (map[x - 1][y - 1].Type.Equals(MapObject.Types.EMPTY) && map[x - 1][y].Type.Equals(MapObject.Types.EMPTY) && map[x - 1][y + 1].Type.Equals(MapObject.Types.EMPTY))
                if (map[x][y - 1].Type.Equals(MapObject.Types.EMPTY) && map[x][y].Type.Equals(MapObject.Types.EMPTY) && map[x][y + 1].Type.Equals(MapObject.Types.EMPTY))
                    if (map[x + 1][y - 1].Type.Equals(MapObject.Types.EMPTY) && map[x + 1][y].Type.Equals(MapObject.Types.EMPTY) && map[x + 1][y + 1].Type.Equals(MapObject.Types.EMPTY))
                        return true;
            return false;
        }

        private static bool isMapGood()
        {
            //initialize tmpMap with size +2 then map by x and y
            MapObject.Types[][] tmpMap = new MapObject.Types[22][];
            for (int i = 0; i < tmpMap.Length; i++)
                tmpMap[i] = new MapObject.Types[21];

            for (int i = 0; i < tmpMap.Length; i++)
                for (int j = 0; j < tmpMap[i].Length; j++)
                    tmpMap[i][j] = MapObject.Types.CONCRETE; //each element = Concrete
            for (int i = 0; i < map.Length; i++)
                for (int j = 0; j < map[i].Length; j++)
                    tmpMap[i + 1][j + 1] = map[i][j].Type; //copy map to tmpMap

            //Check if 'C' in middle line
            bool concreteBreak = false;
            for (int i = 3; i < tmpMap.Length - 3; i++)
                if (tmpMap[i][10].Equals(MapObject.Types.CONCRETE))
                    concreteBreak = true;
            if (!concreteBreak)
                return false;
            //Check Concrete blocks count
            int concreteCount = 0;
            for (int i = 1; i <= 9; i++)
                for (int j = 1; j <= 10; j++)
                    if (tmpMap[i][j].Equals(MapObject.Types.CONCRETE))
                        concreteCount++;
            if (concreteCount < 25 || concreteCount > 35)
                return false;

            //Getting random element with 'E'
            int x = rnd.Next(5, 16);
            int y = rnd.Next(5, 16);
            if (!tmpMap[x][y].Equals(MapObject.Types.EMPTY))
                while (!tmpMap[x][y].Equals(MapObject.Types.EMPTY))
                {
                    x = rnd.Next(0, 20);
                    y = rnd.Next(0, 21);
                }
            tmpMap[x][y] = MapObject.Types.TEMPORARY;
            //Setting to check every Close 'E' to check, added before
            bool foundEmpty = true;
            while (foundEmpty)
            {
                foundEmpty = false;
                for (int i = 1; i < tmpMap.Length - 1; i++)
                    for (int j = 1; j < tmpMap[i].Length - 1; j++)
                        if (tmpMap[i][j].Equals(MapObject.Types.TEMPORARY))
                        {
                            if (tmpMap[i - 1][j].Equals(MapObject.Types.EMPTY))
                            {
                                tmpMap[i - 1][j] = MapObject.Types.TEMPORARY;
                                foundEmpty = true;
                            }
                            if (tmpMap[i + 1][j].Equals(MapObject.Types.EMPTY))
                            {
                                tmpMap[i + 1][j] = MapObject.Types.TEMPORARY;
                                foundEmpty = true;
                            }
                            if (tmpMap[i][j - 1].Equals(MapObject.Types.EMPTY))
                            {
                                tmpMap[i][j - 1] = MapObject.Types.TEMPORARY;
                                foundEmpty = true;
                            }
                            if (tmpMap[i][j + 1].Equals(MapObject.Types.EMPTY))
                            {
                                tmpMap[i][j + 1] = MapObject.Types.TEMPORARY;
                                foundEmpty = true;
                            }
                        }
            }
            foreach (MapObject.Types[] t in tmpMap)
                foreach (MapObject.Types t1 in t)
                    if (t1.Equals(MapObject.Types.EMPTY))
                        foundEmpty = true;
            return !foundEmpty;
        }

        #region ADD : CONCRETE | BRICK | WATER | FOREST

        private static void makeConcreteMap()
        {
            objectInit();

            //"clear" map
            for (int i = 0; i < map.Length; i++)
                for (int j = 0; j < map[i].Length; j++)
                    map[i][j] = new MapObject(i, j, MapObject.Types.EMPTY);

            #region Fill part of a map (1/4)

            for (int i = 1; i < 10 - 1; i++)
                for (int j = 1; j < 9 - 1; j++)
                    if (isEmptyBox(map, i, j))
                        if (rnd.Next(0, 4).Equals(0)) //should be element be added
                        {
                            MapObject[][] element = getRandomElementFromListOfStaticElements();
                            addConcreteStaticElementOnMap(map, element, i, j);
                        }

            #endregion Fill part of a map (1/4)

            #region Mirror of a part map (2/2) (FULL MAP)

            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 9; j++)
                {
                    map[i][j] = new MapObject(i, j, map[i][j].Type);
                    map[map.Length - 1 - i][j] = new MapObject(map.Length - 1 - i, j, map[i][j].Type);
                    map[i][map[i].Length - 1 - j] = new MapObject(i, map[i].Length - 1 - j, map[i][j].Type);
                    map[map.Length - 1 - i][map[i].Length - 1 - j] = new MapObject(map.Length - 1 - i, map[i].Length - 1 - j, map[i][j].Type);
                }

            #endregion Mirror of a part map (2/2) (FULL MAP)

            //adding middle line
            for (int i = 0; i < map.Length; i++)
                map[i][9] = map[i][8].Type == MapObject.Types.CONCRETE
                           ? new MapObject(i, 9, MapObject.Types.CONCRETE)
                           : new MapObject(i, 9, MapObject.Types.EMPTY);
        }

        private static void addConcreteStaticElementOnMap(MapObject[][] map, MapObject[][] element, int x, int y)
        {
            for (int i = 0; i < element.Length; i++)
                for (int j = 0; j < element[i].Length; j++)
                    map[x - 1 + i][y - 1 + j] = new MapObject(x - 1 + i, y - 1 + j, element[i][j].Type);
        }

        private static void addBricksOnMap()
        {
            foreach (MapObject t1 in map.SelectMany(t => t.Where(t1 => t1.Type.Equals(MapObject.Types.EMPTY) && rnd.Next(0, 4).Equals(0))))
                t1.Type = MapObject.Types.BRICK;
        }

        private static void addForestOnMap()
        {
            foreach (MapObject t1 in from t in map from t1 in t where t1.Type.Equals(MapObject.Types.EMPTY) && rnd.Next(0, 5).Equals(0) select t1)
                t1.Type = MapObject.Types.FOREST;
        }

        private static void addWaterOnMap()
        {
            foreach (MapObject t1 in from t in map from t1 in t where t1.Type.Equals(MapObject.Types.EMPTY) && rnd.Next(0, 16).Equals(0) select t1)
                t1.Type = MapObject.Types.WATER;
        }

        #endregion ADD : CONCRETE | BRICK | WATER | FOREST

        #region Element By Random

        private static MapObject[][] getRandomElementFromListOfStaticElements()
        {
            MapObject[][] element = listOfStaticElements[rnd.Next(0, listOfStaticElements.Count)];
            int rotationAngle = rnd.Next(0, 5);
            for (int k = 0; k < rotationAngle; k++)
                element = rotateStaticElement(element);
            return element;
        }

        private static MapObject[][] rotateStaticElement(MapObject[][] element)
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