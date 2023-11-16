using UnityEngine;

public class DamageableCharacters : MonoBehaviour, IDamagable
{
    [Space(5)]
    [Header("HealthText")]
    [SerializeField] private GameObject m_HealthText = null;

    [Space(5)]
    [Header("DisableSimulation")]
    [SerializeField] private bool m_DisableSimulation = false;

    
    [Space(5)]
    [Header("isEnemy")]
    [SerializeField] private bool isEnemy = false;

    [Space(5)]
    [Header("DropIteam")]
    [SerializeField] private bool isDropIteam = false;
    [SerializeField] private GameObject m_DropIteam = null;
    [SerializeField] private Transform m_DropIteamTransform = null;

    [Space(10)]
    [Header("Parametrs")]
    [SerializeField] private float _health = 100;
    [SerializeField] private bool _targetable = true;
    [SerializeField] private bool _isDie = false;

    [HideInInspector] public Animator m_Animator;
    [HideInInspector] public Rigidbody2D m_Rigidbody2D;
    [HideInInspector] public Collider2D m_Collider2D;

    public bool IsDie => _isDie;

    private void Awake()
    {
        m_Animator = GetComponent<Animator>();
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        m_Collider2D = GetComponent<Collider2D>();
    }

    public float Health
    {
        set
        {
            if(value < _health)
            {
                m_Animator.SetTrigger("Hit");
                RectTransform rectTransform = Instantiate(m_HealthText).GetComponent<RectTransform>();
                rectTransform.transform.position = Camera.main.WorldToScreenPoint(gameObject.transform.position);

                GameObject canvasObject = GameObject.Find("Canvas");
                rectTransform.SetParent(canvasObject.transform);
            }

            _health = value;

            if (_health <= 0)
            {
                m_Animator.SetTrigger("Death");
                Targetable = false;

                _isDie = true;

                if (isEnemy)
                {
                    DropItem();
                    KillCount.killCount++;
                    EnemySpawner._currentEnemy--;
                }
                else
                {
                    Time.timeScale = 0;
                }
            }
        }
        get
        {
            return _health;
        }
    }

    public bool Targetable
    {
        get
        {
            return _targetable;
        }
        set
        {
            _targetable = value;

            if (m_DisableSimulation)
            {
                m_Rigidbody2D.simulated = false;
            }
            m_Collider2D.enabled = value;
        }
    }

    public void OnHit(float damage, Vector2 knockback)
    {
        HealthText.text = damage;

        Health -= damage;

        m_Rigidbody2D.AddForce(knockback, ForceMode2D.Impulse);
    }

    void IDamagable.OnHit(float damage)
    {
        HealthText.text = damage;

        Health -= damage;
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }

    private void DropItem()
    {
        if (isDropIteam)
        {
            Instantiate(m_DropIteam, m_DropIteamTransform.position, Quaternion.identity);
        }
    }
}