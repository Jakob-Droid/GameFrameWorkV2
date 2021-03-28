using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using GameFrameWorkV2.Creatures;
using GameFrameWorkV2.Helpers.Logging;
using GameFrameWorkV2.WorldClasses;

namespace GameFrameWorkV2.Helpers.ConfigFileHelper.XML
{
    public class XMLReader
    {

        public static T ReadGameConfiguartion<T>()
        {
            try
            {
                XmlSerializer xmlszl = new XmlSerializer(typeof(T),
                    new XmlRootAttribute("GameConfig"));
                StreamReader reader = new StreamReader("GameConfig.xml");
                using (reader)
                {
                    var x = (T)xmlszl.Deserialize(reader);
                    return x;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return default(T);
            }
        }
    }
}
