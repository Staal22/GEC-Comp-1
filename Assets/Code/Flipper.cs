using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flipper : MonoBehaviour
{
    [SerializeField] private AnimationCurve curve;
    [SerializeField] private bool left = false;
    private Coroutine _flip;
    private Rigidbody _rb;
    private int _orientation = 1;
    private bool _flipping = false;
    
    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }
    
    private void Start()
    {
        InputHandler.Instance.OnFlip += Flip;
        _orientation = left ? -1 : 1;
    }
    
    private void Flip(bool pressedLeft)
    {
        if (_flipping) return;
        StartCoroutine(FlipRoutine(pressedLeft));
    }
    
    private IEnumerator FlipRoutine(bool pressedLeft)
    {
        if (pressedLeft == left)
        {
            _flipping = true;
            float timer = 0;
            Quaternion rotation = transform.rotation;

            while (timer <= 0.5f)
            {
                timer += Time.deltaTime;
                _rb.MoveRotation(rotation * Quaternion.Euler(0, 0, curve.Evaluate(timer) * _orientation * 90f));
                yield return null;
            }
            transform.rotation = rotation;
            _flipping = false;
        }
    }
}
