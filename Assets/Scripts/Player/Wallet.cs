using System;
using UnityEngine;

namespace DefaultNamespace
{
    [Serializable]
    public class Wallet
    {
        public event Action OmMoneyValueChanged;
        public float GoldAmount { get; private set; }
        public float GemsAmount { get; private set; }
        public Wallet(float gold, float gems)
        {
            GoldAmount = gold;
            GemsAmount = gems;
        }
        public void SpendGold(float price)
        {
            if (GoldAmount >= price)
            {
                GoldAmount -= price;
                PlayerPrefs.SetFloat(PlayerPrefsNames.GOLD, GoldAmount);
                OmMoneyValueChanged?.Invoke();
            }
        }
        
        public void SpendGems(float price)
        {
            if (GemsAmount >= price)
            {
                GemsAmount -= price;
                PlayerPrefs.SetFloat(PlayerPrefsNames.GEM, GemsAmount);
                OmMoneyValueChanged?.Invoke();
            }

        }

        public void AddGold(float amount)
        {
            GoldAmount += amount;
            PlayerPrefs.SetFloat(PlayerPrefsNames.GOLD, GoldAmount);
            OmMoneyValueChanged?.Invoke();
        }
        
        public void AddGems(float amount)
        {
            GemsAmount += amount;
            PlayerPrefs.SetFloat(PlayerPrefsNames.GEM, GemsAmount);
            OmMoneyValueChanged?.Invoke();
        }

        public bool HasEnoughGold(float amount)
        {
            return GoldAmount >= amount;
        }
        
        public bool HasEnoughGems(float amount)
        {
            return GemsAmount >= amount;
        }
        
    }
}