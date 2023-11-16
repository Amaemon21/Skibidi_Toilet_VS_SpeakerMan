using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultSettingUI : MonoBehaviour
{
    [SerializeField] private GameObject m_ÑharacteristicsCharacter = null;
    [SerializeField] private GameObject startButton = null;

    private void Start()
    {
        m_ÑharacteristicsCharacter.SetActive(false);
        startButton.SetActive(false);
    }

    public void ResetUI()
    {
        m_ÑharacteristicsCharacter.SetActive(false);
        startButton.SetActive(false);
    }
}
