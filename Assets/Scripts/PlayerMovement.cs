using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public int id = 0;
    [SerializeField] float speed = 5;
    Vector3 movementInput;


    void Update()
    {
        // WASD movement
        movementInput = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
            movementInput.y += 1;
        if (Input.GetKey(KeyCode.S))
            movementInput.y -= 1;
        if (Input.GetKey(KeyCode.D))
            movementInput.x += 1;
        if (Input.GetKey(KeyCode.A))
            movementInput.x -= 1;

        Move(false);


        // arrows movement

        movementInput = Vector3.zero;

        if (Input.GetKey(KeyCode.UpArrow))
            movementInput.y += 1;
        if (Input.GetKey(KeyCode.DownArrow))
            movementInput.y -= 1;
        if (Input.GetKey(KeyCode.RightArrow))
            movementInput.x += 1;
        if (Input.GetKey(KeyCode.LeftArrow))
            movementInput.x -= 1;

        Move(true);
    }

    void Move(bool changeDirection)
    {
        if (movementInput.x != 0 && movementInput.y != 0)
            movementInput.Normalize();

        float actualSpeed = speed;
        if (changeDirection)
            actualSpeed = Mathf.Abs(speed);

        transform.position += movementInput * actualSpeed * Time.deltaTime;
    }
}
