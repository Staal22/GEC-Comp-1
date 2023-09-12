using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ExamplePhysicsMovement : MonoBehaviour
{
    
    [SerializeField] Rigidbody rb;
    int _timeStep = 0;
    float _speed = 10f;
    
    // Start is called before the first frame update
    void Start()
    {
        // reference to the rigidbody
        rb = gameObject.GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        // gravity
        rb.AddForce(Vector3.down * _speed, ForceMode.Acceleration);

        if (_timeStep >= 100)
        {
            int direction = Random.Range(0, 3);
            if (direction == 0)
            {
                rb.AddForce(gameObject.transform.right * -_speed, ForceMode.Impulse);
            }
            else if (direction == 1)
            {
                rb.AddForce(gameObject.transform.right * _speed, ForceMode.Impulse);
            }
            else
            {
                rb.AddForce(gameObject.transform.up * _speed, ForceMode.Impulse);
            }
            _timeStep = 0;
            _speed = Random.Range(5, 50);
        }
        else
        {
            _timeStep++;
        }
    }
}
