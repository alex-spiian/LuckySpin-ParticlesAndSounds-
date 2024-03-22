using System;
using Events;
using Reward;
using UnityEngine;

namespace Arrow
{
    public class ArrowController : MonoBehaviour
    {
        [SerializeField] private Collider _collider;
        public RewardTypes WonRewardType { get; private set; }
        private IDisposable _subscription;

        private void Awake()
        {
            //_subscription = EventStreams.Global.Subscribe<WheelStoppedEvent>(OnWheelStopped);
        }
        private void OnTriggerEnter(Collider other)
        {
            var reward = other.GetComponent<Reward.Reward>();
            if (reward == null) return;
            WonRewardType = reward.RewardType;
            //_collider.enabled = false;
        }
        
        private void OnWheelStopped(WheelStoppedEvent wheelStoppedEvent)
        {
            _collider.enabled = true;
        }
        private void OnDestroy()
        {
            _subscription?.Dispose();
        }
    }
}