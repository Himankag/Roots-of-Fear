using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnableHit(){
        GetComponent<SphereCollider>().enabled = true;
        Invoke("DisableHit", 0.3f);
    }
    public void DisableHit(){
        GetComponent<SphereCollider>().enabled = false;
    }
}
