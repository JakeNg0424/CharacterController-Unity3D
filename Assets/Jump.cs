using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    Vector3 moveVector = Vector3.zero;
    CharacterController characterController;
    public float jumpSpeed = 12;
    public float gravity = 6;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (characterController.isGrounded && Input.GetButton("Jump"))
        {
            moveVector.y = jumpSpeed;
        }
        moveVector.y -= gravity * Time.deltaTime;
        characterController.Move(moveVector * Time.deltaTime);
    }
}
