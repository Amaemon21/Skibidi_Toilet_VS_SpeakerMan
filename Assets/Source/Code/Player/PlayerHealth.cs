using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private PlayerData playerData;

    [SerializeField] private Slider slider_HP = null;

    [Space(10)]
    [SerializeField] private AudioClip LoseSound;
    [SerializeField] private AudioSource AudioSource;
    [SerializeField] private GameObject LosePanel;

    [SerializeField] private DisableMeneger _disableMeneger;

    public DamageableCharacters m_DamageableCharacters;

    private float _minHP = 0;

    private void Start()
    {
        slider_HP.minValue = _minHP;
        slider_HP.maxValue = playerData.maxHealth;

        m_DamageableCharacters.Health = playerData.maxHealth;

        slider_HP.value = m_DamageableCharacters.Health;
    }

    private void Update()
    {
        if(slider_HP.value > _minHP)
        {
            slider_HP.value = m_DamageableCharacters.Health;
        }

        OpenLosePanel();
    }

    private void OpenLosePanel()
    {
        if(m_DamageableCharacters.IsDie)
        {
            _disableMeneger.Disable();

            AudioSource.PlayOneShot(LoseSound);
            LosePanel.SetActive(true);  
        }
    }

    public void UpLevel()
    {       
        slider_HP.minValue = _minHP;
        slider_HP.maxValue = playerData.maxHealth;

        m_DamageableCharacters.Health = playerData.maxHealth;

        slider_HP.value = m_DamageableCharacters.Health;
    }
}