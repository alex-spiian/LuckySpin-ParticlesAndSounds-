using System.Collections.Generic;
using DefaultNamespace;
using Hero;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private string _firstFreeHeroName;
    private void Awake()
    {
        PlayerPrefs.SetString(_firstFreeHeroName, PlayerPrefsNames.BOUGHT);
    }
}