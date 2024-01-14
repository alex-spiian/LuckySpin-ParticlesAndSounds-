using UnityEngine;
using UnityEngine.Serialization;

namespace DefaultNamespace.Sound
{
    public class SoundsManager : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;

        [SerializeField] private AudioClip _rotationSound;
        [SerializeField] private AudioClip _winSound;
        [SerializeField] private AudioClip _fallSound;

        public void PlayRotation()
        {
            _audioSource.PlayOneShot(_rotationSound);
        }
        
        public void PlayWin()
        {
            _audioSource.PlayOneShot(_winSound);
        }
        
        public void PlayFall()
        {
            _audioSource.PlayOneShot(_fallSound);
        }
    }
}