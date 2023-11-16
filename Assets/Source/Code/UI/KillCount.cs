using UnityEngine;
using UnityEngine.UI;

public class KillCount : MonoBehaviour
{
    [Space(5)]
    [SerializeField] private Text killCountText = null;
    static public float killCount = 0;

    private void Update()
    {
        killCountText.text = killCount.ToString();
    }
}
