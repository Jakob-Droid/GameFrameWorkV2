using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameFrameWorkV2.Creatures;
using GameFrameWorkV2.Helpers.Enums;
using GameFrameWorkV2.Items;
using GameFrameWorkV2.WorldClasses;

#nullable enable
namespace GameFrameWorkV2.Helpers.Structs
{
    public struct Tile
    {
        public GroundTile Ground { get; set; }
        public WorldObject? Object { get; set; }
        public AbstractCreature? Creature { get; set; }
    }
}
