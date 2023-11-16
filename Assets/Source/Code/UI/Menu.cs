using UnityEngine;

public class Menu : MonoBehaviour
{
    public string menuName;
    public bool opened;

    public void Open()
    {
        opened = true;
        gameObject.SetActive(opened);
    }

    public void Close()
    {
        opened = false;
        gameObject.SetActive(opened);
    }
}
