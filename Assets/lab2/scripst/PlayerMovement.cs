using UnityEngine;
using System;
using System.IO;
using System.Collections.Generic;
public class PlayerMovement : MonoBehaviour
{
    public float forwardSpeed = 5f; 
    public float horizontalSpeed = 5f; 
    public float jumpForce = 7f; 
    public LayerMask groundLayer;
    public float boostSpeed = 25f; 
    public float boostDuration = 3f; 
    private float boostTimeLeft = 0f;

    private Rigidbody rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        GameManager.Instance.OnGameOver += HandleGameOver;

    }
    void OnDestroy()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.OnGameOver -= HandleGameOver;
        }
    }
    void HandleGameOver()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Finish")
        {
            GameManager.Instance.TriggerGameOver();
        }
    }

    void Update()
    {
        float currentSpeed = (boostTimeLeft > 0) ? boostSpeed : forwardSpeed;

        transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.LeftShift) && boostTimeLeft <= 0)
        {
            boostTimeLeft = boostDuration;
        }

        if (boostTimeLeft > 0)
        {
            boostTimeLeft -= Time.deltaTime;
        }

        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);
        
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * horizontalSpeed * Time.deltaTime);

        isGrounded = Physics.Raycast(transform.position, Vector3.down, 1.1f, groundLayer);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
