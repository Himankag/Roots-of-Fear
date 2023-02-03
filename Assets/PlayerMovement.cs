using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10f;
    public float tiltAmount = 10f;
    private Quaternion targetRotation;
    public float rotationSpeed = 10f;
    public float moveAmount = 10f;
    public GameObject cam;
    public float bounceAmount = 0.1f;
    public float bounceSpeed = 2f;
    private float currentBounce;
    private Vector3 originalPosition;
    private Rigidbody rb;
    public int maxHealth;
    public int currentHealth;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        originalPosition = cam.transform.position;
        currentHealth = maxHealth;
    }

    void Update() 
    {
        if (currentHealth <= 0){
            GetComponent<Animator>().SetBool("dead", true);
        }
        // Move the player forward at a constant speed
        rb.velocity = (transform.forward * speed) + (transform.right * moveAmount * Input.GetAxis("Horizontal"));
        
        currentBounce = bounceAmount * Mathf.Sin(Time.time * bounceSpeed);

        // Apply the bounce offset to the camera position
        cam.transform.position += new Vector3(0f, currentBounce, 0f);
        targetRotation = Quaternion.Euler(0f, 0f, -tiltAmount * Input.GetAxis("Horizontal"));

        // Smoothly rotate the camera towards the target rotation
        cam.transform.rotation = Quaternion.Lerp(cam.transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
    }


    private void OnTriggerEnter(Collider other) {
    if (other.gameObject.tag == "Root"){
        currentHealth -= 1;
    }
}
}