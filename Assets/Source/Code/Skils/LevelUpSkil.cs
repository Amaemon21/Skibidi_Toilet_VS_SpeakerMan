using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LevelUpSkil : Skil, IPointerEnterHandler, IPointerExitHandler
{
    [Space]
    [Header("Player Data")]
    [SerializeField] private PlayerData _playerData;

    [Space]
    [Header("Skil Data")]
    [SerializeField] private SkilData _data;
    [SerializeField] private SkilData.SkilType _type;
    [SerializeField] private TextMeshProUGUI _discriptionText;
 
    [Space]
    [SerializeField] private Characteristik _characteristik;

    [Space]
    [Header("Many")]
    [SerializeField] private ManyHolder _many;

    private Button _upLevel;

    private void Awake()
    {
        _upLevel = GetComponentInChildren<Button>();

        _upLevel.onClick.AddListener(UPLevel);
    }

    public void UPLevel()
    {
        if (_type == _data.Type)
        {
            if (_many.Many >= _startPrice)
            {
                if (_type == SkilData.SkilType.Damage)
                {
                    _playerData.damage += _data.AddValue;
                    AddLevel();
                }
                if (_type == SkilData.SkilType.Health)
                {
                    _playerData.maxHealth += _data.AddValue;
                    AddLevel();
                }
                if (_type == SkilData.SkilType.SpeedAttack)
                {
                    if(_playerData.AttackSpeed >= 0)
                    {
                        _playerData.AttackSpeed += _data.AddValue;
                        AddLevel();
                    }
                }
                if (_type == SkilData.SkilType.Knockback)
                {
                    _playerData.knockback += _data.AddValue;
                    AddLevel();
                }
                if (_type == SkilData.SkilType.Speed)
                {
                    _playerData.speed += _data.AddValue;
                    AddLevel();
                }
                if (_type == SkilData.SkilType.EXPboost)
                {
                    _playerData.EXP += _data.AddValue;
                    AddLevel();
                }
            }
        }
    }

    private void AddLevel()
    {
        _many.RemoveMany(_startPrice);

        _startPrice += _data.AddPrice;

        _level++;

        _characteristik.UpdateText();

        UpdateText();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _discriptionText.text = _data.Discrition;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _discriptionText.text = " ";
    }
}