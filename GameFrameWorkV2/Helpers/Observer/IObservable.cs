namespace GameFrameWorkV2.Helpers.Observer
{
    public interface IObservable
    {
        void AddObserver(IObserver observer);
    }
}
