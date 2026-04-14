using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour
{
    bool iCanOpen = false;
    public Door[] doors;
    public KeyColor myColor;
    bool locked = false;
    Animator key;
    // Start is called before the first frame update
    void Start()
    {
        key = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (iCanOpen && !locked && Input.GetKeyDown(KeyCode.E))
        {
            key.SetBool("useKey", CheckTheKey());
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            iCanOpen = true;
            Debug.Log("You can use lock");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            iCanOpen = false;
            Debug.Log("You can't use lock");
        }
    }
    public void UseKey()
    {
        foreach (Door door in doors)
        {
            door.Open();
        }
    }
    public bool CheckTheKey()
    {
        if (GameManager.gameManager.redKey > 0 && myColor == KeyColor.Red)
        {
            GameManager.gameManager.redKey--;
            locked = true;
            return true;
        }
        else if (GameManager.gameManager.greenKey > 0 && myColor == KeyColor.Green)
        {
            GameManager.gameManager.greenKey--;
            locked = true;
            return true;
        }
        else if (GameManager.gameManager.goldKey > 0 && myColor == KeyColor.Gold)
        {
            GameManager.gameManager.goldKey--;
            locked = true;
            return true;
        }
        else
        {
            Debug.Log("You don't have the key");
            return false;
        }
    }
}
