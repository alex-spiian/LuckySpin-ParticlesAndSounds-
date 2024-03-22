using DefaultNamespace;
using Events;
using FortuneWheel;
using Particles;
using Reward;
using SimpleEventBus.Disposables;
using Spin;
using UnityEngine;
using UnityEngine.Serialization;
using VContainer;

public class LuckySpinSceneController : MonoBehaviour
{

    [SerializeField] private WheelRotator _wheelRotator;
    
    [SerializeField] private RewardsController rewardsController;
    [SerializeField] private SpinAnimationsController _spinAnimationsController;
    [SerializeField] private ChestAnimationsController _chestAnimationsController;
    [SerializeField] private AuraController _auraController;

    [SerializeField] private SpinsCountView _spinsCountView;
    [FormerlySerializedAs("_prizesView")] [SerializeField] private RewardsView rewardsView;
    [SerializeField] private MoneyView _moneyView;

    private PlayerController _playerController;
    private readonly CompositeDisposable _subscriptions = new();

    private void Awake()
    {
        _subscriptions.Add(EventStreams.Global.Subscribe<WheelStoppedEvent>(OnWheelStoppedRotating));
        _subscriptions.Add(EventStreams.Global.Subscribe<WheelRotatingEvent>(OnWheelStartedRotating));
        
        _chestAnimationsController.OnChestOpened += rewardsView.UpdatePrizesCount;
        
        //_chestAnimationsController.OnChestClosed += _moneyView.UpdateMoneyView;
    }
    
    [Inject]
    public void Construct(PlayerController playerController)
    {
        _playerController = playerController;
        _playerController.OnSpinsCountChanged += _chestAnimationsController.SetNewSpinsValue;
        _playerController.OnSpinsCountChanged += _spinsCountView.UpdateSpinsCount;
    }

    private void OnWheelStartedRotating(WheelRotatingEvent wheelRotatingEvent)
    {
        _playerController.SpendSpin();
        _spinAnimationsController.PlayFlyAnimation();
        _auraController.Play();
    }
    
    private void OnWheelStoppedRotating(WheelStoppedEvent wheelStoppedEvent)
    {
        rewardsController.SwitchWonCardOn();
        _auraController.Stop();
    }
    
    
    private void OnDestroy()
    {
        _subscriptions.Dispose();
        _playerController.OnSpinsCountChanged -= _chestAnimationsController.SetNewSpinsValue;
        _playerController.OnSpinsCountChanged -= _spinsCountView.UpdateSpinsCount;

        _chestAnimationsController.OnChestOpened -= rewardsView.UpdatePrizesCount;
       // _chestAnimationsController.OnChestClosed -= _moneyView.UpdateMoneyView;

    }
    


}
