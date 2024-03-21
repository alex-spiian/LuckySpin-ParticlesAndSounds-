using System;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.Serialization;

namespace Hero
{
    public class HeroesSpawner : MonoBehaviour
    {
        public event Action<Hero> OnHeroChanged;
        [SerializeField]
        private Hero[] _availableHeroes;
        [SerializeField]
        private Vector3 _spawnPosition;
        public Hero CurrentHero { get; private set; }
        private int _currentHeroIndex;

        private void Awake()
        {
            PlayerPrefs.SetInt(PlayerPrefsNames.HEROES_COUNT, _availableHeroes.Length);
            _currentHeroIndex = PlayerPrefs.GetInt(PlayerPrefsNames.CURRENT_HERO);
            
            DontDestroyOnLoad(gameObject);
        }

        public void NextHero()
        {
            if (_currentHeroIndex + 1 >= _availableHeroes.Length) return;
        
            _currentHeroIndex++;
            PlayerPrefs.SetInt(PlayerPrefsNames.CURRENT_HERO, _currentHeroIndex);
            
            Destroy(CurrentHero.gameObject);
            SpawnCurrentHero();
            OnHeroChanged?.Invoke(CurrentHero);
        }

        public void PreviousHero()
        {
            if (_currentHeroIndex - 1 < 0) return;
        
            _currentHeroIndex--;
            PlayerPrefs.SetInt(PlayerPrefsNames.CURRENT_HERO, _currentHeroIndex);
            
            Destroy(CurrentHero.gameObject);
            SpawnCurrentHero();
            OnHeroChanged?.Invoke(CurrentHero);
        }
        
        public void SpawnCurrentHero()
        {
            CurrentHero = Instantiate(_availableHeroes[_currentHeroIndex]);
            CurrentHero.transform.position = _spawnPosition;
        }
    }
}