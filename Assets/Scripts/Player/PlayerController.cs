using System;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

[Serializable]
public class PlayerController
{
    public Action OnSpinsCountChanged;
    public event Action OnHeroBought;
    
    [SerializeField]
    private Wallet _wallet;
    
    private int _spinsCount = 3;
    public float GetGoldValue => _wallet.GoldAmount; 
    public float GetGemsValue => _wallet.GemsAmount;
    public int GetSpinsCount => _spinsCount;
    
    
    private List<string> _boughtHeroesNames = new List<string>();
    
    private void Awake()
    {
        OnSpinsCountChanged?.Invoke();
    }
    public bool HaveEnoughGold(float price) => _wallet.GoldAmount >= price;

    public bool HaveEnoughGems(float price) => _wallet.GemsAmount >= price;

    public void SpendSpin()
    {
        _spinsCount--;
            
        OnSpinsCountChanged?.Invoke();
    }
    
    public void AddHeroNameInBoughtList(string heroName)
    {
        if (!_boughtHeroesNames.Contains(heroName))
        {
            _boughtHeroesNames.Add(heroName);
        }
    }

    public bool IsHeroBought(string heroName)
    {
        return _boughtHeroesNames.Contains(heroName);
    }

    public void TryBuyHero(Hero hero)
    {
        if (!HaveEnoughGold(hero.Price)) return;
        
        _wallet.SpendGold(hero.Price);
        AddHeroNameInBoughtList(hero.Name);
        
        OnHeroBought?.Invoke();
    }

    public void UpdateWonPrizesValue()
    {
        _wallet.AddGold(GameController.Instance.WonPlayersPrizes[GlobalConstants.GOLD_TAG] * GlobalConstants.GOLD_MULTIPLICATOR);
        _wallet.AddGems(GameController.Instance.WonPlayersPrizes[GlobalConstants.GEM_TAG] * GlobalConstants.GEMS_MULTIPLICATOR);
        
    }
    
}