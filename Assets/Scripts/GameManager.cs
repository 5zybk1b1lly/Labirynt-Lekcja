using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    public int timeToEnd = 10;
    bool gamePaused = false;
    bool endGame = false;
    bool win = false;
    public int points = 0;
    public int redKey = 0;
    public int greenKey = 0;
    public int goldKey = 0;
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
        PickupCheck();
    }
    void Stopper()
    {
        timeToEnd--;
        Debug.Log("Time to end: "+timeToEnd+" seconds");

        if (timeToEnd <= 0)
        {
            timeToEnd = 0;
            endGame = true;
        }

        if (endGame)
        {
            EndGame();
        }
            
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
    public void EndGame()
    {
        CancelInvoke("Stopper");
        if (win)
        {
            Debug.Log("You win! Reload?");
        }
        else
        {
            Debug.Log("You lose! Reload?" );
        }
    }

    public void AddPoints(int point)
    {
        points += point;
    }
    public void AddTime(int time)
    {
        timeToEnd += time;
    }
    public void FreezeTime(int freez)
    {
        CancelInvoke("Stopper");
        InvokeRepeating("Stopper", freez, 1f);
    }
    public void AddKey(KeyColor keyColor)
    {
        switch (keyColor)
        {
            case KeyColor.Red:
                redKey++;
                break;
            case KeyColor.Green:
                greenKey++;
                break;
            case KeyColor.Gold:
                goldKey++;
                break;
        }
    }
    void PickupCheck()
    {   
        if (Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log("----------------------");
            Debug.Log("Points: " + points);
            Debug.Log("Red keys: " + redKey);
            Debug.Log("Green keys: " + greenKey);
            Debug.Log("Gold keys: " + goldKey);
            Debug.Log("Time to end: " + timeToEnd);
            Debug.Log("----------------------");
        }
    }
}
