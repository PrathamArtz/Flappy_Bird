using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _jumpForce = 1.5f;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private float _rotationSpeed = 10.0f;


    private void Start()
    {
        transform.position = new Vector3(0,0,0);
    }
    private void FixedUpdate()
    {
        /*
        float jumpInput = Input.GetAxis("Jump");

        transform.Translate(Vector3.up * jumpInput * _jumpForce * Time.deltaTime); */


            PlayerJump();

    }

    void PlayerJump()
    {
        if (Input.GetKey("space") || Input.GetMouseButton(0))
        {
            _rb.velocity = Vector3.up * _jumpForce;
        }

        transform.rotation = Quaternion.Euler(0, 0, _rb.velocity.y * _rotationSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameManager.instance.GameOver();
    }
}
