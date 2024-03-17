using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject deathreminder;
    public static GameManager instance;
    [SerializeField] GameObject exitMenu;
    private bool pause = false;
    private bool menuDisplay = false;
    private float tempPauseTime;
    private float timer = 0f;
    private bool startCount = false;
    private void Start()
    {
        instance = this;
        exitMenu.SetActive(false);
    }
    private void Update()
    {

        if (player.GetComponent<Player>().GetHealth() <= 0)
        {
            menuDisplay = true;
            pause = true;
            deathreminder.SetActive(true);
        }
        else
        {
            deathreminder.SetActive(false);
        }
        if (startCount)
        {
            timer += 1;
        }
        if(timer > tempPauseTime)
        {
            startCount = false;
            timer = 0f;
            Continue();
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            menuDisplay = !menuDisplay;
            pause = !pause;
            
        }
   

        if (pause)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
        exitMenu.SetActive(menuDisplay);
        
    }
    public void Pause()
    {
        pause = true;
    }
    public void Continue()
    {
        pause = false;
    }
    public void CloseMenu()
    {
        menuDisplay = false;
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void PauseForALimitedTime(float time)
    {
        Debug.Log("Paaused");
        Pause();
        tempPauseTime = time;
        startCount = true;
    }
    public void SceneLoad()
    {
        SceneManager.LoadScene("Boss");
    }
}
