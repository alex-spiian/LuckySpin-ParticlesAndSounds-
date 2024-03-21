using System;
using TMPro;
using UnityEngine;

namespace DefaultNamespace
{
    public class MoneyView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _goldValue;
        [SerializeField] private TextMeshProUGUI _gemesValue;
        private void Awake()
        {
            UpdateMoneyView();
        }

        public void UpdateMoneyView()
        {
            _goldValue.text = PlayerPrefs.GetFloat(PlayerPrefsNames.GOLD).ToString("N0");
            _gemesValue.text = PlayerPrefs.GetFloat(PlayerPrefsNames.GEM).ToString("N0");
        }

      
    }
}