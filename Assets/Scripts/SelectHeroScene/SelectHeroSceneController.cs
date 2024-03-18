using System;
using DefaultNamespace;
using DefaultNamespace.Hero;
using DefaultNamespace.SceneController;
using UnityEngine;
using VContainer;

namespace SelectHeroScene
{
    public class SelectHeroSceneController : MonoBehaviour
    {
        [SerializeField] private UISelectHeroSceneView _uiSelectHeroSceneView;
        [SerializeField] private HeroSwitcher _heroSwitcher;
        [SerializeField] private MoneyView _moneyView;

        private PlayerController _playerController;
        private HeroesController _heroesController;

        private void Awake()
        {
            _heroesController = GameController.Instance.GetHeroesController;

            _heroSwitcher.OnHeroChanged += _uiSelectHeroSceneView.UpdateHeroInformation;
            _heroSwitcher.OnHeroChanged += _uiSelectHeroSceneView.ChangeStateOfButtonsBuyAndSelect;

            UpdateInformation();

        }

        [Inject]
        public void Construct(PlayerController playerController)
        {
            _playerController = playerController;

            _playerController.Wallet.OmMoneyValueChanged += _moneyView.UpdateMoneyView;
            _playerController.OnHeroBought += _uiSelectHeroSceneView.ChangeStateOfButtonsBuyAndSelect;
        }

        private void OnDisable()
        {
            _heroSwitcher.OnHeroChanged -= _uiSelectHeroSceneView.UpdateHeroInformation;
            _heroSwitcher.OnHeroChanged -= _uiSelectHeroSceneView.ChangeStateOfButtonsBuyAndSelect;

            _playerController.Wallet.OmMoneyValueChanged -= _moneyView.UpdateMoneyView;
            _playerController.OnHeroBought -= _uiSelectHeroSceneView.ChangeStateOfButtonsBuyAndSelect;
        }


        public void BuyHero()
        {
            var currentHero = _heroesController.GetCurrentHero();
            _playerController.TryBuyHero(currentHero);

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
            _uiSelectHeroSceneView.UpdateHeroInformation(_heroesController.GetCurrentHero());
            _uiSelectHeroSceneView.ChangeStateOfButtonsBuyAndSelect(_heroesController.GetCurrentHero());
        }


    }
}