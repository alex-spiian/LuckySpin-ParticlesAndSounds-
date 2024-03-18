using UnityEngine;

namespace Player
{
    [CreateAssetMenu (fileName = "PlayerConfig", menuName = "ScriptableObject/PlayerConfig")]
    public class PlayerConfig : ScriptableObject
    {
        [field:SerializeField] public float StartGoldValue { get; private set; }
        [field:SerializeField] public float StartGemsValue { get; private set; }
        [field:SerializeField] public int StartSpinsCount { get; private set; }
    }
}