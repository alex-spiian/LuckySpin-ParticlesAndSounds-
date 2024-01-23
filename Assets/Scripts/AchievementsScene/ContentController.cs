using System.Collections;
using DefaultNamespace;
using ScriptableObjects.ClaimButton;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ContentController : MonoBehaviour
{
    [SerializeField] private AchievementSettings[] _achievements;
    [SerializeField] private AchievementsButtonsSettings _claimButtonSettings;
    [SerializeField] private AchievementsButtonsSettings _chekMarkSettings;
    [SerializeField] private GameObject ShadowPrefab;
    [SerializeField] private GameObject _darkScreen;
    [SerializeField] private GameObject[] _animatedRawords;
    [SerializeField] private MoneyView _moneyView;

    private GameObject _currentAchievement;
    private AchievementController _currentAchievementController;
    private int _currentIndex;
    private void Awake()
    {
        StartCoroutine(CreateAchievementsMenu());
    }
    
    private IEnumerator CreateAchievementsMenu()
    {
        for (_currentIndex = 0; _currentIndex < _achievements.Length; _currentIndex++)
        {
            CreateBackgroundLabel(_achievements[_currentIndex]);
            CreateIconLabel(_achievements[_currentIndex]);
            CreatePrizeLabel(_achievements[_currentIndex]);
            CreateNameLabel(_achievements[_currentIndex]);
            CreateDescriptionLabel(_achievements[_currentIndex]);
            
            InitializeAchievementController();
            
            if (PlayerPrefs.GetString(_achievements[_currentIndex].Name) == GlobalConstants.COLLECTED)
            {
                _currentAchievementController.MarkAsCollected();
            }
            
            yield return new WaitForSeconds(0.2f);
            
        }
    }

    private GameObject CreateShadowEffect()
    {
        var blackoutEffect = Instantiate(ShadowPrefab);
        blackoutEffect.transform.SetParent(_currentAchievement.transform);
        blackoutEffect.SetActive(false);
        blackoutEffect.transform.localScale = Vector3.one;

        return blackoutEffect;
    }
    private GameObject CreateCheckMarkImage()
    {
        
        var checkMark = new GameObject("checkMark");
        checkMark.transform.parent = _currentAchievement.transform;
        checkMark.transform.localScale = Vector3.one;
        checkMark.transform.position = _chekMarkSettings.ButtonPosition;

        var checkMarkImage = checkMark.AddComponent<Image>();
        checkMarkImage.sprite = _chekMarkSettings.Sprite;

        checkMark.SetActive(false);

        return checkMark;
    }
    private GameObject CreateClaimButton()
    {
        var claim = new GameObject("claim");
        claim.transform.parent = _currentAchievement.transform;
        
        var claimButton = claim.AddComponent<Button>();
        var claimButtonImage = claimButton.AddComponent<Image>();
        claimButton.targetGraphic = claimButtonImage;

        claimButtonImage.rectTransform.sizeDelta = _claimButtonSettings.Size;
        claimButtonImage.sprite = _claimButtonSettings.Sprite;
        claimButtonImage.type = Image.Type.Sliced;
        claim.transform.position = _claimButtonSettings.ButtonPosition;

        var text = new GameObject("text");
        text.transform.parent = claimButton.transform;
        var textLabel = text.AddComponent<TextMeshProUGUI>();
        textLabel.text = _claimButtonSettings.Text;
        textLabel.fontSize = _claimButtonSettings.TextFontSize;
        textLabel.font = Resources.Load<TMP_FontAsset>(GlobalConstants.TITLE_FONT_PATH);
        textLabel.transform.position = _claimButtonSettings.TextPosition;
        
        claimButton.onClick.AddListener(_currentAchievementController.ClaimRewards);

        return claim;

    }

    private void CreateBackgroundLabel(AchievementSettings achievementSettings)
    {
        
        _currentAchievement = new GameObject("Achievement_" + _currentIndex);
        var backgroundImage = _currentAchievement.AddComponent<Image>();
        _currentAchievementController = _currentAchievement.AddComponent<AchievementController>();

        _currentAchievement.transform.SetParent(transform);
        _currentAchievement.transform.localScale = Vector3.one;

        backgroundImage.sprite = achievementSettings.BackgroundSprite;
        backgroundImage.rectTransform.sizeDelta = achievementSettings.BackgroundImageSize;
        backgroundImage.type = Image.Type.Sliced;
    }

    private void CreateIconLabel(AchievementSettings achievementSettings)
    {
        var icon = new GameObject("icon");
        icon.transform.parent = _currentAchievement.transform;
        icon.transform.localScale = Vector3.one;
        icon.transform.position = achievementSettings.IconPosition;

        var iconImage = icon.AddComponent<Image>();
        iconImage.sprite = achievementSettings.Icon;
    }

    private void CreateDescriptionLabel(AchievementSettings achievementSettings)
    {
        var description = new GameObject("description");
        description.transform.parent = _currentAchievement.transform;
        description.transform.position = achievementSettings.DescriptionPosition;

        var descriptionLabel = description.AddComponent<TextMeshProUGUI>();
        descriptionLabel.text = achievementSettings.Description;
        descriptionLabel.enableWordWrapping = false;
        descriptionLabel.font = Resources.Load<TMP_FontAsset>(GlobalConstants.DESCRIPTION_FONT_PATH);
        descriptionLabel.fontSize = achievementSettings.DescriptionFontSize;
    }

    private void CreatePrizeLabel(AchievementSettings achievementSettings)
    {
        var prize = new GameObject("prize");
        prize.transform.parent = _currentAchievement.transform;
        prize.transform.localScale = Vector3.one;
        prize.transform.position = achievementSettings.PrizePosition;

        var prizeImage = prize.AddComponent<Image>();
        prizeImage.sprite = achievementSettings.Prize;

        if (achievementSettings.Type is GlobalConstants.GOLD_TAG or GlobalConstants.GEM_TAG)
        {
            prizeImage.rectTransform.sizeDelta = achievementSettings.PrizeSize;
            prize.transform.position = achievementSettings.PrizePosition;

            CreatePrizeLabelWithAmount(achievementSettings);
        }
        
    }

    private void CreatePrizeLabelWithAmount(AchievementSettings achievementSettings)
    {
        var amount = new GameObject("amount");
        amount.transform.parent = _currentAchievement.transform;
            
        var amountLabel = amount.AddComponent<TextMeshProUGUI>();
            
        amountLabel.text = achievementSettings.Amount.ToString();
        amountLabel.font = Resources.Load<TMP_FontAsset>(GlobalConstants.TITLE_FONT_PATH);
        amountLabel.fontSize = achievementSettings.AmountFontSize;
        amount.transform.position = achievementSettings.AmountPosition;
        amountLabel.alignment = TextAlignmentOptions.Center;
    }

    private void CreateNameLabel(AchievementSettings achievementSettings)
    {
        var name = new GameObject("name");
        name.transform.parent = _currentAchievement.transform;
        name.transform.position = achievementSettings.NamePosition;

        var nameLabel = name.AddComponent<TextMeshProUGUI>();
        nameLabel.text = achievementSettings.Name;
        nameLabel.enableWordWrapping = false;
        nameLabel.font = Resources.Load<TMP_FontAsset>(GlobalConstants.TITLE_FONT_PATH);
        nameLabel.fontSize = achievementSettings.NameFontSize;
    }

    private GameObject SetAnimatedObject(string type)
    {
        for (int i = 0; i < _animatedRawords.Length; i++)
        {
            if (_animatedRawords[i].tag == type)
            {
                return _animatedRawords[i];
            }
        }

        return null;
    }

    private void InitializeAchievementController()
    {
        var claimButton = CreateClaimButton();
        var checkMarkImage = CreateCheckMarkImage();
        var blackoutEffect = CreateShadowEffect();
            
        var animatedReward = SetAnimatedObject(_achievements[_currentIndex].Type);
        var name = _achievements[_currentIndex].Name;
        var amount = _achievements[_currentIndex].Amount;
        var type = _achievements[_currentIndex].Type;

        _currentAchievementController.Initialize(_moneyView, claimButton, checkMarkImage, blackoutEffect,
            animatedReward, _darkScreen, amount, type, name);
    }
    
}
