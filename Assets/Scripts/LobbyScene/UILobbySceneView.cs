using System;
using DefaultNamespace;
using Hero;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

public class UILobbySceneView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _heroName;
    [SerializeField] private TextMeshProUGUI _heroLvl;
    [SerializeField] private TextMeshProUGUI _heroExperience;
    [SerializeField] private Slider _experianceValue;

    [Inject]
    public void Construct(HeroesSpawner heroesSpawner)
    {
        UpdateHeroInformation(heroesSpawner.CurrentHero);
    }
    private void UpdateHeroInformation(Hero.Hero currentHero)
    {
        _heroName.text = currentHero.Name;
        _heroLvl.text = currentHero.Level.ToString();
        
        _heroExperience.text = $"{currentHero.CurrentExperienceValue}/{currentHero.MaxExperienceValue}";
        _experianceValue.value = currentHero.CurrentExperienceValue;
    }
    
}
