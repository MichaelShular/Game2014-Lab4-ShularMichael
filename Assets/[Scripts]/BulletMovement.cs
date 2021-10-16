using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Bullet movement and checking to see if bullet is inside its boundary. If bullet
//is outside boundary call destory fuction from bullet pool, to add bullet back
//to queue
//Version 0.1
//-bullet movement using transform
//-bounary of bullet

public class BulletMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Bounds bulletBounds;
    private BulletManager bulletManager;
    private Vector3 velocity;
    public BulletDirection direction;
    // Start is called before the first frame update
    void Start()
    {
        bulletManager = GameObject.FindObjectOfType<BulletManager>();

        switch (direction)
        {
            case BulletDirection.UP:
                velocity = new Vector3(0.0f, speed, 0.0f);
                break;
            case BulletDirection.DOWN:
                velocity = new Vector3(0.0f, -speed, 0.0f);
                break;
            default:
                break;
             
        }
    }
    private void FixedUpdate()
    {
        //bullet movemenmt
        transform.position += velocity;
        
        //move bullet back into queue if true
        if(transform.position.y < bulletBounds.min)
        {
            bulletManager.destoryBullet(this.gameObject);
        }

        //move bullet back into queue if true
        if (transform.position.y > bulletBounds.max)
        {
            bulletManager.destoryBullet(this.gameObject);
        }
    }
}
