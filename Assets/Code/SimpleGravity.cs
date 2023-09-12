using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleGravity : MonoBehaviour
{
    Rigidbody rb;
    
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }
    
    void FixedUpdate()
    {
        rb.AddForce(Vector3.down * 9.81f, ForceMode.Acceleration);
    }
}
