using BLL.Services.Impl;
using BLL.Services.Observer.Interfaces;
using Xunit;

namespace BLL.Tests
{
    public class ObserverTests
    {
        [Fact]
        public void Observable_RegisterObserver_ObserverAdded()
        {
            InitializeAndRegister(out var observer, out var observable);
            Assert.Contains(observer, observable.Observers);
        }
        
        [Fact]
        public void Observable_RemoveObserver_ObserverRemoved()
        {
            InitializeAndRegister(out var observer, out var observable);
            observable.RemoveObserver(observer);
            Assert.DoesNotContain(observer, observable.Observers);
        }

        [Fact]
        public void Observable_Notify_ChangedValues()
        {
            var observer = new DonateService();
            var observable = new SubscriptionService();
            observable.RegisterObserver(observer);

            var value = 5;
            observable.ChangeCurrentPrice(value);

            float expected;
            if (value > observer.MaxSubsPrice)
                expected = 0.05f - observer.OneStepPercent;
            else
                expected = 0.05f + observer.OneStepPercent;
            

            Assert.Equal(expected, observer.CurrentPercent);
        }

        private void InitializeAndRegister(out IObserver observer, out IObservable observable)
        {
            observer = new DonateService();
            observable = new SubscriptionService();
            observable.RegisterObserver(observer);
        }
    }
}