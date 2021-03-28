using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameFrameWorkV2.WorldClasses;

namespace GameFrameWorkV2.Items
{
    public interface IItem : IWorldObject
    {
        string Name { get; set; }
    }
}
