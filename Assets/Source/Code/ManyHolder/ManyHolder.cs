using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ManyHolder : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _manyText;
    [SerializeField] private int _startMany;

    private int _many;
    public int Many => _many;

    private void Start()
    {
        _many = _startMany;

        UpdateText();
    }

    public void AddMany(int value)
    {
        _many += value;
        UpdateText();
    }

    public void RemoveMany(int value)
    {
        _many -= value;
        UpdateText();
    }

    private void UpdateText()
    {
        _manyText.text = _many.ToString();
    }

}
