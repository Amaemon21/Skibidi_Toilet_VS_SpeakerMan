using UnityEngine;

public class SwordHitBox : MonoBehaviour
{
    [SerializeField] private PlayerData _playerData;

    public BoxCollider2D m_Collider = null;

    private void Start()
    {
        m_Collider.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IDamagable damagleObject = collision.GetComponent<IDamagable>();

        if (damagleObject != null)
        {
            Vector3 parentPosition = transform.parent.position;
            Vector2 direction = (collision.transform.position - parentPosition).normalized;
            Vector2 knockback = direction * _playerData.knockback;

            damagleObject.OnHit(_playerData.damage, knockback);
        }
    }
}