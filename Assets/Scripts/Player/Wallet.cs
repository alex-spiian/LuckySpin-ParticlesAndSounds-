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

        public Wallet(float gold, float gems)
        {
            _goldAmount = gold;
            _gemsAmount = gems;
        }
        public void SpendGold(float price)
        {
            if (GoldAmount >= price)
            {
                _goldAmount -= price;
                PlayerPrefs.SetFloat(GlobalConstants.GOLD_TAG, _goldAmount);
            }
        }
        
        public void SpendGems(float price)
        {
            if (GemsAmount >= price)
            {
                _gemsAmount -= price;
                PlayerPrefs.SetFloat(GlobalConstants.GEM_TAG, _gemsAmount);
            }

        }

        public void AddGold(float amount)
        {
            _goldAmount += amount;
            PlayerPrefs.SetFloat(GlobalConstants.GOLD_TAG, _goldAmount);
        }
        
        public void AddGems(float amount)
        {
            _gemsAmount += amount;
            PlayerPrefs.SetFloat(GlobalConstants.GEM_TAG, _gemsAmount);
        }
        
    }
}