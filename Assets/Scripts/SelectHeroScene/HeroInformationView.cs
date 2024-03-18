using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SelectHeroScene
{
    [Serializable]
    public class HeroInformationView
    {
        [SerializeField] private TextMeshProUGUI _heroNameLabel;
        [SerializeField] private TextMeshProUGUI _heroWeaponLabel;
        [SerializeField] private TextMeshProUGUI _heroPriceLabel;

        [SerializeField] private TextMeshProUGUI _heroExperienceLabel;
        [SerializeField] private TextMeshProUGUI _heroLevelLabel;

        [SerializeField] private Image _heroTypeImage;
        
        public void UpdateHeroInformation(Hero.Hero currentHero)
        {
            _heroNameLabel.text = currentHero.Name;
            _heroWeaponLabel.text = currentHero.Weapon;
            _heroTypeImage.sprite = currentHero.HeroTypeIcon;
            _heroLevelLabel.text = currentHero.Level.ToString();
            _heroPriceLabel.text = currentHero.Price.ToString();

            _heroExperienceLabel.text = $"{currentHero.CurrentExperienceValue}/{currentHero.MaxExperienceValue}";
        
        }
    }
}