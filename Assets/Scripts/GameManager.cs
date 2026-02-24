using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    public int timeToEnd = 60;
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
        
    }
    void Stopper()
    {
        timeToEnd--;
        Debug.Log("Time to end: "+timeToEnd+" seconds");
    }
}
