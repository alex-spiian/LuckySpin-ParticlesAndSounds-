using System;
using UnityEngine;
using UnityEngine.UI;

namespace SelectHeroScene
{
    [Serializable]
    
    public class HeroStatsView
    {
        [SerializeField] private Slider _healthValue;
        [SerializeField] private Slider  _attackValue;
        [SerializeField] private Slider _defenceValue;
        [SerializeField] private Slider _speedValue;
        
        public void UpdateHeroInformation(Hero.Hero currentHero)
        {
            
            _healthValue.value = currentHero.Health;
            _attackValue.value = currentHero.Attack;
            _defenceValue.value = currentHero.Defence;
            _speedValue.value = currentHero.Speed;
        
        }
    }
}