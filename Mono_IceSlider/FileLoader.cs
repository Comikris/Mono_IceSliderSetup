using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Mono_IceSlider
{
    class FileLoader
    {

        public void LoadLevel(string filename, Game1 game, List<Wall> walls, List<Ice> ices)
        {
            XmlReader reader = XmlReader.Create(filename);
            while ( reader.Read() )
            {
                if ( (reader.NodeType == XmlNodeType.Element) && (reader.Name == "Wall"))
                {
                    var xpos = float.Parse(reader.GetAttribute("x"), CultureInfo.InvariantCulture.NumberFormat);
                    var ypos = float.Parse(reader.GetAttribute("y"), CultureInfo.InvariantCulture.NumberFormat);


                    walls.Add(new Wall(xpos, ypos));
                }

                else if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "Ice"))
                {
                    var xpos = float.Parse(reader.GetAttribute("x"), CultureInfo.InvariantCulture.NumberFormat);
                    var ypos = float.Parse(reader.GetAttribute("y"), CultureInfo.InvariantCulture.NumberFormat);


                    ices.Add(new Ice(xpos, ypos));
                }

                else if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "Finish"))
                {
                    var xpos = float.Parse(reader.GetAttribute("x"), CultureInfo.InvariantCulture.NumberFormat);
                    var ypos = float.Parse(reader.GetAttribute("y"), CultureInfo.InvariantCulture.NumberFormat);


                    game.AddExit(xpos, ypos);
                }

                else if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "PlayerStart"))
                {
                    var xpos = float.Parse(reader.GetAttribute("x"), CultureInfo.InvariantCulture.NumberFormat);
                    var ypos = float.Parse(reader.GetAttribute("y"), CultureInfo.InvariantCulture.NumberFormat);


                    game.AddPlayer(xpos, ypos);
                }
            }
            Console.ReadLine();
        }

    }
}
