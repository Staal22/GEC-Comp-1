using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandlingExample : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        Debug.LogWarning($"Collided with {other.gameObject.name}");
    }
}
