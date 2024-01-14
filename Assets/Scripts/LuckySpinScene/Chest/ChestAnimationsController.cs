using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using PrizeCards;
using UnityEngine;
using UnityEngine.UI;

public class ChestAnimationsController : MonoBehaviour
{

    public event Action<int, int, int, int> OnChestOpened;
    public event Action OnChestClosed;


    [SerializeField] private DarkModeController _darkScreenMode;
    [SerializeField] private AudioSource _audioSource;

    [SerializeField] private Animator _chestAnimator;
    [SerializeField] private Button _claimButton;
    [SerializeField] private Button _openChestButton;
    [SerializeField] private Canvas _chestCanvas;
    [SerializeField] private PrizeCardsController _prizeCardsController;

    private int _spinsCount;

    public void ChestToTheMiddle()
    {
        if (_spinsCount == 0)
        {
            _chestCanvas.sortingOrder = 4;
            _openChestButton.interactable = true;
            _chestAnimator.SetTrigger(GlobalConstants.CHEST_ANIM_TRIGER_MOVE);
            _darkScreenMode.SwitchDarkModeOn();

        }
    }


    public void OpenChest()
    {
        _audioSource.Play();
        OnChestOpened?.Invoke(_prizeCardsController.GetGoldCount(), _prizeCardsController.GetGemsCount(), 
            _prizeCardsController.GetLifeCount(), _prizeCardsController.GetMysteryCardsCount());
        
        _darkScreenMode.SwitchDarkModeOn();
        _claimButton.gameObject.SetActive(true);
        _chestAnimator.SetTrigger(GlobalConstants.CHEST_ANIM_TRIGER_OPEN);
    }
        
        
    public void SetClaimButtonInteractable()
    {
        _audioSource.Stop();
        _claimButton.interactable = true;
    }

    public void HideChest()
    {
        _chestCanvas.sortingOrder = 3;
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
        _spinsCount = (int)GameController.Instance.GetPlayersSpinsCount;

        _chestAnimator.SetInteger(GlobalConstants.CHEST_ANIM_SPINS_COUNT_TRIGGER_NAME, _spinsCount);
    }

    
    
}
