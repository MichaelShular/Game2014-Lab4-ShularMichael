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
    // Start is called before the first frame update
    void Start()
    {
        bulletManager = GameObject.FindObjectOfType<BulletManager>();
    }
    private void FixedUpdate()
    {
        //bullet movemenmt
        transform.position -= new Vector3(0.0f, speed, 0.0f);
        
        //move bullet back into queue if true
        if(transform.position.y < bulletBounds.min)
        {
            bulletManager.destoryBullet(this.gameObject);
        }
    }
}
