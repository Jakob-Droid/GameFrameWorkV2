using GameFrameWorkV2.Helpers.Structs;
using GameFrameWorkV2.Items;

namespace GameFrameWorkV2.WorldClasses
{
    public class WorldObject
    {
        public Position Position { get; set; }
        public bool IsLootable { get; set; }
        public string Name { get; set; }
        public bool IsRemoveable { get; set; }
        public IItem Item { get; set; }

        public WorldObject(bool isLootable, string name, bool isRemoveable, Position position, IItem? item)
        {
            Item = item;
            IsLootable = isLootable;
            Name = name;
            IsRemoveable = isRemoveable;
            Position = position;
        }
    }
}
