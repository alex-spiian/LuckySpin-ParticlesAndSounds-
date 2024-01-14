using System;
using UnityEngine;

namespace DefaultNamespace.Hero
{
    public class HeroSwitcher : MonoBehaviour
    {
        [SerializeField] private Vector3 _spawnPoint;
        
        public event Action OnHeroChanged;

        private GameObject _currentHero;

        private void Awake()
        {
            ShowCurrentHero();
        }
        
        public void NextHero()
        {
            var availableHeroesCount = GameController.Instance.GetHeroesCount;
            
            if (PlayerPrefs.GetInt("CurrentHero")+ 1 >= availableHeroesCount) return;
        
            Destroy(_currentHero);

            PlayerPrefs.SetInt("CurrentHero", PlayerPrefs.GetInt("CurrentHero")+1);
            
            ShowCurrentHero();
            OnHeroChanged?.Invoke();
        }

        public void PreviousHero()
        {
            if (PlayerPrefs.GetInt("CurrentHero") <= 0) return;
        
            Destroy(_currentHero);
            PlayerPrefs.SetInt("CurrentHero", PlayerPrefs.GetInt("CurrentHero")-1);
            
            ShowCurrentHero();
            OnHeroChanged?.Invoke();
        }
        
        private void ShowCurrentHero()
        {
            var currentHero = GameController.Instance.GetCurrentHero;

            _currentHero = Instantiate(currentHero.HeroPrefab);
            _currentHero.transform.position = _spawnPoint;
            
        }
        
        
    }
}