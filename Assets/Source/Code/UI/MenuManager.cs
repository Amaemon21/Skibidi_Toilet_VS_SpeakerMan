using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance = null;

    [SerializeField] private Menu[] m_Menus;

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    public void OpenMenu(string menuName)
    {
        for (int i = 0; i < m_Menus.Length; i++)
        {
            if (m_Menus[i].menuName == menuName)
            {
                m_Menus[i].Open();
            }
            else if (m_Menus[i].opened)
            {
                CloseMenu(m_Menus[i]);
            }
        }
    }

    public void OpenMenu(Menu menu)
    {
        for (int i = 0; i < m_Menus.Length; i++)
        {
            if (m_Menus[i].opened)
            {
                CloseMenu(m_Menus[i]);
            }
        }

        menu.Open();
    }

    public void CloseMenu(Menu menu)
    {
        menu.Close();
    }
}
