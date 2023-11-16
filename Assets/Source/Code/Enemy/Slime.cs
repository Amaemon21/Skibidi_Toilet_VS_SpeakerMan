using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class Slime : MonoBehaviour
{
    [SerializeField] private EnemyData _enemyData;  

    [Space()]
    [SerializeField] private DamageableCharacters m_DamageableCharacters;

    private GameObject _player;
    private DamageableCharacters playerDamageable;

    private void Awake()
    {
        _player = GameObject.FindWithTag("Target");
        playerDamageable = _player.GetComponentInParent<DamageableCharacters>();

    }

    private void FixedUpdate()
    {
        if (playerDamageable.Health >= 0)
        {
            if (m_DamageableCharacters.Targetable)
            {
                m_DamageableCharacters.m_Animator.SetBool("isMoving", true);

                Vector2 direction = (_player.transform.position - transform.position).normalized;

                m_DamageableCharacters.m_Rigidbody2D.MovePosition((Vector2)transform.position + direction * _enemyData.Speed * Time.deltaTime);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Collider2D collider = collision.collider;
        IDamagable m_Damagable = collider.GetComponent<IDamagable>();

        if (m_Damagable != null && collider.gameObject.tag != "Enemy")
        {
            StartCoroutine(attackEnemy(m_Damagable, _enemyData.Damage));
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        StopAllCoroutines();
    }

    private IEnumerator attackEnemy(IDamagable _damagable, float _damage)
    {
        while (true)
        {
            _damagable.OnHit(_damage);
            yield return new WaitForSeconds(_enemyData.AttackSpeed);
        }
    }
}