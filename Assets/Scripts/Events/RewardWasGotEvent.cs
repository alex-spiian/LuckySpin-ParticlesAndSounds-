using SimpleEventBus.Events;

namespace Events
{
    public class RewardWasGotEvent : EventBase
    {
        public Reward.Reward Reward { get; private set; }

        public RewardWasGotEvent (Reward.Reward reward)
        {
            Reward = reward;
        }
    }
}