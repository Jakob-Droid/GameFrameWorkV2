using GameFrameWorkV2.Creatures;
using System.Collections.Generic;

namespace GameFrameWorkV2.Helpers.Observer
{
    public class DeathObserver : IObservable
    {
        private static List<IObserver> _observers = new List<IObserver>();
        public void AddObserver(IObserver observer)
        {
            _observers.Add(observer);
        }

        private static void NotifyObservers(AbstractCreature creature)
        {
            foreach (var observer in _observers)
            {
                observer.Notify(creature);
            }
        }

        public static void OnDeath(AbstractCreature creature)
        {
            NotifyObservers(creature);
        }
    }
}
