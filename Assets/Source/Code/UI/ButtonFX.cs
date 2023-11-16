using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonFX : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
{ 
    [Space]
    [Header("AudioSource")]
    [SerializeField] private AudioSource m_AudioSource;

    [Space]
    [Header("Hover Fx")]
    [SerializeField] private AudioClip hoverFx;

    [Space]
    [Header("Click Fx")]
    [SerializeField] private AudioClip clickFx;

    public void OnPointerClick(PointerEventData eventData)
    {
        m_AudioSource.PlayOneShot(clickFx);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        m_AudioSource.PlayOneShot(hoverFx);
    }
}