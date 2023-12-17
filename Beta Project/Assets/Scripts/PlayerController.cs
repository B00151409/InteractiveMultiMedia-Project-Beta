using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public float jumpForce = 1;
    public float moveSpeed = 5;
    private int jumpsLeft = 2;

    private float horizontalInput;
    public Transform groundCheck;
    public LayerMask layerMask;
    private MeshRenderer meshRenderer;
    [SerializeField] private AudioSource jumpSound;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        meshRenderer = GetComponentInChildren<MeshRenderer>();
    }

    void Update()
    {
        // Side to side movement
        horizontalInput = Input.GetAxis("Horizontal");

        Vector3 movement = new Vector3(0, 0, horizontalInput);
        transform.Translate(movement * moveSpeed * Time.deltaTime);

        if (isGrounded())
        {

            jumpsLeft = 2;
        }

        if (Input.GetKeyDown("space") && jumpsLeft > 0)
        {
            jumpSound.Play();
            playerRb.velocity = new Vector2(playerRb.velocity.x, jumpForce);
            jumpsLeft--;
        }
       
    }
    

    bool isGrounded()
    {
       return Physics.CheckSphere(groundCheck.position, .1f, layerMask);
    }

}
