using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace.Hero;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

namespace GameScene
{
    public class GameSceneController : MonoBehaviour
    {
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private Camera _camera;
        private HeroesController _heroesController;
        private NavMeshAgent _navMeshAgent;

        private void Awake()
        {
            _heroesController = GameController.Instance.GetHeroesController;
            var currentHero = Instantiate(_heroesController.GetCurrentHero());

            currentHero.transform.position = _spawnPoint.transform.position;
            currentHero.transform.rotation = Quaternion.Euler(0, 90, 0);

            currentHero.AddComponent<MovementController>();
            _camera.transform.SetParent(currentHero.transform);
        }
    }
}
