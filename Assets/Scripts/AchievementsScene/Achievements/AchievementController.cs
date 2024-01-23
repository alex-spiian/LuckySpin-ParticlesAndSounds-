using DefaultNamespace;
using UnityEngine;
public class AchievementController : MonoBehaviour
{
    private GameObject _claimButton;
    private GameObject _checkMark;
    private GameObject _shadow;
    private GameObject _animator;
    private GameObject _darkScreen;
    private MoneyView _moneyView;

    private int _reward;
    private string _achievementType;
    private string _name;

    private PlayerController _playerController;
    
    private void Awake()
    {
        _playerController = GameController.Instance.GetPlayerController;
    }

    public void Initialize(MoneyView moneyView, GameObject claimButton, GameObject checkMark, GameObject blackoutObject,
        GameObject animatedReword, GameObject darkScreen, int rewardAmount, string type, string name)
    {
        _moneyView = moneyView;
        _claimButton = claimButton;
        _checkMark = checkMark;
        _shadow = blackoutObject;
        _animator = animatedReword;
        _darkScreen = darkScreen;

        _reward = rewardAmount;
        _achievementType = type;
        _name = name;

    }
    public void ClaimRewards()
    {
        _claimButton.SetActive(false);
        _checkMark.SetActive(true);
        _shadow.SetActive(true);
        _animator.SetActive(true);
        
        switch (_achievementType)
        {
            case GlobalConstants.GEM_TAG:
                _playerController.Wallet.AddGems(_reward);
                break;
            case GlobalConstants.GOLD_TAG:
                _playerController.Wallet.AddGold(_reward);
                break;
            case GlobalConstants.CHARACTER or GlobalConstants.INVENTORY:
                _darkScreen.SetActive(true);
                break;
        }
        
        _moneyView.UpdateMoneyView();
        PlayerPrefs.SetString(_name, GlobalConstants.COLLECTED);

    }

    public void MarkAsCollected()
    {
        _claimButton.SetActive(false);
        _checkMark.SetActive(true);
        _shadow.SetActive(true);
    }
    
}
