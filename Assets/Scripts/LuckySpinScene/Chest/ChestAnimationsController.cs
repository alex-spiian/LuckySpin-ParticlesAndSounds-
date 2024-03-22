using System;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;

public class ChestAnimationsController : MonoBehaviour
{
    public event Action OnChestOpened;
    [SerializeField] private Chest.Chest _chest;
    [SerializeField] private DarkModeController _darkScreenMode;
    [SerializeField] private AudioSource _audioSource;

    [SerializeField] private Animator _chestAnimator;
    [SerializeField] private Button _claimButton;
    [SerializeField] private Button _openChestButton;
    [SerializeField] private Canvas _chestCanvas;

    public void MoveToMiddle()
    {
        var currentSpinsCount = PlayerPrefs.GetInt(PlayerPrefsNames.SPINS);
        
        if (currentSpinsCount <= 0)
        {
            _chestCanvas.sortingOrder = GlobalConstants.CHEST_ORDER_TO_BE_ABOVE_DARK_SCREEN;
            
            _openChestButton.interactable = true;
            _chestAnimator.SetTrigger(GlobalConstants.CHEST_ANIM_TRIGER_MOVE);
            _darkScreenMode.SwitchDarkModeOn();
        }
    }

    public void Open()
    {
        OnChestOpened?.Invoke();
        _audioSource.Play();
        _chestAnimator.SetTrigger(GlobalConstants.CHEST_ANIM_TRIGER_OPEN);
        
        _darkScreenMode.SwitchDarkModeOn();
        _claimButton.gameObject.SetActive(true);
        _openChestButton.interactable = false;
    }
    
    public void Hide()
    {
        _chest.OnChestClosed();
        
        _chestAnimator.SetTrigger(GlobalConstants.CHEST_ANIM_TRIGER_HIDE);
        _darkScreenMode.ResetDarkScreenMode();
        
    }
    public void PunchScale()
    {
        _chestAnimator.SetTrigger(GlobalConstants.CHEST_ANIM_TRIGER_SCALE);
    }
    
    public void SetNewSpinsValue()
    {
        _chestAnimator.SetInteger(GlobalConstants.CHEST_ANIM_SPINS_COUNT_TRIGGER_NAME, PlayerPrefs.GetInt(PlayerPrefsNames.SPINS));
    }
}
