using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private bool alive = true;
    [SerializeField] private float jumpForce = 10;
    //Variable that holds the name of the layer that an object has to be in in order to cause death to the player
    [SerializeField] private string killer = "Enemy";
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //transform.position += new Vector3(0.1f, 0, 0) * speed;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity += Vector2.up * jumpForce;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer(killer))
        {
            alive = false;
            Destroy(gameObject);
        }
     
    }

    //NEED TO MAKE GROUND DETECTION TO PREVENT INFINITE JUMP
    //NEED TO IMPLEMENT SNAPPIER JUMP
}
