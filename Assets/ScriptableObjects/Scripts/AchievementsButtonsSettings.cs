using TMPro;
using UnityEngine;

namespace ScriptableObjects.ClaimButton
{
    [CreateAssetMenu]
    public class AchievementsButtonsSettings : ScriptableObject
    {
        [field:SerializeField]
        public Sprite Sprite { get; private set; }
        [field:SerializeField]
        public string Text { get; private set; }
        [field:SerializeField]
        public float TextFontSize { get; private set; }
        [field:SerializeField]
        public Vector2 Size { get; private set; }
        
        [field:SerializeField]
        public Vector3 ButtonPosition { get; private set; }
        
        [field:SerializeField]
        public Vector3 TextPosition { get; private set; }
    }
}