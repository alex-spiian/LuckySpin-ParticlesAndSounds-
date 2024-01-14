using System;
using DefaultNamespace;
using DefaultNamespace.Hero;
using DefaultNamespace.SceneController;
using UnityEngine;

public class SelectHeroSceneController : MonoBehaviour
{

    [SerializeField] private UISelectHeroSceneView _uiSelectHeroSceneView;

    [SerializeField] private HeroSwitcher _heroSwitcher;
    [SerializeField] private SceneController _sceneController;
    [SerializeField] private MoneyView _moneyView;

    private PlayerController _playerController;

    private void Awake()
    {
        _playerController = GameController.Instance.GetPlayerController;
        
        _heroSwitcher.OnHeroChanged += _uiSelectHeroSceneView.UpdateHeroInformation;
        _heroSwitcher.OnHeroChanged += _uiSelectHeroSceneView.ChangeStateOfButtonsBuyAndSelect;
        
        _playerController.OnHeroBought += _moneyView.UpdateMoneyView;
        _playerController.OnHeroBought += _uiSelectHeroSceneView.ChangeStateOfButtonsBuyAndSelect;

        _uiSelectHeroSceneView.UpdateHeroInformation();
        _uiSelectHeroSceneView.ChangeStateOfButtonsBuyAndSelect();
        _moneyView.UpdateMoneyView();

    }

    private void OnDisable()
    {
        _heroSwitcher.OnHeroChanged -= _uiSelectHeroSceneView.UpdateHeroInformation;
        _heroSwitcher.OnHeroChanged -= _uiSelectHeroSceneView.ChangeStateOfButtonsBuyAndSelect;
        
        _playerController.OnHeroBought -= _moneyView.UpdateMoneyView;
        _playerController.OnHeroBought -= _uiSelectHeroSceneView.ChangeStateOfButtonsBuyAndSelect;
        
    }
    
    
    public void BuyHero()
    {
        var currentHero = GameController.Instance.GetCurrentHero;
        _playerController.TryBuyHero(currentHero);
        
    }
    
    public void SelectHero()
    {
        GameController.Instance.LastSelectedHeroIndex = GameController.Instance.CurrentHeroIndex;
        _sceneController.LoadLobbyScene();
    }

    public void BackToLobbyScene()
    {
        GameController.Instance.CurrentHeroIndex = GameController.Instance.LastSelectedHeroIndex;
        _sceneController.LoadLobbyScene();
    }

  
}
