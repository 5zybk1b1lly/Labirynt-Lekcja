using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 12f;
    Vector3 velocity;
    CharacterController controller;
    public Transform groundCheck;
    public LayerMask groundMask; 


    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>(); 
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
    }

    void PlayerMove()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        RaycastHit hit;

        if (Physics.Raycast(groundCheck.position, Vector3.down, out hit, .4f, groundMask))
        {
            string terrainType = hit.collider.gameObject.tag;

            switch (terrainType)
            {
                case "Standard":
                    speed = 12f;
                    break;
                case "Low":
                    speed = 3f;
                    break;
                case "High":
                    speed = 20f;
                    break;
                default:
                    speed = 12f;
                    break;
            }
        }

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "PickUp")
        {
            hit.gameObject.GetComponent<PickUp>().Picked();
        }
    }
}
