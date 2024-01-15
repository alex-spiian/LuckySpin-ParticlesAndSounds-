using System;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;

public class ChestAnimationsController : MonoBehaviour
{
    public event Action OnChestOpened;
    public event Action OnChestClosed;
    
    [SerializeField] private DarkModeController _darkScreenMode;
    [SerializeField] private AudioSource _audioSource;

    [SerializeField] private Animator _chestAnimator;
    [SerializeField] private Button _claimButton;
    [SerializeField] private Button _openChestButton;
    [SerializeField] private Canvas _chestCanvas;

    public void ChestToTheMiddle()
    {
        if (PlayerPrefs.GetInt(PlayerPrefsNames.SPINS) == 0)
        {
            // order in layer to be above the dark screen mode = 4
            _chestCanvas.sortingOrder = GlobalConstants.CHEST_ORDER_TO_BE_ABOVE_DARK_SCREEN;
            
            _openChestButton.interactable = true;
            _chestAnimator.SetTrigger(GlobalConstants.CHEST_ANIM_TRIGER_MOVE);
            _darkScreenMode.SwitchDarkModeOn();

        }
    }

    public void OpenChest()
    {
        OnChestOpened?.Invoke();
        _audioSource.Play();
        _chestAnimator.SetTrigger(GlobalConstants.CHEST_ANIM_TRIGER_OPEN);
        
        _darkScreenMode.SwitchDarkModeOn();
        _claimButton.gameObject.SetActive(true);
        _openChestButton.interactable = false;
    }
    
    public void SetClaimButtonInteractable()
    {
        _audioSource.Stop();
        _claimButton.interactable = true;
    }
    public void HideChest()
    {
        OnChestClosed?.Invoke();
        
        _chestAnimator.SetTrigger(GlobalConstants.CHEST_ANIM_TRIGER_HIDE);
        _darkScreenMode.ResetDarkScreenMode();
        
    }
    public void ScaleChest()
    {
        _chestAnimator.SetTrigger(GlobalConstants.CHEST_ANIM_TRIGER_SCALE);
    }
    
    public void SetNewSpinsValue()
    {
        _chestAnimator.SetInteger(GlobalConstants.CHEST_ANIM_SPINS_COUNT_TRIGGER_NAME, PlayerPrefs.GetInt(PlayerPrefsNames.SPINS));
    }
    
}
