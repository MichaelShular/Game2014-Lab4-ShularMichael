using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Movement for enemy by using transform, and the logic enemy movement using pingpong
//Version 0.1
//-speed and range randomaly done with movementBounds
//-spawn location of enemy is randomaly done by spawnBounds
//-Using Mathf pingpong fuction to transform the location each update

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Bounds movementBounds;
    [SerializeField] private Bounds spawnBounds;
    private float spawnLoc;
    private float speed;


    void Start()
    {
        //choosing speed and how far the range of movement is 
        speed = Random.Range(movementBounds.min, movementBounds.max);
        //spawn loaction of enemy
        spawnLoc =  Random.Range(spawnBounds.min, spawnBounds.max);
    }

    // Update is called once per frame
    void Update()
    {
        //object movement
        transform.position = new Vector2(Mathf.PingPong(Time.time, speed) + spawnLoc, transform.position.y);
    }
}
