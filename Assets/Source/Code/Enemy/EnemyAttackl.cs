using System.Collections;
using UnityEngine;

public class EnemyAttackl : MonoBehaviour
{
    [SerializeField] private float m_Damage = 10;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Collider2D collider = collision.collider;
        IDamagable damagable = collider.GetComponent<IDamagable>();

        if (damagable != null)
        {
            StartCoroutine(attackEnemy(damagable, m_Damage));
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
            yield return new WaitForSeconds(0.25f);
            Debug.Log("true");
        }
    }
}
