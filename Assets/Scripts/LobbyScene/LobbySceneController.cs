using DefaultNamespace;
using DefaultNamespace.SceneController;
using UnityEngine;

public class LobbySceneController : MonoBehaviour
{
    [SerializeField] private Vector3 _spawnPoint;
    [SerializeField] private UILobbySceneView _uiLobbySceneView;
    [SerializeField] private GameObject _dayliGiftButton;
    [SerializeField] private MoneyView _moneyView;

    private HeroesController _heroesController;
    
    private void Awake()
    {
        _heroesController = GameController.Instance.GetHeroesController;
        
        LoadPlayersPrefs();
        
        if (PlayerPrefs.GetInt(PlayerPrefsNames.SPINS) == 0)
        {
            _dayliGiftButton.SetActive(false);
        }
        
        InstantiateHero();
        _uiLobbySceneView.UpdateHeroInformation(_heroesController.GetCurrentHero());
        _moneyView.UpdateMoneyView();
        
    }

    private void InstantiateHero()
    {
        var currentHero = _heroesController.GetCurrentHero();
        Instantiate(currentHero.HeroPrefab).transform.position = _spawnPoint;
        
    }

    private void LoadPlayersPrefs()
    {
        if (PlayerPrefs.GetInt(PlayerPrefsNames.GAIM_RANNING_COUNT, 0) == 0)
        {
            GameController.Instance.GetPlayerController.SetDefaultInformation();
            PlayerPrefs.SetInt(PlayerPrefsNames.GAIM_RANNING_COUNT, 1);
            PlayerPrefs.Save();
        }
        else
        {
            GameController.Instance.GetPlayerController.LoadSavedInformation();
        }
    }
    
}
