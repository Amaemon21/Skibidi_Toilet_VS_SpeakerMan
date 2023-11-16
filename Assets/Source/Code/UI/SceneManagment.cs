using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagment : MonoBehaviour
{
    [SerializeField] private int _sceneIndex = 0;

    private void OnValidate()
    {
        if(_sceneIndex < 0)
            _sceneIndex = 0;
    }

    public void MainMenuStart()
    {
        if (SelectCharacter.isSelected)
        {
            SceneManager.LoadScene(_sceneIndex);
        }
    } 
    
    public void ExitInGame()
    {
        SceneManager.LoadScene(_sceneIndex);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
