using UnityEngine;

public class RewardsView : MonoBehaviour
{
   [SerializeField] private RewardLabel[] _labels;
   [SerializeField] private Chest.Chest _chest;

   public void UpdatePrizesCount()
   {
      for (int i = 0; i < _labels.Length; i++)
      {
         _labels[i].View.text = _chest.GetRewardValue(_labels[i].ReawardType).ToString();
      }
   }
}