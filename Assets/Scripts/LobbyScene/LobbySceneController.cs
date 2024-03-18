using DefaultNamespace;
using DefaultNamespace.SceneController;
using Hero;
using UnityEngine;
using VContainer;

public class LobbySceneController : MonoBehaviour
{
    [SerializeField] private UILobbySceneView _uiLobbySceneView;
    [SerializeField] private GameObject _dayliGiftButton;
    [SerializeField] private MoneyView _moneyView;
    [SerializeField] private HeroesSpawner _heroesSpawner;
    
    private void Awake()
    {
        if (PlayerPrefs.GetInt(PlayerPrefsNames.SPINS) == 0)
        {
            _dayliGiftButton.SetActive(false);
        }
        _heroesSpawner.SpawnCurrentHero();
        _moneyView.UpdateMoneyView();
    }

    [Inject]
    public void Construct(PlayerController playerController)
    {
        LoadPlayersPrefs(playerController);
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
