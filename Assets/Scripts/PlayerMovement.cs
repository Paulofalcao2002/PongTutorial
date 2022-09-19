using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public bool isPlayer1;
    public Rigidbody2D rb;
    public float speed;
    public Vector3 startPosition;


    private float movement;

    void Start(){
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayer1)
        {
            movement = Input.GetAxisRaw("Vertical2");
        }
        else{
            movement = Input.GetAxisRaw("Vertical");
        }
        
        rb.velocity = new Vector2(rb.velocity.x, movement*speed);
    }

    public void Reset(){
        rb.velocity = Vector2.zero;
        transform.position = startPosition;
    }
}
