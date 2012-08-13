using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;

namespace BattleCity.GameLib
{
    public class MapLoader
    {
        public MapLoader()
        {
        }
        private Map map;
        private MapObject[][] mapObjects;
        private GameMode mode;
        private XmlTextReader reader = null;
        public Map LoadMap(String filePath)
        {
            int x,y;
            mapObjects  = new MapObject[20][];
            for (int i = 0; i < mapObjects.Length; i++)
                mapObjects[i] = new MapObject[19];
            MapObject obj;
            String tempStr;
            reader = new XmlTextReader(filePath);
            reader.WhitespaceHandling = WhitespaceHandling.None;    //skipping empty nodes
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    if (reader.Name == "mode")
                    {
                        tempStr = reader.GetAttribute("name");
                        switch (tempStr)
                        {
                            case "CLASSIC":
                                mode = new GameMode(GameMode.Mode.CLASSIC);
                                break;
                            case "TDM":
                                mode = new GameMode(GameMode.Mode.TDM);
                                break;
                            case "TDMB":
                                mode = new GameMode(GameMode.Mode.TDMB);
                                break;
                            case "DM":
                                mode = new GameMode(GameMode.Mode.DM);
                                break;
                        }
                    }
                    if (reader.Name == "element")
                    {
                        x = int.Parse(reader.GetAttribute("x"));
                        y = int.Parse(reader.GetAttribute("y"));
                        tempStr = reader.GetAttribute("type");
                        switch (tempStr)
                        {
                            case "EMPTY":
                                obj = new MapObject(x, y, MapObject.Types.EMPTY);
                                mapObjects[x][y] = obj;
                                break;

                            case "BRICK":
                                obj = new MapObject(x, y, MapObject.Types.BRICK);
                                mapObjects[x][y] = obj;
                                break;
                            case "CONCRETE":
                                obj = new MapObject(x, y, MapObject.Types.CONCRETE);
                                mapObjects[x][y] = obj;
                                break;
                            case "WATER":
                                obj = new MapObject(x, y, MapObject.Types.WATER);
                                mapObjects[x][y] = obj;
                                break;
                            case "FOREST":
                                obj = new MapObject(x, y, MapObject.Types.FOREST);
                                mapObjects[x][y] = obj;
                                break;
                            case "BASE":
                                obj = new MapObject(x, y, MapObject.Types.BASE);
                                mapObjects[x][y] = obj;
                                break;
                        }
                        
                    }
                        
                }
            }
            reader.Close();
            map = new Map(mapObjects);
            return map;
        }
        public GameMode GetMode()
        {
            return mode;
        }
    }
}
