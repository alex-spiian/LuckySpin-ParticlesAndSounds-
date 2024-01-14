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
            
            if (GameController.Instance.CurrentHeroIndex + 1 >= availableHeroesCount) return;
        
            Destroy(_currentHero);
            
            GameController.Instance.CurrentHeroIndex++;
            ShowCurrentHero();
            OnHeroChanged?.Invoke();
        }

        public void PreviousHero()
        {
            if (GameController.Instance.CurrentHeroIndex <= 0) return;
        
            Destroy(_currentHero);
            GameController.Instance.CurrentHeroIndex--;
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