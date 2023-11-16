using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonScaler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Space(5)]
    [Header("Color")]
    [SerializeField] private Color m_selectedColor;
    [SerializeField] private Color m_DeselectedColor;

    [Space]
    [Header("Scale")]
    [SerializeField] private float normal = 1.0f;
    [SerializeField] private float scale = 1.1f;

    [SerializeField] private bool isText = true;

    private Text m_ButtonText;

    private void Awake()
    {
        if(isText)
            m_ButtonText = GetComponentInChildren<Text>();
    }

    public void OnDisable()
    {
        gameObject.transform.localScale = new Vector3(normal, normal, normal);

        if (isText)
            m_ButtonText.color = m_DeselectedColor;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        gameObject.transform.localScale = new Vector3(scale, scale, scale);

        if (isText)
            m_ButtonText.color = m_selectedColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        gameObject.transform.localScale = new Vector3(normal, normal, normal);

        if (isText)
            m_ButtonText.color = m_DeselectedColor;
    }
}