using System;
using System.Collections;
using System.Collections.Generic;
using Hero;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using VContainer;

namespace GameScene
{
    public class GameSceneController : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        private NavMeshAgent _navMeshAgent;

        private void Awake()
        {
            StartGame(HeroesSpawner.Instance);
        }
        private void StartGame(HeroesSpawner heroesSpawner)
        {
            heroesSpawner.SpawnCurrentHero();
            var currentHero = heroesSpawner.CurrentHero;

            currentHero.transform.rotation = Quaternion.Euler(0, 90, 0);

            currentHero.AddComponent<MovementController>();
            _camera.transform.SetParent(currentHero.transform);
        }
    }
}
