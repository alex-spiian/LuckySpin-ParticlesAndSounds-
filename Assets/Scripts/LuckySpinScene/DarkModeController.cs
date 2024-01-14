using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class DarkModeController : MonoBehaviour
    {
  
        public void SwitchDarkModeOn()
        {
            gameObject.SetActive(true);
            
        }
        
        public void ResetDarkScreenMode()
        {
            gameObject.SetActive(false);
            
        }
        
    }
}