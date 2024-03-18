using System;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

namespace Hero
{
    [Serializable]
    public class HeroesController
    {
        [SerializeField] private Hero[] _heroesPrefabs;

        // public Hero SpawnCurrentHero()
        // {
        //     return _heroesPrefabs[PlayerPrefs.GetInt(PlayerPrefsNames.CURRENT_HERO)];
        // }

    }
}
