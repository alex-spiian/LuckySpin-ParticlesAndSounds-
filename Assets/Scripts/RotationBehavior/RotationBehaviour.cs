using UnityEngine;

namespace DefaultNamespace.RotationBehaviour
{
    public class RotationBehavior : MonoBehaviour
    {
        [SerializeField]
        private float _rotationSpeed;

        private void FixedUpdate()
        {
            transform.Rotate(Vector3.forward, _rotationSpeed * Time.deltaTime);
        }
    }
}