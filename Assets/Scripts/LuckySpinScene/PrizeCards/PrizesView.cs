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
      // when the chest will be opened this method wil run and sets value for each reward
      
      _goldCount.text = "x " + PlayerPrefs.GetInt(PlayerPrefsNames.WON + GlobalConstants.GOLD_TAG) *
         GlobalConstants.GOLD_MULTIPLICATOR;
      
      _gemsCount.text = "x " + PlayerPrefs.GetInt(PlayerPrefsNames.WON + GlobalConstants.GEM_TAG) *
         GlobalConstants.GEMS_MULTIPLICATOR;
      
      _lifesCount.text = "x " + PlayerPrefs.GetInt(PlayerPrefsNames.WON + GlobalConstants.HEART_TAG);
      
      _mysteryCardsCount.text = "x " + PlayerPrefs.GetInt(PlayerPrefsNames.WON + GlobalConstants.RUNE_TAG);
   }
}
