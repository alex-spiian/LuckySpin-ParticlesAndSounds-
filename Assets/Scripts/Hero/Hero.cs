using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Hero : MonoBehaviour
{   
    public float Health => _health;
    public float Attack => _attack;
    public float Defence => _defence;
    public float Speed => _speed;
    public float Price => _price;
    public float CurrentExperienceValue => _currentExperienceValue;
    public float MaxExperienceValue => _maxExperienceValue;
    public int Level => _level;

    public Sprite HeroTypeIcon => _heroTypeIcon;
    public string Weapon => _weapon;
    public string Name => _name;
    
    [SerializeField] private string _name;
    [SerializeField] private string _weapon;
    
    [SerializeField] private float _health;
    [SerializeField] private float _attack;
    [SerializeField] private float _defence;
    [SerializeField] private float _speed;
    [SerializeField] private float _price;
    [SerializeField] private float _currentExperienceValue;
    [SerializeField] private float _maxExperienceValue;
    
    [SerializeField] private int _level;

    [SerializeField] private Sprite _heroTypeIcon;
    
    public GameObject HeroPrefab { get; set; }
    
}
