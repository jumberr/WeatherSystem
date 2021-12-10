using System.Collections.Generic;
using BLL.Services.Interfaces;
using BLL.Services.Observer.Interfaces;

namespace BLL.Services.Impl
{
    public class SubscriptionService : ISubscriptionService, IObservable
    {
        private List<IObserver> observers = new List<IObserver>();
        private float currentPrice;

        public IReadOnlyList<IObserver> Observers => observers;

        public float Pay(int value)
        {
            return value;
        }

        public void RegisterObserver(IObserver o)
        {
            observers.Add(o);
        }

        public void RemoveObserver(IObserver o)
        {
            observers.Remove(o);
        }

        public void NotifyObservers()
        {
            foreach (IObserver o in observers)
            {
                o.Update(currentPrice);
            }
        }

        public void ChangeCurrentPrice(float price)
        {
            currentPrice = price;
            NotifyObservers();
        }
    }
}