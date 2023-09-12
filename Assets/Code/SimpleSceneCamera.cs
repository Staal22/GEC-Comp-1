using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleSceneCamera : MonoBehaviour
{
    [SerializeField] GameObject target;
    [SerializeField] float distance = 150f;

    private void Start()
    {
        transform.position = target.transform.position + new Vector3(distance / 3, distance, distance / 3);
        transform.LookAt(target.transform);
    }
}
