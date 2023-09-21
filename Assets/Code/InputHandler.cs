using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public static InputHandler Instance;
    public Action<bool> OnFlip;
    
    private void Awake()
    {
        Instance = this;
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            OnFlip?.Invoke(true);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            OnFlip?.Invoke(false);
        }
    }
}
