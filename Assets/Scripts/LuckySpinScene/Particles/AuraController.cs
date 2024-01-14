using UnityEngine;

namespace Particles
{
    public class AuraController : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _particleSystem;

        public void Play()
        {
            _particleSystem.Play();
        }
        
        public void Stop()
        {
            _particleSystem.Stop();
        }
    }
}