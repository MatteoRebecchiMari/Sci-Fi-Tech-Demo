using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    CharacterController _controller;

    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        if(_controller == null)
        {
            Debug.LogError("CharacterController not found!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovements();
    }

    [SerializeField]
    float _speed = 3.5f;

    [SerializeField]
    float _gravity = 9.81f;

    /// <summary>
    /// Handle player movementes
    /// </summary>
    void HandleMovements()
    {
        // Handle User Input
        // NOTE: GetAxis --> See Input Manager in Unity Editor
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");


        // Convert the input into motion DIRECTION
        Vector3 direction = new Vector3(horizontalInput, 0, verticalInput);


        // Handle Gravity
        if (_controller.isGrounded == false)
        {
            direction.y -= _gravity;
        }

        // Convert the local player direction into a GLOBAL motion
        // (controller.Move() method handle ABSOLUTE movements (not relative to the gameobject))
        Vector3 worldSpaceDirection = transform.TransformDirection(direction);

        // Move the player
        _controller.Move(worldSpaceDirection * _speed * Time.deltaTime);

    }

}
