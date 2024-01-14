using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace DefaultNamespace.ShiningBehavior
{
    public class ShiningBehavior : MonoBehaviour
    {
        
        [SerializeField]
        private Vector3 _startSize;
        
        [SerializeField]
        private Vector3 _maxSize;
        
        [SerializeField]
        private float _resizingDuration;

        [SerializeField] private float leftBoard;
        [SerializeField] private float rightBoard;
        [SerializeField] private float upperBoard;
        [SerializeField] private float lowerBoard;

        private Vector3 _endSize;

        private bool _isResizing;

        void Start()
        {
            StartCoroutine(ResizeAndMove());
        }

        IEnumerator ResizeAndMove()
        {
            while (true)
            {
                if (!_isResizing)
                {
                    _isResizing = true;

                    yield return StartCoroutine(ResizeObject());

                    _isResizing = false;
                    
                    _startSize = transform.localScale;
                    _endSize = GetRandomSize();
                    transform.localPosition = GetRandomPosition();
                }

                yield return null;
            }
        }

        IEnumerator ResizeObject()
        {
            float currentTime = 0;

            while (currentTime < _resizingDuration)
            {
                currentTime += Time.deltaTime;

                transform.localScale = Vector3.Lerp(_startSize, _endSize, currentTime / _resizingDuration);

                yield return null;
            }

            currentTime = 0;
            while (currentTime < _resizingDuration)
            {
                currentTime += Time.deltaTime;

                transform.localScale = Vector3.Lerp(_endSize, _startSize, currentTime / _resizingDuration);

                yield return null;
            }

            transform.localScale = _startSize;
        }
        
        private Vector3 GetRandomPosition()
        {
            var randomX = Random.Range(leftBoard, rightBoard);
            var randomY = Random.Range(upperBoard, lowerBoard);

            return new Vector3(randomX, randomY,0);
        }

        private Vector3 GetRandomSize()
        {
            var randomSize = Random.Range(0.1f, _maxSize.x);

            return new Vector3(randomSize, randomSize, randomSize);
        }
        
    }
}