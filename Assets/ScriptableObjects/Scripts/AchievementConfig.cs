using UnityEngine;

[CreateAssetMenu (fileName = "AchievementSettings", menuName = "ScriptableObject/AchievementSettings")]
public class AchievementConfig : ScriptableObject
{
    public string Type => _type;
    public string Name => _name;
    public string Description => _description;
    public int Amount => _amount;
    public Sprite Icon => _icon;
    public Sprite Prize => _prize;

    [SerializeField] private string _type;
    [SerializeField] private string _name;
    [SerializeField] private string _description;
    [SerializeField] private int _amount;
    [SerializeField] private Sprite _icon;
    [SerializeField] private Sprite _prize;

}
