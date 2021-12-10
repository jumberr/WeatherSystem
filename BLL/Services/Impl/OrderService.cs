using BLL.Services.Interfaces;

namespace BLL.Services.Impl
{
    public class OrderService
    {
        public float Order(ISubscriptionService subscription, int value)
        {
            return subscription.Pay(value);
        }
    }
}