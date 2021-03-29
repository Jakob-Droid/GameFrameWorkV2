using GameFrameWorkV2.WorldClasses;

namespace GameFrameWorkV2.Items
{
    public interface IItem : IWorldObject
    {
        string Name { get; set; }
    }
}
