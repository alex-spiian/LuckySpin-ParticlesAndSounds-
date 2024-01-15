using UnityEngine;

namespace Arrow
{
    public class ArrowController : MonoBehaviour
    {
        public string GetWonPrizeName { get; private set; }

        private void OnTriggerEnter(Collider other)
        {
            GetWonPrizeName = other.tag;
        }
    }
}