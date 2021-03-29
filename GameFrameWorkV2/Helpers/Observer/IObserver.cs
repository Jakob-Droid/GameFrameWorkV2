using GameFrameWorkV2.Creatures;

namespace GameFrameWorkV2.Helpers.Observer
{
    public interface IObserver
    {
        void Notify(AbstractCreature creature);
    }
}
