using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Mono_IceSlider
{
    class FileLoader
    {

        public void LoadLevel(string filename)
        {
            XmlReader reader = XmlReader.Create(filename);
            while ( reader.Read() )
            {
                if ( (reader.NodeType == XmlNodeType.Element) && (reader.Name == "Walls"))
                {
                    if (reader.HasAttributes)
                    {
                        Console.WriteLine(reader.GetAttribute("Wall") + "xpos:" + reader.GetAttribute("x") + " ypos:" + reader.GetAttribute("y"));
                    }
                }
            }
            Console.ReadLine();
        }

    }
}
