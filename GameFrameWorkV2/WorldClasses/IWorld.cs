using GameFrameWorkV2.Creatures;
using GameFrameWorkV2.Helpers.Observer;

namespace GameFrameWorkV2.WorldClasses
{
    public interface IWorld : IObserver
    {
        int MaxX { get; set; }
        int MaxY { get; set; }
        DeathObserver DeathObserver { get; set; }
        void Notify(AbstractCreature creature);
    }
}