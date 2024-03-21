using System;
using Events;
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
            EventStreams.Global.Subscribe<MoneyValueChangedEvent>(UpdateMoneyView);
        }

        public void UpdateMoneyView(MoneyValueChangedEvent moneyValueChangedEvent)
        {
            _goldValue.text = moneyValueChangedEvent.Gold.ToString();
            _gemesValue.text = moneyValueChangedEvent.Gems.ToString();
        }
    }
}