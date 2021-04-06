using GameFrameWorkV2.Creatures;

namespace GameFrameWorkV2.Helpers.Observer
{
    public interface IObserver
    {
        public void Notify(AbstractCreature creature);
    }
}
