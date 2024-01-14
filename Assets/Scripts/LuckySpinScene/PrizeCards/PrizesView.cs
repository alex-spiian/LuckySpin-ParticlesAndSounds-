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

   public void UpdatePrizesCount()
   {
      _goldCount.text = "x " + PlayerPrefs.GetInt("won"+GlobalConstants.GOLD_TAG) *
         GlobalConstants.GOLD_MULTIPLICATOR;
      
      _gemsCount.text = "x " + PlayerPrefs.GetInt("won"+GlobalConstants.GEM_TAG) *
         GlobalConstants.GEMS_MULTIPLICATOR;;
      
      _lifesCount.text = "x " + PlayerPrefs.GetInt("won"+GlobalConstants.HEART_TAG);
      
      _mysteryCardsCount.text = "x " + PlayerPrefs.GetInt("won"+GlobalConstants.RUNE_TAG);
   }
}
