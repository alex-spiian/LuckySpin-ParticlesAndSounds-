using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

namespace Hero
{
    public class MovementController : MonoBehaviour
    {
        private HeroAnimationsController _heroAnimationsController;
        private NavMeshAgent _navMeshAgent;

        private void Awake()
        {
            _heroAnimationsController = new HeroAnimationsController();
            _navMeshAgent = gameObject.AddComponent<NavMeshAgent>();
        }

        private void Update()
        {
         
            _heroAnimationsController.PlayAnimations(_navMeshAgent);
            
            if (!Input.GetMouseButtonDown(0))
            {
                return;
            }

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out var hit))
            {
                _navMeshAgent.destination = hit.point;
            }
            
            
        }

        
    }
}