using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using GameFrameWorkV2.Helpers.Exceptions;

namespace GameFrameWorkV2.Items.ConcreteDefenceItems
{
    public class CompositeDefence : DefenceItem
    {
        //TODO -- is this the right way to use this?
        public List<DefenceItem> DefenceItems { get; set; }
        public CompositeDefence()
        {
            DefenceItems = new List<DefenceItem>();
        }

        public override int ReduceHitPoints
        {
            get
            {
                return DefenceItems.Sum(x => x.ReduceHitPoints);
            }
            set { base.ReduceHitPoints = value; }
        }

        public void AddDefenceItem(DefenceItem item)
        {
            if (!DefenceItems.Contains(DefenceItems.Find(x=> x.Type == item.Type)))
            {
                DefenceItems.Add(item);
            }
            else
            {
                throw new ItemAlreadyEquipped("You cannot equip another item of the same type!");
            }
        }
    }
}
