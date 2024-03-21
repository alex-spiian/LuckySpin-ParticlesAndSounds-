using System;
using System.Collections.Generic;
using System.Linq;
using Events;
using Reward;
using SimpleEventBus.Disposables;
using UnityEngine;

namespace Chest
{
    public class Chest : MonoBehaviour
    {
        [SerializeField] private ChestAnimationsController _animationsController;
        private readonly List<Reward.Reward> _rewards = new();
        private readonly CompositeDisposable _subscriptions = new();

        private void Awake()
        {
            _subscriptions.Add(EventStreams.Global.Subscribe<RewardWasGotEvent>(AddReward));
        }
        
        private void AddReward(RewardWasGotEvent rewardWasGotEvent)
        {
            var reward = rewardWasGotEvent.Reward;
            
            if (_rewards.Contains(reward)) return;
            _rewards.Add(reward);
            _animationsController.ScaleChest();
            _animationsController.ChestToTheMiddle();
        }

        public int GetRewardValue(RewardTypes type)
        {
            return _rewards.Where(reward => reward.RewardType == type).Sum(reward => reward.Amount);
        }

        private void OnDestroy()
        {
            _subscriptions?.Dispose();
        }
    }
}