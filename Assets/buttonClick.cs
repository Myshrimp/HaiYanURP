using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonClick : MonoBehaviour
{
    public void GameStart()
    {
        SceneManager.LoadScene("Start");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
