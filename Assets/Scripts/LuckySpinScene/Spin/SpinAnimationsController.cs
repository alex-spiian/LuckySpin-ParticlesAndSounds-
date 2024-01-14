using System;
using DefaultNamespace;
using UnityEngine;

namespace Spin
{
    public class SpinAnimationsController : MonoBehaviour
    {
        
        [SerializeField] private Animator _animator;
        [SerializeField] private AudioSource _audioSource;

        public void PlayFlyAnimation()
        {
            _animator.SetTrigger(GlobalConstants.SPIN_ANIM_TRIGGER_FLY);
            _audioSource.Play();
        }
    }
}