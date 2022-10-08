using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // target is a ball 
    private Vector3 offset; //camera has in the begining of ball

    private void Start()
    {
        offset = transform.position- target.transform.position;
    }

    private void Update()
    {
        transform.position = new Vector3 (target.position.x+offset.x, target.position.y+offset.y, target.position.z+offset.z);
    }

}
