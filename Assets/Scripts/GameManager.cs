using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    public int timeToEnd = 60;
    bool gamePaused = false;
    // Start is called before the first frame update
    void Start()
    {
        if (gameManager == null)
        {
            gameManager = this;
        }
        InvokeRepeating("Stopper", 1f, 1f);
        
    }

    // Update is called once per frame
    void Update()
    {
       PauseCheck(); 
    }
    void Stopper()
    {
        timeToEnd--;
        Debug.Log("Time to end: "+timeToEnd+" seconds");
    }
    public void PauseGame()
    {
        Debug.Log("Game Paused");
        Time.timeScale = 0f;
        gamePaused = true;
    }
    public void ResumeGame()
    {
        Debug.Log("Game Resumed");
        Time.timeScale = 1f;
        gamePaused = false;
    }
    void PauseCheck()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
           if (gamePaused) // gamePaused == true
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }
}
