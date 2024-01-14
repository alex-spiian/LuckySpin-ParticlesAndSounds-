using System;
using System.Collections;
using Arrow;
using UnityEngine;
using UnityEngine.UI;

namespace FortuneWheel
{
    public class WheelRotator : MonoBehaviour
    {
        public event Action OnWheelRotation;
        public event Action OnWheelStopped;
        
        [SerializeField] private SettingsKeeper _settingsKeeper;
        [SerializeField] private Button _spinButton;
        [SerializeField] private AudioSource _audioSource;
        
        private float _rotationDuration;
        private float _speedRotation;
        private float _startRotationState;
        private float _endRotationState;

        public void Rotate()
        {
            OnWheelRotation?.Invoke();
            _audioSource.Play();
            
            _endRotationState += _settingsKeeper.GetRandomRotationAngel();
            _rotationDuration = _settingsKeeper.GetRandomRotationDuration();
            _speedRotation = _settingsKeeper.GetRandomSpeedRotation();
            
            SetSpinButtonNonInteractable();
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
            
            _audioSource.Stop();
            SetSpinButtonInteractable();
            OnWheelStopped?.Invoke();

        }

        private float EaseInOut(float t)
        {
            if (t < 0.5f)
                return _speedRotation * t * t * t;
            else
                return 1f - Mathf.Pow(-2f * t + 2f, 3f) / 2f;
        }
        
    }
}