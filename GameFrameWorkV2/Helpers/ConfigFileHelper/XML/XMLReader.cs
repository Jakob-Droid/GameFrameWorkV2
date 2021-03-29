using System;
using System.IO;
using System.Xml.Serialization;

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
