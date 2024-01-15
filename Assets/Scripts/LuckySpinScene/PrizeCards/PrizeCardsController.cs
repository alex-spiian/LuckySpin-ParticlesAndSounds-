using System;
using System.Collections.Generic;
using Arrow;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.Events;

namespace PrizeCards
{
    
    [Serializable]
    public class PrizeCardsController : MonoBehaviour
    {
        [SerializeField] public GameObject[] _cards;
        [SerializeField] private ArrowController _arrowController;

        public void SwitchWonCardOn()
        {
            for (int i = 0; i < _cards.Length; i++)
            {
                if (_cards[i].transform.CompareTag(_arrowController.GetWonPrizeName))
                {
                    _cards[i].SetActive(true);
                    
                }
            }
        }
        public void ResetCardsState()
        {
            for (int i = 0; i < _cards.Length; i++)
            {
                _cards[i].SetActive(false);
            }
        }

    }
}