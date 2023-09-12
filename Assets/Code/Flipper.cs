using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flipper : MonoBehaviour
{
    [SerializeField] private AnimationCurve curve;

    float _timer = 5f;
    private Coroutine rut;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) && _timer > 1f)
        {
            _timer = 0f;
            if (rut != null)
            {
                StopCoroutine(rut);
            }
            rut = StartCoroutine(somead());
        }
        _timer += Time.deltaTime;

        // float angleRotation = curve.Evaluate(_timer) * 90f;
        // Vector3 rotation = new Vector3(0, 0, angleRotation);
        // transform.localEulerAngles = rotation;
    }

    public IEnumerator somead()
    {
        float timer = 0;
        while (timer < 2f)
        {
            timer += Time.deltaTime;
            transform.localEulerAngles = new Vector3(0,0, curve.Evaluate(timer) * 90f);
            yield return new WaitForEndOfFrame();
        }
    }
    
}
