using System;
using DefaultNamespace;
using UnityEngine;
using Random = UnityEngine.Random;

namespace FortuneWheel
{
    [Serializable]
    public class WheelConfig
    {
        [SerializeField] private float _minRotationDurationBorder;
        [SerializeField] private float _maxRotationDurationBorder;
        
        [SerializeField] private float _minRotationSpeedBorder;
        [SerializeField] private float _maxRotationSpeedBorder;
        
        [SerializeField] private int _spinsCount;
        
        public float GetRandomSpeedRotation()
        {
            return Random.Range(_minRotationSpeedBorder, _maxRotationSpeedBorder);
        }

        public float GetRandomRotationDuration()
        {
            return Random.Range(_minRotationDurationBorder, _maxRotationDurationBorder);
        }

        public float GetRandomRotationAngel()
        {
            return Random.Range(GlobalConstants.MIN_ROTATION_ANGEL, GlobalConstants.MAX_ROTATION_ANGEL)
                   + GlobalConstants.MAX_ROTATION_ANGEL * _spinsCount;
        }
    }
}