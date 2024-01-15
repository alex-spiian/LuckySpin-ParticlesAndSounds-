using System;
using DefaultNamespace;
using DefaultNamespace.SelectHeroScene;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UISelectHeroSceneView : MonoBehaviour
{
    
    [SerializeField] private HeroInformationView _heroInformationView;
    [SerializeField] private HeroStatsView _heroStatsView;
    
    [SerializeField] private Button _buyHeroButton;
    [SerializeField] private Button _selectHeroButton;

    public void UpdateHeroInformation(Hero currentHero)
    {
        _heroInformationView.UpdateHeroInformation(currentHero);
        _heroStatsView.UpdateHeroInformation(currentHero);
        
    }
    
    public void ChangeStateOfButtonsBuyAndSelect(Hero currentHero)
    {
        if (_buyHeroButton == null) return;

        if (PlayerPrefs.GetString(currentHero.Name) != PlayerPrefsNames.BOUGHT)
        {
                _buyHeroButton.gameObject.SetActive(true);
            _selectHeroButton.interactable = false;
        }
        else
        {
            _buyHeroButton.gameObject.SetActive(false);
            _selectHeroButton.interactable = true;
        }
    }
    
}
