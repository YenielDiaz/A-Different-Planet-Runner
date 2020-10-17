using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxScroll : MonoBehaviour
{
    private float length, startPos;
    private Camera cam;

    [SerializeField] private float parallaxFactor;
    [SerializeField] private float offset;

    void Start()
    {
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
        cam = Camera.main;
    }


    void Update()
    {
        //get distance traveled relative to the camera
        float distRelativeToCamera = cam.transform.position.x * (1 - parallaxFactor);
        //get distance we will add to its position
        float distance = cam.transform.position.x * parallaxFactor;

        //move background part based on how much parallaxFactor it has
        transform.position = new Vector3(startPos + distance, transform.position.y, transform.position.z);

        if(distRelativeToCamera > startPos + (length - offset))
        {
            //update start position to the right so that the camera does not go out of bounds
            startPos += length;
        }
        else if (distRelativeToCamera < startPos - (length - offset))
        {
            //update start position to the left so that the camera does not go out of bounds
            startPos -= length;
        }
    }
}
