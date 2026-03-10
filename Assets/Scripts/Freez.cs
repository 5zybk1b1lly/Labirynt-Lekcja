using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freez : PickUp
{
    public int freezeTime = 10;
    public override void Picked()
    {
        Debug.Log("Freez picked");
        GameManager.gameManager.FreezeTime(freezeTime);
        Destroy(gameObject);
    }
    

    // Update is called once per frame
    void Update()
    {
        Rotation();
    }
}
