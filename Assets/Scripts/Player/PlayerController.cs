using System;
using System.Collections.Generic;
using DefaultNamespace;
using Events;
using Player;
using Reward;
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
    private IDisposable _subscription;

    [Inject]
    public void Construct(PlayerConfig playerConfig)
    {
        _playerConfig = playerConfig;
        OnSpinsCountChanged?.Invoke();
        _subscription = EventStreams.Global.Subscribe<RewardsWereClaimedEvent>(OnRewardsWereClaimed);
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
    
    private void OnRewardsWereClaimed(RewardsWereClaimedEvent rewardsWereClaimedEvent)
    {
        var rewards = rewardsWereClaimedEvent.Rewards;

        foreach (var reward in rewards)
        {
            if (reward.RewardType == RewardTypes.Gold)
            {
                Wallet.AddGold(reward.Amount);
            }
            
            if (reward.RewardType == RewardTypes.Gem)
            {
                Wallet.AddGems(reward.Amount);
            }
        }
    }
    
}