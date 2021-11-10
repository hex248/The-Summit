using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float maxSpeed = 0.5f;
    float rotation = 0.0f;
    public float rotationSpeed = 2.0f;
    public float camRotationSpeed = 2.0f;

    float camRotation = 0.0f;
    GameObject cam;
    Rigidbody myRB;


    bool isOnGround;
    public GameObject groundCheck;
    public LayerMask groundLayer;
    public float jumpForce = 300.0f;

    void Start()
    {
        cam = GameObject.Find("Main Camera");
        myRB = GetComponent<Rigidbody>();
    }

    void Update()
    {
        isOnGround = Physics.CheckSphere(groundCheck.transform.position, 0.1f, groundLayer);
        
        if (isOnGround && Input.GetKeyDown(KeyCode.Space))
        {
            myRB.AddForce(transform.up * jumpForce);
        }

        Vector3 newVelocity = (transform.forward * Input.GetAxis("Vertical") * maxSpeed) + (transform.right * Input.GetAxis("Horizontal") * maxSpeed);
        myRB.velocity = new Vector3(newVelocity.x, myRB.velocity.y, newVelocity.z);

        rotation = rotation + Input.GetAxis("Mouse X") * rotationSpeed;
        transform.rotation = Quaternion.Euler(new Vector3(0.0f, rotation, 0.0f));

        camRotation = camRotation + Input.GetAxis("Mouse Y") * camRotationSpeed;

        camRotation = Mathf.Clamp(camRotation, -40.0f, 40.0f);

        cam.transform.localRotation = Quaternion.Euler(new Vector3(-camRotation, 0.0f, 0.0f));
    }
}
