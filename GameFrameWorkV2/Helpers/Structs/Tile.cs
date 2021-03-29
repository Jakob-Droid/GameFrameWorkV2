using GameFrameWorkV2.Creatures;
using GameFrameWorkV2.Helpers.Enums;
using GameFrameWorkV2.WorldClasses;
using System.Collections.Generic;

#nullable enable
namespace GameFrameWorkV2.Helpers.Structs
{
    public struct Tile
    {
        public GroundTile Ground { get; set; }
        public List<IWorldObject>? Object { get; set; }
        public AbstractCreature? Creature { get; set; }
    }
}
