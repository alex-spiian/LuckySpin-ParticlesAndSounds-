using System;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using VContainer;

namespace AchievementsScene
{
    public class AchievementController : MonoBehaviour
    {
        public string RewardName { get; private set; }
        public string Type { get; set; }

        [SerializeField]
        private Button _claimButton;
        [SerializeField]
        private GameObject _checkMark;
        [SerializeField]
        private AchievementView _achievementView;
        
        private PlayerController _playerController;
        private MoneyView _moneyView;
        private float _amount;
        
        private GameObject _animatedReward;
        private GameObject _darkScreen;
        private GameObject _darkAnimatedCover;

        private void Awake()
        {
            _claimButton.onClick.AddListener(Claim);
        }
        public void Initialize(string rewardName, float amount, MoneyView moneyView,
            GameObject animatedReward, GameObject darkScreen, GameObject darkAnimatedCover, PlayerController playerController)
        {
            RewardName = rewardName;
            _amount = amount;
            _moneyView = moneyView;
            _animatedReward = animatedReward;
            _darkScreen = darkScreen;
            _darkAnimatedCover = darkAnimatedCover;
            _playerController = playerController;
        }
        
        private void Claim()
        {
            _animatedReward.SetActive(true);
            _claimButton.gameObject.SetActive(false);
            _checkMark.SetActive(true);
            _darkAnimatedCover.SetActive(true);
            
            switch (Type)
            {
                case GlobalConstants.GEM_TAG:
                    _playerController.Wallet.AddGems(_amount);
                    break;
                case GlobalConstants.GOLD_TAG:
                    _playerController.Wallet.AddGold(_amount);
                    break;
                case GlobalConstants.CHARACTER or GlobalConstants.INVENTORY:
                    _darkScreen.SetActive(true);
                    break;
            }
        
            _moneyView.UpdateMoneyView();
            PlayerPrefs.SetString(RewardName, GlobalConstants.COLLECTED);
        }
        
        public void MarkAsCollected()
        {
            _claimButton.gameObject.SetActive(false);
            _checkMark.SetActive(true);
            _darkAnimatedCover.SetActive(true);
        }

        public void FillLabels(AchievementConfig achievementConfig)
        {
            _achievementView.InitializeLabels(achievementConfig);
        }
    }
}