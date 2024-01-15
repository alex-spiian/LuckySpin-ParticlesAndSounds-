using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneController : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;
    private HeroesController _heroesController;

    private void Awake()
    {
        _heroesController = GameController.Instance.GetHeroesController;
        var currentHero = Instantiate(_heroesController.GetCurrentHero());

        currentHero.transform.position = _spawnPoint.transform.position;
        currentHero.transform.rotation = Quaternion.Euler(0, 90, 0);

    }
}
