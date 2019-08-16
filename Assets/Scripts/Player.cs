using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController _controller;
    [SerializeField]
    private float _speed = 5.0f;
    [SerializeField]
    private float _gravity = 1.0f;
    [SerializeField]
    private float _jumpHeight = 15.0f;
    private float _yVelocity;
    private bool _doubleJump = false;
    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    void Update()
    {
       float movement =  Input.GetAxis("Horizontal");
        Vector3 direction = new Vector3(movement, 0, 0);
        Vector3 velocity = direction * _speed;

        if (_controller.isGrounded == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _yVelocity = _jumpHeight;
            }
            _doubleJump = false;
        }
        else
        {
            if (_doubleJump == false  && Input.GetKeyDown(KeyCode.Space))
            {
                _yVelocity += _jumpHeight;
                _doubleJump = true;
            }
            _yVelocity -= _gravity;
        }
        velocity.y = _yVelocity;
        _controller.Move(velocity * Time.deltaTime);
    }
}
