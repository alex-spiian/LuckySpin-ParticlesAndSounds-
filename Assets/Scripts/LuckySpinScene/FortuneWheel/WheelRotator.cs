using System.Collections;
using Events;
using UnityEngine;
using UnityEngine.UI;

namespace FortuneWheel
{
    public class WheelRotator : MonoBehaviour
    {
        [SerializeField] private WheelConfig wheelConfig;
        [SerializeField] private Button _spinButton;
        [SerializeField] private AudioSource _audioSource;
        
        private float _rotationDuration;
        private float _speedRotation;
        private float _startRotationState;
        private float _endRotationState;
        public void Rotate()
        {
            EventStreams.Global.Publish(new WheelRotatingEvent());
            
            _endRotationState += wheelConfig.GetRandomRotationAngel();
            _rotationDuration = wheelConfig.GetRandomRotationDuration();
            _speedRotation = wheelConfig.GetRandomSpeedRotation();
            
            StartCoroutine(RotateCoroutine());
        }

        
        public void SetSpinButtonNonInteractable()
        {
            _spinButton.interactable = false;
        }
        
        private void SetSpinButtonInteractable()
        {
            _spinButton.interactable = true;
        }
        private IEnumerator RotateCoroutine()
        {
            var currentTime = 0f;

            while (currentTime <= _rotationDuration)
            {
                var progress = EaseInOut(currentTime / _rotationDuration);
                var newRotation = Mathf.Lerp(_startRotationState, _endRotationState, progress);

                transform.rotation = Quaternion.Euler(0f, 180f, newRotation);
                currentTime += Time.deltaTime;
                yield return null;
            }

            transform.rotation = Quaternion.Euler(0f, 180f, _endRotationState);
            _startRotationState = _endRotationState;
            
            SetSpinButtonInteractable();
            _audioSource.Stop();
            EventStreams.Global.Publish(new WheelStoppedEvent());

        }

        private float EaseInOut(float t)
        {
            if (t < 0.5f)
            {
                return _speedRotation * t * t * t;
            }
            return 1f - Mathf.Pow(-2f * t + 2f, 3f) / 2f;
        }
        
    }
}