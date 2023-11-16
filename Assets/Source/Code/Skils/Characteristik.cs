using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Characteristik : MonoBehaviour
{
    [SerializeField] private PlayerData playerData;

    [Space]
    [SerializeField] private TextMeshProUGUI _damageText;

    [SerializeField] private TextMeshProUGUI _speedAttackText;

    [SerializeField] private TextMeshProUGUI _speedText;

    [SerializeField] private TextMeshProUGUI _healthText;

    [SerializeField] private TextMeshProUGUI _expText;

    [SerializeField] private TextMeshProUGUI _knockbackText;

    private void Start()
    {
        UpdateText();
    }

    public void UpdateText()
    {
        _damageText.text = playerData.damage.ToString("N1");
        _speedAttackText.text = playerData.AttackSpeed.ToString("N1");
        _speedText.text = playerData.speed.ToString("N1");
        _healthText.text = playerData.maxHealth.ToString("N1");
        _expText.text = playerData.EXP.ToString("N1");
        _knockbackText.text = playerData.knockback.ToString("N1");
    }
}
