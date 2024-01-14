using System;
using DefaultNamespace;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UILobbySceneView : MonoBehaviour
{
    
    [SerializeField] private TextMeshProUGUI _heroName;
    [SerializeField] private TextMeshProUGUI _heroLvl;
    [SerializeField] private TextMeshProUGUI _heroExperience;
    
    [SerializeField] private Slider _experianceValue;
    
    public void UpdateHeroInformation(Hero currentHero)
    {
        _heroName.text = currentHero.Name;
        _heroLvl.text = currentHero.Level.ToString();
        
        _heroExperience.text = $"{currentHero.CurrentExperienceValue}/{currentHero.MaxExperienceValue}";
        _experianceValue.value = currentHero.CurrentExperienceValue;
    }
    
}
