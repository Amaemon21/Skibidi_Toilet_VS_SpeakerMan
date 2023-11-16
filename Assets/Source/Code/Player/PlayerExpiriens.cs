using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerExpiriens : MonoBehaviour
{
    [SerializeField] private PlayerData _playerData;

    [Space()]
    [Header("Experience Slider")]
    [SerializeField] private Slider _experienceSlider = null;
    [SerializeField] private int _maxValue = 100;

    [Space()]
    [Header("Add Experience one Gem")]
    [SerializeField] private int _addExperienceOneGem = 10;
    [SerializeField] private int _addExperiencNextlevel = 100;

    [Space()]
    [Header("Text and Level")]
    [SerializeField] private TextMeshProUGUI _levelText = null;
    
    [Space(5)]
    [SerializeField] private ManyHolder _many;
    [SerializeField] private EnemySpawner _enemySpawner;

    [Space(5)]
    [SerializeField] private int _addMaxEnemy = 0;
    [SerializeField] private float _removeSpawmDelay = 0;

    private PlayerHealth _playerHealth;

    private int _minValue = 0;
    private int _currentExperience = 0;
    private int _level = 1;

    private void Awake()
    {
        _playerHealth = GetComponent<PlayerHealth>();

        _currentExperience = _minValue;

        InterfaceUpdate();
    }

    private void AddExperience()
    {
        if (_currentExperience <= _maxValue)
        {
            _currentExperience += _addExperienceOneGem;

            if(_currentExperience >= _maxValue)
            {
                levelUp();
            }
        }

        InterfaceUpdate();
    }

    private void levelUp()
    {
        _level++;
        _maxValue += _addExperiencNextlevel;
        _currentExperience = _minValue;
        _playerHealth.UpLevel();

        if (_level % 2 == 0)
        {
            _enemySpawner.AddMaxEnemy(_addMaxEnemy);
        }
        else
        {
            _enemySpawner.AddMaxEnemy(_addMaxEnemy, _removeSpawmDelay);
        }
    }

    private void InterfaceUpdate()
    {
        _levelText.text = $"{_level} - ур.";
        _experienceSlider.value = _currentExperience;
        _experienceSlider.minValue = _minValue;
        _experienceSlider.maxValue = _maxValue;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Gem"))
        {
            Crystal crystal = collision.GetComponent<Crystal>();
            crystal.Take();
            _many.AddMany((int)_playerData.EXP);

            AddExperience();
        }
    }
}