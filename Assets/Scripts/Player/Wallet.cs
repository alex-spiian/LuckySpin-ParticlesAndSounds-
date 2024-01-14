using System;
using UnityEngine;

namespace DefaultNamespace
{
    [Serializable]
    public class Wallet
    {
        [SerializeField] private float _goldAmount;
        [SerializeField] private float _gemsAmount;
        public float GoldAmount => _goldAmount;
        public float GemsAmount => _gemsAmount;
        
        public void SpendGold(float price)
        {
            if (GoldAmount >= price)
            {
                _goldAmount -= price;
            }
        }
        
        public void SpendGems(float price)
        {
            if (GemsAmount >= price)
            {
                _gemsAmount -= price;
            }

        }

        public void AddGold(float amount)
        {
            _goldAmount += amount;
        }
        
        public void AddGems(float amount)
        {
            _gemsAmount += amount;
        }
        
    }
}