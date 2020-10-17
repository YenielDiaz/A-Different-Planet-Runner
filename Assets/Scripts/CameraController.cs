using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float speed;

    void Start()
    {
        
    }


    void Update()
    {
        //test code to move the camera automatically
        transform.position += new Vector3(0.1f,0,0) * speed;
    }
}
