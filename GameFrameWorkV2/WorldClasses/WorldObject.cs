using GameFrameWorkV2.Helpers.Structs;
using GameFrameWorkV2.Items;

namespace GameFrameWorkV2.WorldClasses
{
    public interface IWorldObject
    {
        public Position Position { get; set; }
        public bool IsLootable { get; set; }
        public string Name { get; set; }

    }
}
