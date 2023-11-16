using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthText : MonoBehaviour
{
    [SerializeField] private float m_TimeToLive = 0.5f;
    [SerializeField] private float m_Speed = 300f;
    [SerializeField] private Vector3 m_Direction = new Vector3(0,1,0);
    [SerializeField] public TextMeshProUGUI m_TextMesh = null;

    public static float text = 0;

    private RectTransform m_RectTransform;
    private Color m_StartingColor;

    private float m_TimeElapsed = 0.0f;

    private void Start()
    {
        m_StartingColor = m_TextMesh.color;
        m_RectTransform = GetComponent<RectTransform>();
    }

    private void Update()
    {
        m_TextMesh.text = text.ToString();

        m_TimeElapsed += Time.deltaTime;

        m_RectTransform.position += m_Direction * m_Speed * Time.deltaTime;

        m_TextMesh.color = new Color(m_StartingColor.r, m_StartingColor.g, m_StartingColor.b, 1 - (m_TimeElapsed / m_TimeToLive));

        if (m_TimeElapsed > m_TimeToLive)
        {
            Destroy(gameObject);
        }
    }
}
