using System;
using DefaultNamespace;
using UnityEngine;

namespace AchievementsScene
{
    public class AchievementPlaquesCreator : MonoBehaviour
    {
        [SerializeField]
        private AchievementSettings[] _achievementSettings;
        [SerializeField]
        private AchievementController _achievementControllerPrefab;
        [SerializeField]
        private GameObject[] _animatedRewards;
        [SerializeField]
        private GameObject _darkScreen;
        [SerializeField]
        private MoneyView _moneyView;
        [SerializeField]
        private GameObject _darkAnimatedObjectPrefab;

        private AchievementController _achievementController;
        

        private void Awake()
        {
            for (int i = 0; i < _achievementSettings.Length; i++)
            {
               _achievementController = Instantiate(_achievementControllerPrefab, transform);
               InitializeAchievementController(i);
               _achievementController.FillLabels(_achievementSettings[i]);
                
                if (PlayerPrefs.GetString(_achievementController.RewardName) == GlobalConstants.COLLECTED)
                {
                    _achievementController.MarkAsCollected();
                }
            }
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
            _achievementController.Type = _achievementSettings[index].Type;
            var amount = _achievementSettings[index].Amount;
            var rewardName = _achievementSettings[index].Name;
            var darkAnimatedCover = Instantiate(_darkAnimatedObjectPrefab,_achievementController.gameObject.transform);
            darkAnimatedCover.SetActive(false);
            
            _achievementController.Initialize(rewardName, amount, _moneyView, 
                GetCurrentAnimatedReward(), _darkScreen, darkAnimatedCover);
        }
    }
}