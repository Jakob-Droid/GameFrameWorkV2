using System.Collections.Generic;

namespace GameFrameWorkV2.Helpers.ConfigFileHelper.XML
{
    public class XmlConfigurations
    {
        public List<XmlHelper> EnemyNamesList { get; set; }

        public XmlConfigurations()
        {

        }

        public struct XmlHelper
        {
            public string Name { get; set; }
        }
    }
}
