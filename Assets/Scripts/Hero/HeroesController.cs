using System;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

[Serializable]
public class HeroesController
{
    [SerializeField] private GameObject[] _heroesPrefabs;

    private List<Hero> _heroesWithStats = new();
    
    public void InitializeHeroesStats()
    {
        PlayerPrefs.SetInt(PlayerPrefsNames.HEROES_COUNT, _heroesPrefabs.Length);

        if (_heroesPrefabs == null) return;
        
        for (var i = 0; i < _heroesPrefabs.Length; i++)
        {
            _heroesWithStats.Add(_heroesPrefabs[i].GetComponent<Hero>());

            _heroesWithStats[i].HeroPrefab = _heroesPrefabs[i];
        }
    }

    public Hero GetCurrentHero()
    {
        return _heroesWithStats[PlayerPrefs.GetInt(PlayerPrefsNames.CURRENT_HERO)];
    }

}
