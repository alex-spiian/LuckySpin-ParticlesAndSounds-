using DefaultNamespace;
using Events;
using FortuneWheel;
using Particles;
using PrizeCards;
using Spin;
using UnityEngine;
using UnityEngine.SceneManagement;
using VContainer;

public class LuckySpinSceneController : MonoBehaviour
{

    [SerializeField] private WheelRotator _wheelRotator;
    
    [SerializeField] private PrizeCardsController prizeCardsController;
    [SerializeField] private SpinAnimationsController _spinAnimationsController;
    [SerializeField] private ChestAnimationsController _chestAnimationsController;
    [SerializeField] private AuraController _auraController;

    [SerializeField] private SpinsCountView _spinsCountView;
    [SerializeField] private PrizesView _prizesView;
    [SerializeField] private MoneyView _moneyView;
    
    private PlayerController _playerController;

    private void Awake()
    {
        _wheelRotator.OnWheelRotation += OnWheelStartedRotating;

        _wheelRotator.OnWheelStopped += prizeCardsController.SwitchWonCardOn;
        _wheelRotator.OnWheelStopped += _auraController.Stop;
        
        _chestAnimationsController.OnChestOpened += _prizesView.UpdatePrizesCount;
        
        _chestAnimationsController.OnChestClosed += _playerController.UpdateWonPrizesValue;
        //_chestAnimationsController.OnChestClosed += _moneyView.UpdateMoneyView;

    }
    
    [Inject]
    public void Construct(PlayerController playerController)
    {
        _playerController = playerController;
        
        _playerController.OnSpinsCountChanged += _chestAnimationsController.SetNewSpinsValue;
        _playerController.OnSpinsCountChanged += _spinsCountView.UpdateSpinsCount;
    }

    private void OnWheelStartedRotating()
    {
        _playerController.SpendSpin();
        _spinAnimationsController.PlayFlyAnimation();
        _auraController.Play();
    }
    
    
    private void OnDestroy()
    {
        _wheelRotator.OnWheelRotation -= OnWheelStartedRotating;

        _wheelRotator.OnWheelStopped -= prizeCardsController.SwitchWonCardOn;
        _wheelRotator.OnWheelStopped -= _auraController.Stop;

        _playerController.OnSpinsCountChanged -= _chestAnimationsController.SetNewSpinsValue;
        _playerController.OnSpinsCountChanged -= _spinsCountView.UpdateSpinsCount;

        _chestAnimationsController.OnChestOpened -= _prizesView.UpdatePrizesCount;
       // _chestAnimationsController.OnChestClosed -= _moneyView.UpdateMoneyView;
        _chestAnimationsController.OnChestClosed -= _playerController.UpdateWonPrizesValue;

    }
    


}
