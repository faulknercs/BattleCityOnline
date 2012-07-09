using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace TestProject
{
    public partial class MapImage : Form
    {
        public MapImage()
        {
            InitializeComponent();

            for (int i = 0; i < 19; i++)
            {
                DataGridViewRow row = new DataGridViewRow { HeaderCell = { Value = i } };
                dataGridView1.Rows.Add(row);
            }
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                dataGridView1.Columns[i].HeaderCell.Value = (i + 1).ToString();
                dataGridView1.Columns[i].Width = 25;
            }
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].HeaderCell.Value = (i + 1).ToString();
                dataGridView1.Rows[i].Height = 25;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            initialize();
            while (true)
            {
                makeConcreteMap();
                if (rnd.Next(0, 2) == 0) addWaterOnMap(); //Water on map 50%
                if (isMapGood(map)) break;
            }
            addBricksOnMap();
            addForestOnMap();
            output(map);
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

        private char[][] map = new char[20][];

        private List<char[][]> listOfStaticElements = new List<char[][]>();
        private Random rnd = new Random();

        private char[][] getRandomElementFromListOfStaticElements()
        {
            char[][] element = listOfStaticElements[rnd.Next(0, listOfStaticElements.Count)];
            int rotationAngle = rnd.Next(0, 5);
            for (int k = 0; k < rotationAngle; k++)
                element = rotateStaticElement(element);
            return element;
        }

        private void addConcreteStaticElementOnMap(char[][] map, char[][] element, int x, int y)
        {
            for (int i = 0; i < element.Length; i++)
                for (int j = 0; j < element[i].Length; j++)
                    map[x - 1 + i][y - 1 + j] = element[i][j];
        }

        private void makeConcreteMap()
        {
            char[][] partMap = new char[10][];
            char[][] halfMap = new char[20][];
            for (int i = 0; i < partMap.Length; i++)
                partMap[i] = new char[9];
            for (int i = 0; i < halfMap.Length; i++)
                halfMap[i] = new char[9];
            clearMap(partMap);

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

            #region adding middle line

            foreach (char[] t in map)
                t[9] = t[8].Equals('C') ? 'C' : 'E';

            //adding base and tanks

            //map[0][9 - 2] = 'T';
            map[0][9] = 'O';
            //map[0][9 + 2] = 'T';
            //map[2][9] = 'T';
            //map[19][9 - 2] = 'T';
            map[19][9] = 'O';
            //map[19][9 + 2] = 'T';
            //map[17][9] = 'T';

            #endregion adding middle line
        }

        #region ADD : BRICK | WATER | FOREST

        private void addBricksOnMap()
        {
            if (!map[0][9 - 1].Equals('C'))
                map[0][9 - 1] = 'B';
            if (!map[0][9 + 1].Equals('C'))
                map[0][9 + 1] = 'B';
            if (!map[1][9].Equals('C'))
                map[1][9] = 'B';
            if (!map[1][9 - 1].Equals('C'))
                map[1][9 - 1] = 'B';
            if (!map[1][9 + 1].Equals('C'))
                map[1][9 + 1] = 'B';

            if (!map[19][9 - 1].Equals('C'))
                map[19][9 - 1] = 'B';
            if (!map[19][9 + 1].Equals('C'))
                map[19][9 + 1] = 'B';
            if (!map[18][9].Equals('C'))
                map[18][9] = 'B';
            if (!map[18][9 - 1].Equals('C'))
                map[18][9 - 1] = 'B';
            if (!map[18][9 + 1].Equals('C'))
                map[18][9 + 1] = 'B';

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

        #endregion ADD : BRICK | WATER | FOREST

        private char[][] rotateStaticElement(char[][] element)
        {
            char[][] tmp = new[] { new char[3], new char[3], new char[3] };
            for (int i = 0; i < element.Length; i++)
                for (int j = 0; j < element[i].Length; j++)
                    tmp[i][j] = element[2 - j][i];
            return tmp;
        }

        private bool isEmptyBox(char[][] map, int x, int y)
        {
            if (map[x - 1][y - 1] == 'E' && map[x - 1][y] == 'E' && map[x - 1][y + 1] == 'E')
                if (map[x][y - 1] == 'E' && map[x][y] == 'E' && map[x][y + 1] == 'E')
                    if (map[x + 1][y - 1] == 'E' && map[x + 1][y] == 'E' && map[x + 1][y + 1] == 'E')
                        return true;
            return false;
        }

        private bool isMapGood(char[][] map)
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

        #region clearmap output initialize

        private void initialize()
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

        private void clearMap(char[][] map)
        {
            for (int i = 0; i < map.Length; i++)
                for (int j = 0; j < map[i].Length; j++)
                {
                    map[i][j] = 'E';
                    dataGridView1[j, i].Style.BackColor = Color.White;
                }
        }

        private void output(char[][] map)
        {
            for (int i = 0; i < map.Length; i++)
                for (int j = 0; j < map[i].Length; j++)
                    switch (map[i][j])
                    {
                        case 'E':
                            dataGridView1[j, i].Style.BackColor = Color.Yellow;
                            break;
                        case 'B':
                            dataGridView1[j, i].Style.BackColor = Color.RosyBrown;
                            break;
                        case 'C':
                            dataGridView1[j, i].Style.BackColor = Color.Black;
                            break;
                        case 'W':
                            dataGridView1[j, i].Style.BackColor = Color.LightBlue;
                            break;
                        case 'F':
                            dataGridView1[j, i].Style.BackColor = Color.GreenYellow;
                            break;
                        case 'O':
                            dataGridView1[j, i].Style.BackColor = Color.Red;
                            break;
                    }
        }

        #endregion clearmap output initialize
    }
}