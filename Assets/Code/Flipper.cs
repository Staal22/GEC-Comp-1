using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flipper : MonoBehaviour
{
    [SerializeField] private AnimationCurve curve;
    [SerializeField] private bool left = false;
    private int _orientation = 1;
    private bool _flipping = false;
    private Coroutine _flip;

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
            Vector3 rotation = transform.localEulerAngles;

            while (timer <= 1f)
            {
                timer += Time.deltaTime;
                transform.localEulerAngles = new Vector3(transform.localEulerAngles.x,transform.localEulerAngles.y, rotation.z + curve.Evaluate(timer) * _orientation * 90f);
                yield return null;
            }
            transform.localEulerAngles = rotation;
            _flipping = false;
        }
    }
}
