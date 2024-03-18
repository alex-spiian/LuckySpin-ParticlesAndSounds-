using System.Collections.Generic;
using DefaultNamespace;
using DefaultNamespace.SceneController;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public HeroesController GetHeroesController => _heroesController;
    
    [SerializeField] private HeroesController _heroesController;
    [SerializeField] private string _firstFreeHeroName;

    private static GameController _instance;
    public static GameController Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameController>();
                
                if (_instance == null)
                {
                    var singleton = new GameObject("GameController");
                    _instance = singleton.AddComponent<GameController>();
                }

                if (_instance != null)
                {
                    DontDestroyOnLoad(_instance);
                }
            }
            
            return _instance;
        }
    }
    

    private void Awake()
    {
        _heroesController.InitializeHeroesStats();
        PlayerPrefs.SetString(_firstFreeHeroName, PlayerPrefsNames.BOUGHT);
        
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }
        
        DontDestroyOnLoad(gameObject);
        
    }
    
}