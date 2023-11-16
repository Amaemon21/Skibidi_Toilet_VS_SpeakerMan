using UnityEngine;

public class SelectCharacter : MonoBehaviour
{
    [SerializeField] private GameObject[] m_characteristicsCharacter = null;
    [SerializeField] private GameObject startButton = null;

    private int m_targetCharacter;
    static public bool isSelected = false;

    public void targetCharacter(int index)
    {
        m_characteristicsCharacter[index].SetActive(true);
        isSelected = true;  
        m_targetCharacter = index;
        startButton.SetActive(true);
    }
}