using System;
using UnityEngine;
using UnityEngine.AI;

namespace Hero
{
    public class HeroAnimationsController
    {
        private Animator _animator;
        private NavMeshAgent _heroNavMeshAgent;
        
        public void PlayAnimations(NavMeshAgent navMeshAgent)
        {
            _heroNavMeshAgent = navMeshAgent;
            
            if (_animator == null)
            {
                _animator = _heroNavMeshAgent.gameObject.GetComponent<Animator>();
            }

            _animator.SetBool("IsWalking", !IsHeroStopped());
        }
        
        
        private bool IsHeroStopped()
        {
            return _heroNavMeshAgent.remainingDistance <= _heroNavMeshAgent.stoppingDistance;

            
        }
    }
}