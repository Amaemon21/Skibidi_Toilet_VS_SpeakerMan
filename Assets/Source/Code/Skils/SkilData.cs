using UnityEngine;

[CreateAssetMenu(fileName = "Character Data", menuName = "Scriptable Object/SkilsData")]
public class SkilData : ScriptableObject
{
    public enum SkilType
    {
        Damage,
        SpeedAttack,
        Knockback,
        Speed,
        Health,
        EXPboost
    }
    public SkilType Type;

    [SerializeField] private int _addPrice = 10;
    [SerializeField] private float _addValue = 10;
    [SerializeField] private string _discrition = "text";

    public int AddPrice => _addPrice;
    public float AddValue => _addValue;
    public string Discrition => _discrition;
}