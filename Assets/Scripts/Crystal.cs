using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : PickUp
{
    public int points = 5;
    public override void Picked()
    {
        Debug.Log("Crystal picked");
        GameManager.gameManager.AddPoints(points);
        Destroy(gameObject);
    }
    

    // Update is called once per frame
    void Update()
    {
        Rotation();
    }
}
