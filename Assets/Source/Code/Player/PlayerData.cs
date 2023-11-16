using UnityEngine;

[CreateAssetMenu(fileName = "Character Data", menuName = "Scriptable Object/Player Data")]
public class PlayerData : ScriptableObject
{
    public float damage = 0;
    public float AttackSpeed = 0;
    public float knockback = 0;
    public float speed = 0;
    public float maxHealth = 0;
    public float EXP = 0;
}