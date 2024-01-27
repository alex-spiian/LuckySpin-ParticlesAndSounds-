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
        
        public void InitializeLabels(AchievementSettings achievementSettings)
        {
            Name.text = achievementSettings.Name;
            Icon.sprite = achievementSettings.Icon;
            Description.text = achievementSettings.Description;
            RewardIcon.sprite = achievementSettings.Prize;
            Amount.text = achievementSettings.Amount.ToString();
            
            if (achievementSettings.Type is GlobalConstants.INVENTORY or GlobalConstants.CHARACTER)
            {
                Amount.gameObject.SetActive(false);
            }
        }

    }
}