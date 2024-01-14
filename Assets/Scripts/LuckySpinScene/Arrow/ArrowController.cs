using UnityEngine;

namespace Arrow
{
    public class ArrowController : MonoBehaviour
    {
        public string GetWonPrizeName => _lastWonPrizeName;
        
        private string _lastWonPrizeName;

        private void OnTriggerEnter(Collider other)
        {

            _lastWonPrizeName = other.tag;
        }
    }
}