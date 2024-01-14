using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UISelectHeroSceneView : MonoBehaviour
{
    
    [SerializeField] private Slider _healthValue;
    [SerializeField] private Slider  _attackValue;
    [SerializeField] private Slider _defenceValue;
    [SerializeField] private Slider _speedValue;
    
    [SerializeField] private TextMeshProUGUI _heroNameLabel;
    [SerializeField] private TextMeshProUGUI _heroWeaponLabel;
    [SerializeField] private TextMeshProUGUI _heroPriceLabel;

    [SerializeField] private TextMeshProUGUI _heroExperienceLabel;
    [SerializeField] private TextMeshProUGUI _heroLevelLabel;

    [SerializeField] private Image _heroTypeImage;
    
    [SerializeField] private Button _buyHeroButton;
    [SerializeField] private Button _selectHeroButton;
    
    
    public void UpdateHeroInformation()
    {
        var currentHero = GameController.Instance.GetCurrentHero;
        
        _heroNameLabel.text = currentHero.Name;
        _heroWeaponLabel.text = currentHero.Weapon;
        _heroTypeImage.sprite = currentHero.HeroTypeIcon;
        _heroLevelLabel.text = currentHero.Level.ToString();
        _heroPriceLabel.text = currentHero.Price.ToString();

        _healthValue.value = currentHero.Health;
        _attackValue.value = currentHero.Attack;
        _defenceValue.value = currentHero.Defence;
        _speedValue.value = currentHero.Speed;
        _heroExperienceLabel.text = $"{currentHero.CurrentExperienceValue}/{currentHero.MaxExperienceValue}";
        
    }
    
    public void ChangeStateOfButtonsBuyAndSelect()
    {

        var currentHero = GameController.Instance.GetCurrentHero;

        if (PlayerPrefs.GetString(currentHero.Name) != "true")
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
