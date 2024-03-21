using System;
using Events;
using UnityEngine;

namespace DefaultNamespace
{
    [Serializable]
    public class Wallet
    {
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
                EventStreams.Global.Publish(new MoneyValueChangedEvent(GoldAmount, GemsAmount));
            }
        }
        
        public void SpendGems(float price)
        {
            if (GemsAmount >= price)
            {
                GemsAmount -= price;
                PlayerPrefs.SetFloat(PlayerPrefsNames.GEM, GemsAmount);
                EventStreams.Global.Publish(new MoneyValueChangedEvent(GoldAmount, GemsAmount));
            }

        }

        public void AddGold(float amount)
        {
            GoldAmount += amount;
            PlayerPrefs.SetFloat(PlayerPrefsNames.GOLD, GoldAmount);
            EventStreams.Global.Publish(new MoneyValueChangedEvent(GoldAmount, GemsAmount));
        }
        
        public void AddGems(float amount)
        {
            GemsAmount += amount;
            PlayerPrefs.SetFloat(PlayerPrefsNames.GEM, GemsAmount);
            EventStreams.Global.Publish(new MoneyValueChangedEvent(GoldAmount, GemsAmount));
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