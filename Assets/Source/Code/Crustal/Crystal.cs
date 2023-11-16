using System.Collections;
using UnityEngine;

public class Crystal : MonoBehaviour
{
    [SerializeField] private PlayerControler _player;
    [SerializeField] private int _speed;

    private Rigidbody2D _rigidbody2d;
    private Coroutine _coroutine;
    private bool _isCollided;

    void Start()
    {
        _rigidbody2d = GetComponent<Rigidbody2D>();

        GameObject player = GameObject.FindWithTag("Player");
        _player = player.GetComponent<PlayerControler>();

        _isCollided = false;
    }

    public void Take()
    {
        if (_coroutine == null)
        {
            _coroutine = StartCoroutine(CrystalAnimation());
        }
        if (_isCollided)
        {
            GetCrystal();
        }
    }

    IEnumerator CrystalAnimation()
    {
        _rigidbody2d.AddForce(new Vector2(_player.GetHorizontal(), _player.GetVertical()) * _speed, ForceMode2D.Impulse);

        yield return new WaitForSecondsRealtime(0.4f);

        _isCollided=true;

        StartCoroutine(Disable());

        while (true)
        {
            Vector2 direction = _player.transform.position - transform.position;
            _rigidbody2d.MovePosition(_rigidbody2d.position + direction.normalized * Time.deltaTime * _speed++);

            yield return null;
        }
    }

    IEnumerator Disable()
    {
        yield return new WaitForSeconds(0.4f);

        GetCrystal();
    }

    void GetCrystal()
    {
        Destroy(gameObject);
    }
}