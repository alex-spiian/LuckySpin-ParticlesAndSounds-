using System;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.Serialization;

[Serializable]
public class PlayerController
{
    public Action OnSpinsCountChanged;
    public event Action OnHeroBought;
    
    [SerializeField] private float _startGoldValue;
    [SerializeField] private float _startGemsValue;
    
    [SerializeField]
    private int _startSpinsCount;

    private List<string> _boughtHeroesNames = new List<string>();
    private Wallet _wallet;
    private int _spinsCount;

    
    private void Awake()
    {
        OnSpinsCountChanged?.Invoke();
    }
    public bool HaveEnoughGold(float price) => _wallet.GoldAmount >= price;

    public bool HaveEnoughGems(float price) => _wallet.GemsAmount >= price;

    public void SpendSpin()
    {
        _spinsCount--;
        PlayerPrefs.SetInt("Spins", _spinsCount);
        OnSpinsCountChanged?.Invoke();
    }
    
    public void AddHeroNameInBoughtList(string heroName)
    {
        if (!_boughtHeroesNames.Contains(heroName))
        {
            _boughtHeroesNames.Add(heroName);
            
            PlayerPrefs.SetString(heroName, "true");
        }
    }

    public void TryBuyHero(Hero hero)
    {
        if (!HaveEnoughGold(hero.Price)) return;
        
        _wallet.SpendGold(hero.Price);
        AddHeroNameInBoughtList(hero.Name);
        
        PlayerPrefs.SetString(hero.Name, "true");
        
        OnHeroBought?.Invoke();
    }

    public void UpdateWonPrizesValue()
    {
        _wallet.AddGold(PlayerPrefs.GetInt("won"+GlobalConstants.GOLD_TAG) * GlobalConstants.GOLD_MULTIPLICATOR);
        _wallet.AddGems(PlayerPrefs.GetInt("won"+GlobalConstants.GEM_TAG) * GlobalConstants.GEMS_MULTIPLICATOR);
        
    }

    public void SetDefaultInformation()
    {
        PlayerPrefs.SetFloat(GlobalConstants.GOLD_TAG, _startGoldValue);
        PlayerPrefs.SetFloat(GlobalConstants.GEM_TAG, _startGemsValue);
        PlayerPrefs.SetInt("Spins", _startSpinsCount);

        _wallet = new Wallet(_startGoldValue, _startGemsValue);
        _spinsCount = _startSpinsCount;

    }

    public void LoadSavedInformation()
    {
        _wallet = new Wallet(PlayerPrefs.GetFloat(GlobalConstants.GOLD_TAG),
            PlayerPrefs.GetFloat(GlobalConstants.GEM_TAG));
        _spinsCount = PlayerPrefs.GetInt("Spins");
    }
    
}