using System;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.Serialization;
using VContainer;

namespace AchievementsScene
{
    public class AchievementPlaquesCreator : MonoBehaviour
    {
        [SerializeField]
        private AchievementConfig[] _achievementConfig;
        [SerializeField]
        private AchievementController _achievementPrefab;
        [SerializeField]
        private GameObject[] _animatedRewards;
        [SerializeField]
        private GameObject _darkScreen;
        [SerializeField]
        private MoneyView _moneyView;
        [SerializeField]
        private GameObject _darkAnimatedObjectPrefab;

        private AchievementController _achievementController;
        private PlayerController _playerController;


        private void Awake()
        {
            for (int i = 0; i < _achievementConfig.Length; i++)
            {
               _achievementController = Instantiate(_achievementPrefab, transform);
               InitializeAchievementController(i);
               _achievementController.FillLabels(_achievementConfig[i]);
                
                if (PlayerPrefs.GetString(_achievementController.RewardName) == GlobalConstants.COLLECTED)
                {
                    _achievementController.MarkAsCollected();
                }
            }
        }

        [Inject]
        public void Construct(PlayerController playerController)
        {
            _playerController = playerController;
        }
        
        private GameObject GetCurrentAnimatedReward()
        {
            for (int i = 0; i < _animatedRewards.Length; i++)
            {
                if (_animatedRewards[i].tag == _achievementController.Type)
                {
                    return _animatedRewards[i];
                }
            }
            return null;
        }

        private void InitializeAchievementController(int index)
        {
            _achievementController.Type = _achievementConfig[index].Type;
            var amount = _achievementConfig[index].Amount;
            var rewardName = _achievementConfig[index].Name;
            var darkAnimatedCover = Instantiate(_darkAnimatedObjectPrefab,_achievementController.gameObject.transform);
            darkAnimatedCover.SetActive(false);
            
            _achievementController.Initialize(rewardName, amount, _moneyView, 
                GetCurrentAnimatedReward(), _darkScreen, darkAnimatedCover, _playerController);
        }
    }
}