using BLL.Services.Interfaces;
using BLL.Services.Observer.Interfaces;

namespace BLL.Services.Impl
{
    public class DonateService : IDonateService, IObserver
    {
        public float MaxSubsPrice = 3;
        public float OneStepPercent = 0.02f;
        
        private float currentPercent = 0.05f;
        public float CurrentPercent => currentPercent;

        public float GiveADonate(int value)
        {
            return value * CurrentPercent;
        }

        public void Update(object ob)
        {
            var subscriptionPrice = (float) ob;
            if (subscriptionPrice > MaxSubsPrice)
            {
                currentPercent -= OneStepPercent;
            }
            else
            {
                currentPercent += OneStepPercent;
            }
        }
    }
}