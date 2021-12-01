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

    public GameObject mesh;


    bool isOnGround;
    public GameObject groundCheck;
    public LayerMask groundLayer;
    public float jumpForce = 300.0f;

    public int score = 0;

    public Animator animator;

    AudioSource sfxSource;

    void Start()
    {
        cam = GameObject.Find("Main Camera");
        myRB = GetComponent<Rigidbody>();
        score = 0;

        sfxSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        isOnGround = Physics.CheckSphere(groundCheck.transform.position, 0.1f, groundLayer);
        animator.SetBool("isOnGround", isOnGround);

        if (isOnGround && Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("jumped");
            myRB.AddForce(transform.up * jumpForce);
        }

        Vector3 newVelocity = (transform.forward * Input.GetAxis("Vertical") * maxSpeed) + (transform.right * Input.GetAxis("Horizontal") * maxSpeed);
        if (Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0)
        {
            mesh.transform.rotation = transform.rotation;
        }
        myRB.velocity = new Vector3(newVelocity.x, myRB.velocity.y, newVelocity.z);
        animator.SetFloat("speed", newVelocity.magnitude);
        mesh.transform.position = transform.position;

        if ((myRB.velocity.magnitude > 1.0f) && (!sfxSource.isPlaying))
        {
            sfxSource.volume = Random.Range(0.8f, 1.0f);
            sfxSource.pitch = Random.Range(0.8f, 1.1f);
            sfxSource.Play();
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Pickup"))
        {
            score++;
            Destroy(col.transform.parent.gameObject);
        }
    }
}
