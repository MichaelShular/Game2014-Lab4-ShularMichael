using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Used to control player movement with physics no touch input yet
//Version 0.1
//-player move by adding force
//-decay used to limit speed
//-limits player movement inside screen 

//Last edited: 10/8/2021

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D playerRigidbody;
    [SerializeField] float speed;
    [Range(0.0f, 1.0f)][SerializeField] float decay;
    [SerializeField] Bounds bounds;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        //take inputs from x-axis and multiples it by speed to add forec to player 
        playerRigidbody.AddForce(new Vector2(Input.GetAxisRaw("Horizontal") * speed, 0));
        //slow player down
        playerRigidbody.velocity *= (1.0f - decay);

        //player minimum distance on x-axis 
        if (transform.position.x < bounds.min)
        {
            transform.position = new Vector2(bounds.min, transform.position.y);
        }
        //player maximum distance on x-axis 
        if (transform.position.x > bounds.max)
        {
            transform.position = new Vector2(bounds.max, transform.position.y);
        }
    }
}
