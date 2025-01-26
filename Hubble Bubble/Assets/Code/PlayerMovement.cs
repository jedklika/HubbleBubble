using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]

    [SerializeField] float verticalSpeed;

    [Header("KeyBinds")]
    public KeyCode raiseKey = KeyCode.LeftShift;
    public KeyCode lowerKey = KeyCode.LeftControl;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 movedirection;

    Rigidbody rb;

    GameManager GM;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        GM = FindObjectOfType<GameManager>();
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

        rb.AddForce(movedirection.normalized * GM.Speed * 10f, ForceMode.Force);
    }

    void SpeedControl() 
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if (flatVel.magnitude > GM.Speed) 
        {
            Vector3 limitedVel = flatVel.normalized * GM.Speed;
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
