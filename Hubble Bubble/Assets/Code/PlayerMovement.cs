using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] float moveSpeed;

    [SerializeField] float verticalSpeed;

    [Header("KeyBinds")]
    public KeyCode raiseKey = KeyCode.LeftShift;
    public KeyCode lowerKey = KeyCode.LeftControl;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 movedirection;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        MoveInput();
        SpeedControl();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    void MoveInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if (Input.GetKey(raiseKey)) 
        {
            Raise();
        }
        else if (Input.GetKey(lowerKey)) 
        {
            Lower();
        }
    }

    void MovePlayer()
    {
        movedirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        rb.AddForce(movedirection.normalized * moveSpeed * 10f, ForceMode.Force);
    }

    void SpeedControl() 
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if (flatVel.magnitude > moveSpeed) 
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }
    void Raise() 
    {
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * verticalSpeed, ForceMode.Impulse);
    }

    void Lower()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(-transform.up * verticalSpeed, ForceMode.Impulse);
    }
}
