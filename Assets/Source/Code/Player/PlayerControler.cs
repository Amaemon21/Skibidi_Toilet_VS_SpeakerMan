using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControler : MonoBehaviour
{
    [Space]
    [Header("ScriptableObject")]
    [SerializeField] private PlayerData playerData;

    [Space]
    [SerializeField] private AudioClip[] _attackSound;
    [SerializeField] private AudioSource _audioSource;

    [Space(5)]
    [Header("Scripts")]
    [SerializeField] private DamageableCharacters _damageableCharacters;
    [SerializeField] private SwordHitBox _swordHitBox;

    private bool _isAttack = true;
    private Vector2 _movmentInput;
    private float _horizontal = 0;
    private float _vertical = 0;

    private void Update()
    {
        _horizontal = Input.GetAxisRaw("Horizontal");
        _vertical = Input.GetAxisRaw("Vertical");

        FlipXPlayer();
    }

    private void FixedUpdate()
    {
        RotationMove();

        _damageableCharacters.m_Rigidbody2D.MovePosition(_damageableCharacters.m_Rigidbody2D.position + _movmentInput * playerData.speed * Time.deltaTime);
    }

    private void OnMove(InputValue movmentValue)
    {
        _movmentInput = movmentValue.Get<Vector2>();
    }

    private void OnFire()
    {
        if (_damageableCharacters.Health > 0 && _isAttack == true)
        {
            _audioSource.PlayOneShot(_attackSound[Random.Range(0, _attackSound.Length)]);
            _damageableCharacters.m_Animator.SetTrigger("swordAttack");
            StartCoroutine(AttackSpeed());
        }
    }

    public void StartAttack()
    {
        _swordHitBox.m_Collider.enabled = true;
    }
    public void EndAttack()
    {
        _swordHitBox.m_Collider.enabled = false;
    }

    private void RotationMove()
    {
        if (_damageableCharacters.Health > 0)
        {
            _damageableCharacters.m_Animator.SetFloat("Horizontal", _movmentInput.x);
            _damageableCharacters.m_Animator.SetFloat("Speed", _movmentInput.sqrMagnitude);

            if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1)
            {
                _damageableCharacters.m_Animator.SetFloat("LastHorizontal", Input.GetAxisRaw("Horizontal"));
            }
        }
    }

    private void FlipXPlayer()
    {
        if (Input.GetAxisRaw("Horizontal") > 0.01)
        {
            _swordHitBox.transform.localScale = new Vector3(1, 1, 1);
        }

        if(Input.GetAxisRaw("Horizontal") < -0.01)
        {
            _swordHitBox.transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    public float GetHorizontal()
    {
        return _horizontal;
    }

    public float GetVertical()
    {
        return _vertical;
    }

    private IEnumerator AttackSpeed()
    {
        _isAttack = false;
        yield return new WaitForSeconds(playerData.AttackSpeed);
        _isAttack = true;
    }
}