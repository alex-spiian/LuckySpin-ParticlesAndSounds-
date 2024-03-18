using DefaultNamespace;
using DefaultNamespace.SceneController;
using UnityEngine;
using VContainer;

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

        if (PlayerPrefs.GetInt(PlayerPrefsNames.SPINS) == 0)
        {
            _dayliGiftButton.SetActive(false);
        }
        
        InstantiateHero();
        _uiLobbySceneView.UpdateHeroInformation(_heroesController.GetCurrentHero());
        _moneyView.UpdateMoneyView();
    }

    [Inject]
    public void Construct(PlayerController playerController)
    {
        LoadPlayersPrefs(playerController);
    }

    private void InstantiateHero()
    {
        var currentHero = _heroesController.GetCurrentHero();
        Instantiate(currentHero.HeroPrefab).transform.position = _spawnPoint;
        
    }

    private void LoadPlayersPrefs(PlayerController playerController)
    {
        if (PlayerPrefs.GetInt(PlayerPrefsNames.GAIM_RANNING_COUNT, 0) == 0)
        {
            playerController.SetDefaultInformation();
            PlayerPrefs.SetInt(PlayerPrefsNames.GAIM_RANNING_COUNT, 1);
            PlayerPrefs.Save();
        }
        else
        {
            playerController.LoadSavedInformation();
        }
    }
    
}
