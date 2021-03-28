using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
