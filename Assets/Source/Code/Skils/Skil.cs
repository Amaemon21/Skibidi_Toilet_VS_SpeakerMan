using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Skil : MonoBehaviour
{
    public int _startPrice;
    protected int _level;

    public TextMeshProUGUI _priceText;
    public TextMeshProUGUI _levelText;

    private void OnEnable()
    {
        UpdateText();
    }

    protected void UpdateText()
    {
        _priceText.text = _startPrice.ToString();
        _levelText.text = _level.ToString() + "-Óð";
    }
}