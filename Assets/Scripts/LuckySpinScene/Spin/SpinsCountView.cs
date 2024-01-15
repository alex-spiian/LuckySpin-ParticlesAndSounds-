using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using TMPro;
using UnityEngine;

namespace Spin
{
    public class SpinsCountView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _spinsCount;

        private void Awake()
        {
            UpdateSpinsCount();
        }

        public void UpdateSpinsCount()
        {
            _spinsCount.text = "x " + PlayerPrefs.GetInt(PlayerPrefsNames.SPINS);
        }
    }
}
