using System;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.Serialization;

[Serializable]
public class PlayerController
{
    public Action OnSpinsCountChanged;
    public Action<Hero> OnHeroBought;
    
    [SerializeField] private float _startGoldValue;
    [SerializeField] private float _startGemsValue;
    
    [SerializeField] private int _startSpinsCount;
    public Wallet Wallet { get; private set; }
    private int _spinsCount;

    
    private void Awake()
    {
        OnSpinsCountChanged?.Invoke();
    }
    public bool HaveEnoughGold(float price) => Wallet.GoldAmount >= price;

    public bool HaveEnoughGems(float price) => Wallet.GemsAmount >= price;

    public void SpendSpin()
    {
        _spinsCount--;
        PlayerPrefs.SetInt(PlayerPrefsNames.SPINS, _spinsCount);
        OnSpinsCountChanged?.Invoke();
    }


    public void TryBuyHero(Hero hero)
    {
        if (!HaveEnoughGold(hero.Price)) return;
        
        PlayerPrefs.SetString(hero.Name, PlayerPrefsNames.BOUGHT);
        OnHeroBought?.Invoke(hero);
        Wallet.SpendGold(hero.Price);
    }

    public void UpdateWonPrizesValue()
    {
        Wallet.AddGold(PlayerPrefs.GetInt(PlayerPrefsNames.WON + PlayerPrefsNames.GOLD) * GlobalConstants.GOLD_MULTIPLICATOR);
        Wallet.AddGems(PlayerPrefs.GetInt(PlayerPrefsNames.WON + PlayerPrefsNames.GEM) * GlobalConstants.GEMS_MULTIPLICATOR);
        
    }

    public void SetDefaultInformation()
    {
        PlayerPrefs.SetFloat(PlayerPrefsNames.GOLD, _startGoldValue);
        PlayerPrefs.SetFloat(PlayerPrefsNames.GEM, _startGemsValue);
        PlayerPrefs.SetInt(PlayerPrefsNames.SPINS, _startSpinsCount);

        Wallet = new Wallet(_startGoldValue, _startGemsValue);
        _spinsCount = _startSpinsCount;
    }

    public void LoadSavedInformation()
    {
        Wallet = new Wallet(PlayerPrefs.GetFloat(PlayerPrefsNames.GOLD),
            PlayerPrefs.GetFloat(PlayerPrefsNames.GEM));
        
        _spinsCount = PlayerPrefs.GetInt(PlayerPrefsNames.SPINS);
    }
    
}