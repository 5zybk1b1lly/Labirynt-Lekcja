using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Transform door;
    public Transform openPosition;
    public Transform closedPosition;
    public bool open = false;
    float speed = 5f;


    // Start is called before the first frame update
    void Start()
    {
        door.position = closedPosition.position;
    }

    // Update is called once per frame
    void Update()
    {
        if ( open && Vector3.Distance(door.position, openPosition.position) > 0.001f)
        door.position = Vector3.MoveTowards(door.position, openPosition.position, speed * Time.deltaTime);
        
    }
    public void Open()
    {
        open = true;
    }
}
