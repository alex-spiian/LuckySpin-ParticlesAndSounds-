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
        public UnityEvent OnDarkScreenMode;

        [SerializeField] public GameObject[] _cards;
        [SerializeField] private ArrowController _arrowController;

        private Dictionary<string, int> _prizesCount;
        
        private void Awake()
        {
            _prizesCount = GameController.Instance.WonPlayersPrizes;
            InitializeCardsDictionary();
        }


        public void SwitchWonCardOn()
        {
            for (int i = 0; i < _cards.Length; i++)
            {
                if (_cards[i].transform.CompareTag(_arrowController.GetWonPrizeName))
                {
                    OnDarkScreenMode?.Invoke();

                    _cards[i].SetActive(true);

                    _prizesCount[_cards[i].tag] ++;

                    GameController.Instance.WonPlayersPrizes = _prizesCount;

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

        public int GetGoldCount()
        {
            _prizesCount.TryGetValue(GlobalConstants.GOLD_TAG, out var count);

            return count * GlobalConstants.GOLD_MULTIPLICATOR;
        }
        
        public int GetGemsCount()
        {
            _prizesCount.TryGetValue(GlobalConstants.GEM_TAG, out var count);

            return count * GlobalConstants.GEMS_MULTIPLICATOR;
        }
        
        public int GetLifeCount()
        {
            _prizesCount.TryGetValue(GlobalConstants.HEART_TAG, out var count);

            return count;
        }
        
        public int GetMysteryCardsCount()
        {
            _prizesCount.TryGetValue(GlobalConstants.RUNE_TAG, out var count);

            return count;
        }
        
        

        private void InitializeCardsDictionary()
        {
            
            for (int i = 0; i < _cards.Length; i++)
            {
                _prizesCount.TryAdd(_cards[i].tag, 0);
            }
        }
        
        
    }
}