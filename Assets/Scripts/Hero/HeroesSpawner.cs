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
        public Hero CurrentHero { get; private set; }
        private int _currentHeroIndex;

        private static HeroesSpawner _instance;
        public static HeroesSpawner Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<HeroesSpawner>();
                
                    if (_instance == null)
                    {
                        var singleton = new GameObject("HeroesSpawner");
                        _instance = singleton.AddComponent<HeroesSpawner>();
                    }

                    if (_instance != null)
                    {
                        DontDestroyOnLoad(_instance);
                    }
                }
            
                return _instance;
            }
        }
        
        private void Awake()
        {
            PlayerPrefs.SetInt(PlayerPrefsNames.HEROES_COUNT, _availableHeroes.Length);
            OnHeroChanged?.Invoke(_availableHeroes[_currentHeroIndex]);
            DontDestroyOnLoad(gameObject);
        }

        public void NextHero()
        {
            var availableHeroesCount = PlayerPrefs.GetInt(PlayerPrefsNames.HEROES_COUNT);
            var nextIndex = PlayerPrefs.GetInt(PlayerPrefsNames.CURRENT_HERO) + 1;
            
            if (nextIndex >= availableHeroesCount) return;
        
            Destroy(CurrentHero.gameObject);

            PlayerPrefs.SetInt(PlayerPrefsNames.CURRENT_HERO, PlayerPrefs.GetInt(PlayerPrefsNames.CURRENT_HERO)+1);
            
            SpawnCurrentHero();
            OnHeroChanged?.Invoke(CurrentHero);
        }

        public void PreviousHero()
        {
            var previousIndex = PlayerPrefs.GetInt(PlayerPrefsNames.CURRENT_HERO) - 1;
            if (previousIndex < 0) return;
        
            Destroy(CurrentHero.gameObject);
            PlayerPrefs.SetInt(PlayerPrefsNames.CURRENT_HERO, PlayerPrefs.GetInt(PlayerPrefsNames.CURRENT_HERO)-1);
            
            SpawnCurrentHero();
            OnHeroChanged?.Invoke(CurrentHero);
        }
        
        public void SpawnCurrentHero()
        {
            var currentIndex = PlayerPrefs.GetInt(PlayerPrefsNames.CURRENT_HERO);
            var currentHeroPrefab = _availableHeroes[currentIndex];

            CurrentHero = Instantiate(currentHeroPrefab, transform);
        }
    }
}