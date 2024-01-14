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
            _goldValue.text = GameController.Instance.GetPlayersGoldValue.ToString("N0");
            _gemesValue.text = GameController.Instance.GetPlayersGemsValue.ToString("N0");
        }

      
    }
}