using System;
using System.Collections.Generic;
using DefaultNamespace;
using Player;
using UnityEngine;
using UnityEngine.Serialization;
using VContainer;

public class PlayerController
{
    public Action OnSpinsCountChanged;
    public Action<Hero.Hero> OnHeroBought;
    public Wallet Wallet { get; private set; }
    private int _spinsCount;
    private PlayerConfig _playerConfig;

    [Inject]
    public void Construct(PlayerConfig playerConfig)
    {
        _playerConfig = playerConfig;
        OnSpinsCountChanged?.Invoke();
    }

    public void SpendSpin()
    {
        _spinsCount--;
        PlayerPrefs.SetInt(PlayerPrefsNames.SPINS, _spinsCount);
        OnSpinsCountChanged?.Invoke();
    }
    
    public void TryBuyHero(Hero.Hero hero)
    {
        if (!Wallet.HasEnoughGold(hero.Price)) return;
        
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
        PlayerPrefs.SetFloat(PlayerPrefsNames.GOLD, _playerConfig.StartGoldValue);
        PlayerPrefs.SetFloat(PlayerPrefsNames.GEM, _playerConfig.StartGemsValue);
        PlayerPrefs.SetInt(PlayerPrefsNames.SPINS, _playerConfig.StartSpinsCount);

        Wallet = new Wallet(_playerConfig.StartGoldValue, _playerConfig.StartGemsValue);
        _spinsCount = _playerConfig.StartSpinsCount;
    }

    public void LoadSavedInformation()
    {
        Wallet = new Wallet(PlayerPrefs.GetFloat(PlayerPrefsNames.GOLD),
            PlayerPrefs.GetFloat(PlayerPrefsNames.GEM));
        
        _spinsCount = PlayerPrefs.GetInt(PlayerPrefsNames.SPINS);
    }
    
}