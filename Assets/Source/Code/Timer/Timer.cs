using System.Collections;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private float _time;
    [SerializeField] private TextMeshProUGUI _timerText;

    [Space(10)]
    [SerializeField] private GameObject _winPanel;

    [Space(10)]
    [SerializeField] private DisableMeneger _disableMeneger;

    private float _timeLeft = 0f;

    private void Awake()
    {
        _disableMeneger = GetComponent<DisableMeneger>();
    }

    private IEnumerator StartTimer()
    {
        while (_timeLeft > 0)
        {
            _timeLeft -= Time.deltaTime;
            UpdateTimeText();
            yield return null;
        }
    }

    private void Start()
    {
        _timeLeft = _time;
        StartCoroutine(StartTimer());
    }

    private void UpdateTimeText()
    {
        if (_timeLeft < 0)
        {
            _timeLeft = 0;
            OpenPanel();
        }


        float minutes = Mathf.FloorToInt(_timeLeft / 60);
        float seconds = Mathf.FloorToInt(_timeLeft % 60);
        _timerText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }

    private void OpenPanel()
    {
        if(_timeLeft <= 0)
        {
            _disableMeneger.Disable();
            Time.timeScale = 0;
            _winPanel.SetActive(true);
        }
    }
}
