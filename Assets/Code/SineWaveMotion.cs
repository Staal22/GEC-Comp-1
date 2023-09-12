using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SineWaveMotion : MonoBehaviour
{
    private Vector3 _position;
    // Start is called before the first frame update
    void Start()
    {
        _position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // move gameObject in a repeating sine wave motion
        transform.position = _position + new Vector3(Time.time, Mathf.Sin(Time.time), 0);
    }
}
