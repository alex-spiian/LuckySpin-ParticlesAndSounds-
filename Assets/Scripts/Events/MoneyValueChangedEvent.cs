using SimpleEventBus.Events;

namespace Events
{
    public class MoneyValueChangedEvent : EventBase
    {
        public float Gold { get; }
        public float Gems { get; }

        public MoneyValueChangedEvent(float gold, float gems)
        {
            Gold = gold;
            Gems = gems;
        }
    }
}