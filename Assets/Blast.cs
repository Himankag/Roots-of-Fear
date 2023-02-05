using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blast : MonoBehaviour
{
    public float explosionForce = 10.0f;
    public float explosionRadius = 5.0f;
    public Vector3 explosionPoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Rigidbody>() != null)
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            rb.AddExplosionForce(explosionForce, explosionPoint, explosionRadius);
        }
    }
}
