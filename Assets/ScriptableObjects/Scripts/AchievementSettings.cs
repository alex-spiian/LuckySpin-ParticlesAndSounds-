using UnityEngine;

[CreateAssetMenu]
public class AchievementSettings : ScriptableObject
{
    public string Type => _type;
    public string Name => _name;
    public Vector3 NamePosition => _namePosition;
    public float NameFontSize => _nameFontSize;
    public string Description => _description;
    public Vector3 DescriptionPosition => _descriptionPosition;
    public float DescriptionFontSize => _descriptionFontSize;

    public int Amount => _amount;
    public Vector3 AmountPosition => _amountPosition;
    public float AmountFontSize => _amountFontSize;
    public Sprite Icon => _icon;
    public Vector3 IconPosition => _iconPosition;
    public Sprite Prize => _prize;
    public Vector3 PrizePosition => _prizePosition;
    public Vector2 PrizeSize => _prizeSize;
    public Sprite BackgroundSprite => _backgroundSprite;
    public Vector2 BackgroundImageSize => _backgroundImageSize;
    
    [SerializeField] private string _type;

    [SerializeField] private string _name;
    [SerializeField] private Vector3 _namePosition;
    [SerializeField] private float _nameFontSize;

    [SerializeField] private string _description;
    [SerializeField] private Vector3 _descriptionPosition;
    [SerializeField] private float _descriptionFontSize;


    [SerializeField] private int _amount;
    [SerializeField] private Vector3 _amountPosition;
    [SerializeField] private float _amountFontSize;

    [SerializeField] private Sprite _icon;
    [SerializeField] private Vector3 _iconPosition;

    [SerializeField] private Sprite _prize;
    [SerializeField] private Vector3 _prizePosition;
    [SerializeField] private Vector2 _prizeSize;

    [SerializeField] private Sprite _backgroundSprite;
    [SerializeField] private Vector2 _backgroundImageSize;
    
}
