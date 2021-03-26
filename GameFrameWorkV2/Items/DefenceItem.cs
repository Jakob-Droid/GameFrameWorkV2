using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFrameWorkV2.Items
{
    public abstract class DefenceItem :IItem
    {
        public int _reduceHitPoints;

        public string Name { get; set; }
        public virtual int ReduceHitPoints
        {
            get { return _reduceHitPoints;}
            set { _reduceHitPoints = value; }
        }
        public string Type { get; set; }
        protected DefenceItem(string name, int reduceHitPoints)
        {
            Name = name;
            _reduceHitPoints = reduceHitPoints;
        }

        public DefenceItem()
        {
            
        }
    }
}
