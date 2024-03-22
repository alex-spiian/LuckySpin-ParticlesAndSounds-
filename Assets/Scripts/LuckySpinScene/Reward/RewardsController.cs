using System;
using Arrow;
using UnityEngine;
using UnityEngine.Serialization;

namespace Reward
{
    
    [Serializable]
    public class RewardsController : MonoBehaviour
    {
        [SerializeField] public Reward[] _rewards;
        [SerializeField] private ArrowController _arrowController;

        public void SwitchWonCardOn()
        {
            for (int i = 0; i < _rewards.Length; i++)
            {
                if (_rewards[i].RewardType == _arrowController.WonRewardType)
                {
                    _rewards[i].gameObject.SetActive(true);
                    
                }
            }
        }
        public void ResetCardsState()
        {
            for (int i = 0; i < _rewards.Length; i++)
            {
                _rewards[i].gameObject.SetActive(false);
            }
        }

    }
}