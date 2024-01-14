using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using TMPro;
using UnityEngine;

public class PrizesView : MonoBehaviour
{
   [SerializeField] private TextMeshProUGUI _goldCount;
   [SerializeField] private TextMeshProUGUI _gemsCount;
   [SerializeField] private TextMeshProUGUI _lifesCount;
   [SerializeField] private TextMeshProUGUI _mysteryCardsCount;

   public void UpdatePrizesCount(int gold, int gems, int life, int mysteryCards)
   {
      _goldCount.text = "x " + GameController.Instance.WonPlayersPrizes[GlobalConstants.GOLD_TAG] *
         GlobalConstants.GOLD_MULTIPLICATOR;
      
      _gemsCount.text = "x " + GameController.Instance.WonPlayersPrizes[GlobalConstants.GEM_TAG] *
         GlobalConstants.GEMS_MULTIPLICATOR;;
      
      _lifesCount.text = "x " + GameController.Instance.WonPlayersPrizes[GlobalConstants.HEART_TAG];
      
      _mysteryCardsCount.text = "x " + GameController.Instance.WonPlayersPrizes[GlobalConstants.RUNE_TAG];
   }
}
