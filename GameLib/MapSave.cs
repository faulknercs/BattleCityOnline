using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;

namespace BattleCity.GameLib
{
    public class MapSave
    {
        public MapSave(Map map, GameMode mode)
        {
            this.map = map;
            this.mode = mode;
        }
        private Map map;
        private GameMode mode;
        private XmlWriter writer = null;
        public void createXMLDoc(String filePath)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = "\t";
            settings.NewLineChars = "\n";
            //settings.OmitXmlDeclaration = true; // "<?xml version="1.0" encoding="utf-8"?>"

            //writer = new XmlTextWriter(filePath, Encoding.Unicode);
            writer = XmlWriter.Create(filePath,settings);
            writer.WriteStartDocument();
            writer.WriteStartElement("map");        //
            //writer.WriteStartElement("name");

            //Writing name of the mode
            writer.WriteStartElement("mode");
            writer.WriteAttributeString("name", mode.mode.ToString());           //writer.WriteAttributeString("name", mode.getName());
            writer.WriteEndElement();

            //Writing map structure block
            writer.WriteStartElement("structure");      //
            //MapObject[][] tempMapObject = map.GetInternalForm();
            foreach (MapObject[] m in map.GetInternalForm())
            {
                for (int j = 0; j < m.Length; j++)
                {
                    writer.WriteStartElement("element");
                    writer.WriteAttributeString("x", m[j].X.ToString());
                    writer.WriteAttributeString("y", m[j].Y.ToString());
                    writer.WriteAttributeString("type", m[j].Type.ToString());
                    writer.WriteEndElement();
                }
            }
            writer.WriteEndElement();

            writer.WriteEndElement();

            writer.WriteEndDocument();
            writer.Close();
        }
        private void WriteMapToXML(string filePath, string name, string pwd)
        {
            XmlDocument mapDocument = new XmlDocument();
            FileStream fileStream = new FileStream(filePath, FileMode.Open);

        }
    }
}
