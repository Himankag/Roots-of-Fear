using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mENI : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public SpawnRoots spawnRoots;
    public GameObject screen;
    // Start is called before the first frame update
    void Start()
    {
        playerMovement.enabled = false;
        spawnRoots.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartPlaying(){
        screen.SetActive(false);
        playerMovement.enabled = true;
        spawnRoots.enabled = true;
    }
}
