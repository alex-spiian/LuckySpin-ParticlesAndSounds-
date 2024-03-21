using UnityEngine;

namespace DefaultNamespace.DailyGift
{
    public class DailyGiftController : MonoBehaviour
    {
        private void Awake()
        {
            if (PlayerPrefs.GetInt(PlayerPrefsNames.SPINS) == 0)
            {
                gameObject.SetActive(false);
            }
        }
    }
}