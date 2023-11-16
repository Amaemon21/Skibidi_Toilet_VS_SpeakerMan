using UnityEngine;
using UnityEngine.UI;

public class ShowFps : MonoBehaviour
{
    [SerializeField] private static float fps;

    void OnGUI()
    {
        fps = 1.0f / Time.deltaTime;

        GUI.Label(new Rect(10, 560, 100, 20), "FPS: " + (int)fps);
    }
}
