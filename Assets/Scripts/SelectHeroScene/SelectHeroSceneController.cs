using System;
using DefaultNamespace;
using Hero;
using UnityEngine;
using VContainer;

namespace SelectHeroScene
{
    public class SelectHeroSceneController : MonoBehaviour
    {
        [SerializeField] private UISelectHeroSceneView _uiSelectHeroSceneView;
        [SerializeField] private MoneyView _moneyView;

        private PlayerController _playerController;
        private HeroesSpawner _heroesSpawner;

        [Inject]
        public void Construct(PlayerController playerController, HeroesSpawner heroesSpawner)
        {
            _playerController = playerController;
            if (_heroesSpawner == null)
            {
                _heroesSpawner = heroesSpawner;
            }

            _playerController.Wallet.OmMoneyValueChanged += _moneyView.UpdateMoneyView;
            _playerController.OnHeroBought += _uiSelectHeroSceneView.ChangeStateOfButtonsBuyAndSelect;
            
            heroesSpawner.OnHeroChanged += _uiSelectHeroSceneView.UpdateHeroInformation;
            heroesSpawner.OnHeroChanged += _uiSelectHeroSceneView.ChangeStateOfButtonsBuyAndSelect;
            
            UpdateInformation();
        }

        private void OnDestroy()
        {
            _heroesSpawner.OnHeroChanged -= _uiSelectHeroSceneView.UpdateHeroInformation;
            _heroesSpawner.OnHeroChanged -= _uiSelectHeroSceneView.ChangeStateOfButtonsBuyAndSelect;

            _playerController.Wallet.OmMoneyValueChanged -= _moneyView.UpdateMoneyView;
            _playerController.OnHeroBought -= _uiSelectHeroSceneView.ChangeStateOfButtonsBuyAndSelect;
        }
        
        public void BuyHero()
        {
            _playerController.TryBuyHero(_heroesSpawner.CurrentHero);

        }
        public void NextHero()
        {
           _heroesSpawner.NextHero();
        }
        
        public void PreviousHero()
        {
            _heroesSpawner.PreviousHero();
        }

        public void SelectHero()
        {
            PlayerPrefs.SetInt(PlayerPrefsNames.PREVIUS_HERO, PlayerPrefs.GetInt(PlayerPrefsNames.CURRENT_HERO));
        }

        public void BackToLobbyScene()
        {
            PlayerPrefs.SetInt(PlayerPrefsNames.CURRENT_HERO, PlayerPrefs.GetInt(PlayerPrefsNames.PREVIUS_HERO));
        }

        private void UpdateInformation()
        {
            _uiSelectHeroSceneView.UpdateHeroInformation(_heroesSpawner.CurrentHero);
            _uiSelectHeroSceneView.ChangeStateOfButtonsBuyAndSelect(_heroesSpawner.CurrentHero);
        }


    }
}