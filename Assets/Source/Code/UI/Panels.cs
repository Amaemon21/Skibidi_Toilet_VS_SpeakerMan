using UnityEngine;

public class Panels : MonoBehaviour
{
    [SerializeField] private GameObject _statsPanel;
    [SerializeField] private DamageableCharacters _damageableCharacters;
    private DisableMeneger _disableMeneger;

    private bool _isActive = false;

    void Awake()
    {
        _disableMeneger = GetComponent<DisableMeneger>();
        _statsPanel.SetActive(false);
    }

    private void Update()
    {
        OnStats();
    }

    private void OnStats()
    {
        if (Input.GetKeyDown(KeyCode.I) && !_isActive)
        {
            _isActive = true;
            _statsPanel.SetActive(_isActive);
        }
        else if (Input.GetKeyDown(KeyCode.I) && _isActive)
        {
            _isActive = false;
            _statsPanel.SetActive(_isActive);
        }

        if (_isActive)
        {
            _disableMeneger.Disable();
            Time.timeScale = 0;
        }
        else if(!_isActive && !_damageableCharacters.IsDie)
        {
            _disableMeneger.Enable();
            Time.timeScale = 1;
        }
    }
}