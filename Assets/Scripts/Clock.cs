using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : PickUp
{
    public uint time = 5;
    public bool addTime;
    public override void Picked()
    {
        Debug.Log("Clock picked");
        int sign;
        if (addTime)
        {
            sign = 1;
        }
        else
        {
            sign = -1;
        }
        GameManager.gameManager.AddTime((int)time * sign);
        Destroy(gameObject);
    }
    

    // Update is called once per frame
    void Update()
    {
        Rotation();
    }
}
