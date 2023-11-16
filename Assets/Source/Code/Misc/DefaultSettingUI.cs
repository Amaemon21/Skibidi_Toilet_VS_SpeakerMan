using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultSettingUI : MonoBehaviour
{
    [SerializeField] private GameObject m_�haracteristicsCharacter = null;
    [SerializeField] private GameObject startButton = null;

    private void Start()
    {
        m_�haracteristicsCharacter.SetActive(false);
        startButton.SetActive(false);
    }

    public void ResetUI()
    {
        m_�haracteristicsCharacter.SetActive(false);
        startButton.SetActive(false);
    }
}
