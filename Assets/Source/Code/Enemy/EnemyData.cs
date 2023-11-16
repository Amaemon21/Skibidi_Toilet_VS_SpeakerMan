using UnityEngine;

[CreateAssetMenu(fileName = "Character Data", menuName = "Scriptable Object/Enemy Data")]
public class EnemyData : ScriptableObject
{
    [SerializeField] private float _damage = 0;
    [SerializeField] private float _attackSpeed = 0;
    [SerializeField] private float _speed = 0;
    [SerializeField] private float _maxHealth = 0;

    public float Damage => _damage;
    public float AttackSpeed => _attackSpeed;
    public float Speed => _speed;
    public float MaxHealth => _maxHealth;

    public void AddDamage(float value)
    {
        _damage += value;
    }

    public void AddSpeed(float value)
    {
        _speed += value;
    }

    public void AddAttackSpeed(float value)
    {
        _attackSpeed += value;
    }

    public void AddMaxHealth(float value)
    {
        _maxHealth += value;
    }
}
