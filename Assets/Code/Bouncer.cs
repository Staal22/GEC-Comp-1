using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncer : MonoBehaviour
{
    private GameObject _mesh;
    private Vector3 _originalScale;
    private Vector3 _targetScale;
    private bool _isAnimating = false;

    private void Awake()
    {
        _mesh = transform.GetChild(0).gameObject;
    }

    private void Start()
    {
        _originalScale = _mesh.transform.localScale;
        _targetScale = _originalScale * 1.3f;
    }

    private void OnCollisionEnter(Collision other)
    {
        Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
        if (rb != null && !_isAnimating)
        {
            var direction = other.GetContact(0).normal;
            var velocity = -1 * rb.velocity;
            rb.AddForce(-direction * 80 + velocity, ForceMode.Impulse);
            _isAnimating = true;
            StartCoroutine(AnimateBounce());
        }
    }
    
    private IEnumerator AnimateBounce()
    {
        float timer = 0;
        float duration = 0.2f;
    
        while (timer < duration)
        {
            timer += Time.deltaTime;
            float percent = Mathf.SmoothStep(0, 1, timer / duration);
            _mesh.transform.localScale = Vector3.Lerp(_originalScale, _targetScale, percent);
            yield return null;
        }

        timer = 0;

        while (timer < duration)
        {
            timer += Time.deltaTime;
            float percent = Mathf.SmoothStep(0, 1, timer / duration);
            _mesh.transform.localScale = Vector3.Lerp(_targetScale, _originalScale, percent);
            yield return null;
        }
    
        _isAnimating = false;
    }
}
