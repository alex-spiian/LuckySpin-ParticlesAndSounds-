using DefaultNamespace;
using Events;
using UnityEngine;
using UnityEngine.Events;

namespace Reward
{
    public class Reward : MonoBehaviour, IReward
    {
        [field:SerializeField]
        public RewardTypes RewardType { get; private set; }
        [field:SerializeField]
        public CardTypes CardType { get; private set; }
        [field:SerializeField]
        public int Amount { get; private set; }
        
        [SerializeField] private DarkModeController _darkModeController;

        public void StartAnimationPlaying()
        {
            //_darkModeController.SwitchDarkModeOn();
            Debug.Log("StartAnimationPlaying");
        }

        public void StopAnimationPlaying()
        {
            gameObject.SetActive(false);
            Debug.Log("StopAnimationPlaying");


            if (CardType != CardTypes.Prize) return;
            
            EventStreams.Global.Publish(new RewardWasGotEvent(this));

            var currentWonAmount = PlayerPrefs.GetInt(PlayerPrefsNames.WON + gameObject.tag);
            PlayerPrefs.SetInt(PlayerPrefsNames.WON + gameObject.tag, currentWonAmount + 1);
        }
    }
}