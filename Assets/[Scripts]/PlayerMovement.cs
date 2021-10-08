using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Used to control player movement with physics no touch input yet
//Version 0.1
//-player move by adding force
//-decay used to limit speed
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D playerRigidbody;
    [SerializeField] float speed;
    [Range(0.0f, 1.0f)][SerializeField] float decay;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        playerRigidbody.AddForce(new Vector2(Input.GetAxisRaw("Horizontal") * speed, 0));
        playerRigidbody.velocity *= (1.0f - decay);
    }
}
