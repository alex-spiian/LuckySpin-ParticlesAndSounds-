using System;
using UnityEngine;

namespace DefaultNamespace.Hero
{
    public class HeroSwitcher : MonoBehaviour
    {
        public event Action<global::Hero> OnHeroChanged;

        [SerializeField] private Vector3 _spawnPoint;
        private HeroesController _heroesController; 
        private GameObject _currentHero;

        private void Awake()
        {
            _heroesController = GameController.Instance.GetHeroesController;
            ShowCurrentHero();
            
            OnHeroChanged?.Invoke(_heroesController.GetCurrentHero());
        }
        
        public void NextHero()
        {
            var availableHeroesCount = PlayerPrefs.GetInt(PlayerPrefsNames.HEROES_COUNT);
            
            if (PlayerPrefs.GetInt(PlayerPrefsNames.CURRENT_HERO)+ 1 >= availableHeroesCount) return;
        
            Destroy(_currentHero);

            PlayerPrefs.SetInt(PlayerPrefsNames.CURRENT_HERO, PlayerPrefs.GetInt(PlayerPrefsNames.CURRENT_HERO)+1);
            
            ShowCurrentHero();
            OnHeroChanged?.Invoke(_heroesController.GetCurrentHero());
        }

        public void PreviousHero()
        {
            if (PlayerPrefs.GetInt(PlayerPrefsNames.CURRENT_HERO) <= 0) return;
        
            Destroy(_currentHero);
            PlayerPrefs.SetInt(PlayerPrefsNames.CURRENT_HERO, PlayerPrefs.GetInt(PlayerPrefsNames.CURRENT_HERO)-1);
            
            ShowCurrentHero();
            OnHeroChanged?.Invoke(_heroesController.GetCurrentHero());
        }
        
        private void ShowCurrentHero()
        {
            var currentHero = _heroesController.GetCurrentHero();

            _currentHero = Instantiate(currentHero.HeroPrefab);
            _currentHero.transform.position = _spawnPoint;
            
        }
        
        
    }
}