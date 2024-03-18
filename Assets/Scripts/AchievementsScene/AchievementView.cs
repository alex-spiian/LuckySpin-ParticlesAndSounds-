using System;
using DefaultNamespace;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace AchievementsScene
{
    public class AchievementView : MonoBehaviour
    {
        [field:SerializeField] public Image Icon { get; private set; }
        [field:SerializeField] public Image RewardIcon { get; private set; }
        [field:SerializeField] public TextMeshProUGUI Name { get; private set; }
        [field:SerializeField] public TextMeshProUGUI Description { get; private set; }
        [field:SerializeField] public TextMeshProUGUI Amount { get; private set; }
        
        public void InitializeLabels(AchievementConfig achievementConfig)
        {
            Name.text = achievementConfig.Name;
            Icon.sprite = achievementConfig.Icon;
            Description.text = achievementConfig.Description;
            RewardIcon.sprite = achievementConfig.Prize;
            Amount.text = achievementConfig.Amount.ToString();
            
            if (achievementConfig.Type is GlobalConstants.INVENTORY or GlobalConstants.CHARACTER)
            {
                Amount.gameObject.SetActive(false);
            }
        }

    }
}