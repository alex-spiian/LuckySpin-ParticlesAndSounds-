using DefaultNamespace;
using DefaultNamespace.SceneController;
using UnityEngine;

public class LobbySceneController : MonoBehaviour
{
    [SerializeField] private Vector3 _spawnPoint;
    [SerializeField] private UILobbySceneView _uiLobbySceneView;
    [SerializeField] private MoneyView _moneyView;
    [SerializeField] private SceneController _sceneController;
    [SerializeField] private GameObject _dayliGiftButton;
    
    private void Awake()
    {
        
        if (PlayerPrefs.GetInt("RunsCount", 0) == 0)
        {
            GameController.Instance.GetPlayerController.SetDefaultInformation();
            PlayerPrefs.SetInt("RunsCount", 1);
            PlayerPrefs.Save();
        }
        else
        {
            GameController.Instance.GetPlayerController.LoadSavedInformation();
        }
        
        if (PlayerPrefs.GetInt("Spins") == 0)
        {
            _dayliGiftButton.SetActive(false);
        }
        
        InstantiateHero();
        _moneyView.UpdateMoneyView();
        _uiLobbySceneView.UpdateHeroInformation(GameController.Instance.GetCurrentHero);
        
    }

    private void InstantiateHero()
    {
        var currentHero = GameController.Instance.GetCurrentHero;
        Instantiate(currentHero.HeroPrefab).transform.position = _spawnPoint;
        
    }

    public void ChangeHero()
    {
        _sceneController.LoadSelectHeroScene();
    }
    
    
    
}
