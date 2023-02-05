using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    public GameObject hitTimeline;
    public GameObject deathTimeline;
    public Animator knifeAnim;
    float currentTime = 0f;
    float nextTimeToAttack = 0.3f;
    float attackDelta = 0.3f;
    public Attack attack;
    public Slider healthBar;
    bool dead = false;
    bool attacking = false;
    public AudioSource knifeSFX;
    public DistanceTraveled distanceTraveled;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        originalPosition = cam.transform.position;
        currentHealth = maxHealth;
        Application.targetFrameRate = 30;
    }

    void Update() 
    {
        if (currentHealth <= 0){
            dead = true;
            deathTimeline.SetActive(true);
            distanceTraveled.StopDistance();
            Invoke("DisableMovement", 1.833333f);
            Invoke("RestartLevel", 7f);
        }
       
        healthBar.value = currentHealth;
        currentTime += Time.deltaTime;
        if (Input.GetButtonDown("Fire1") && currentTime > nextTimeToAttack){
            attacking = true;
            knifeSFX.Play();
            nextTimeToAttack = currentTime + attackDelta;
            knifeAnim.SetTrigger("attack");
            attack.EnableHit();
            nextTimeToAttack -= currentTime;
            currentTime = 0.0F;
        }
        else if (currentTime < nextTimeToAttack && !Input.GetButtonDown("Fire1")){
            attacking = false;
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
    if (other.gameObject.tag == "Root" && !dead && !attacking){
        currentHealth -= 1;
        hitTimeline.SetActive(true);
        Invoke("DisableHitTimeline",1f);
    }
}
    public void DisableHitTimeline(){
        hitTimeline.SetActive(false);
    }

    public void DisableMovement(){
        speed = 0f;
        rotationSpeed = 0f;
        moveAmount = 0f;
        bounceAmount = 0f;
        knifeAnim.enabled = false;
    }
    public void RestartLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}