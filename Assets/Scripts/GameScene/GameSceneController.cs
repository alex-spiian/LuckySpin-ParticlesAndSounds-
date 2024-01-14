using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneController : MonoBehaviour
{
    [SerializeField] private GameObject[] _heroesPrefabs;
    [SerializeField] private Transform _spawnPoint;

    private void Awake()
    {
        var currentHero = Instantiate(_heroesPrefabs[PlayerPrefs.GetInt("CurrentHero")]);

        currentHero.transform.position = _spawnPoint.transform.position;

        currentHero.transform.rotation = Quaternion.Euler(0, 90, 0);

    }
}
