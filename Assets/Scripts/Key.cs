using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum KeyColor
{
    Red,
    Green,
    Gold
}

public class Key : PickUp
{
    public KeyColor keyColor;
    public override void Picked()
    {
        Debug.Log("Key picked");
        GameManager.gameManager.AddKey(keyColor);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        Rotation();
    }
}
