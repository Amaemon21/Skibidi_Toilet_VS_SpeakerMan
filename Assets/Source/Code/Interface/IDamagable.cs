using UnityEngine;

public interface IDamagable
{
    public float Health { set; get; }
    public bool Targetable { set; get; }
    public void OnHit(float damage, Vector2 knockback);
    public void OnHit(float damage);
}
