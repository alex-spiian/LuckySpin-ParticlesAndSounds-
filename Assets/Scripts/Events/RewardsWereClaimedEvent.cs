using System.Collections.Generic;
using SimpleEventBus.Events;

namespace Events
{
    public class RewardsWereClaimedEvent : EventBase
    {
        public List<Reward.Reward> Rewards { get; } = new();

        public RewardsWereClaimedEvent(List<Reward.Reward> rewards)
        {
            Rewards = rewards;
        }

    }
}