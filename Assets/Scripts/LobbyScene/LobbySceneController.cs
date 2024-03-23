using DefaultNamespace;
using Hero;
using UnityEngine;
using VContainer;

public class LobbySceneController : MonoBehaviour
{
    [Inject]
    public void Construct(PlayerController playerController, HeroesSpawner heroesSpawner)
    {
        LoadPlayersPrefs(playerController);
        heroesSpawner.SpawnCurrentHero();
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
