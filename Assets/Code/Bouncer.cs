using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncer : MonoBehaviour
{
    private Vector3 _originalScale;
    private Vector3 _targetScale;
    private void Start()
    {
        _originalScale = transform.localScale;
        _targetScale = _originalScale * 2f;
    }

    private void OnCollisionEnter(Collision other)
    {
        Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
        if (rb != null)
        {
            StartCoroutine(AnimateBounce());
            var direction = other.GetContact(0).normal;
            rb.AddForce(-direction * 40f, ForceMode.Impulse);
        }
    }
    
    private IEnumerator AnimateBounce()
    {
        float timer = 0;
        while (timer <= 0.2f)
        {
            timer += Time.deltaTime;
            transform.localScale = Vector3.Lerp(_originalScale, _targetScale, timer);
            yield return null;
        }
        timer = 0;
        _targetScale = _originalScale;
        _originalScale = transform.localScale;
        while (timer <= 0.2f)
        {
            timer += Time.deltaTime;
            transform.localScale = Vector3.Lerp(_targetScale, _originalScale, timer);
            yield return null;
        }
    }
}
