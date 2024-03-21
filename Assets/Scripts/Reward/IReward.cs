namespace Reward
{
    public interface IReward
    {
        public RewardTypes RewardType { get; }
        public int Amount { get; }
    }
}