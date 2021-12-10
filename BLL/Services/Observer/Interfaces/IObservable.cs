using System.Collections.Generic;

namespace BLL.Services.Observer.Interfaces
{
    public interface IObservable
    {
        IReadOnlyList<IObserver> Observers { get; }
        
        void RegisterObserver(IObserver o);
        void RemoveObserver(IObserver o);
        void NotifyObservers();
    }
}