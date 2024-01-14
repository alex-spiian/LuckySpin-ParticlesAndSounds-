using System;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace PrizeCards
{
    public class CardStateController : MonoBehaviour
    {

        public UnityEvent OnAnimationEndedPlaying;
        public UnityEvent OnCardIsInChest;

        [SerializeField] private DarkModeController _darkModeController;

        public void StartAnimationPlaying()
        {
            _darkModeController.SwitchDarkModeOn();
        }

        public void StopAnimationPlaying(string cardType)
        {
            gameObject.SetActive(false);

            if (cardType == GlobalConstants.PRIZE_CARD_TYPE)
            {
                OnCardIsInChest?.Invoke();
            }

            
            OnAnimationEndedPlaying?.Invoke();

        }
    }
}