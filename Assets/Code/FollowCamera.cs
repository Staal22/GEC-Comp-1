using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] GameObject target;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //follow the target
        transform.position = target.transform.position + new Vector3(0, 8, -15);
        //look at the target
        transform.LookAt(target.transform);
    }
}
