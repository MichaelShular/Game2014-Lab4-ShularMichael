using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Spawn location for enemy bullet and when activate a bullet  
//Version 0.1
//-bullet spawn location from child game object
//-bullets spawn base on frame delay
//-using bullet pool's bullets 
public class EnemyBullets : MonoBehaviour
{
    [SerializeField] private Transform spawnLoc;
    [SerializeField] private float framedelay;
    private BulletManager bulletManager;
    // Start is called before the first frame update
    private void Start()
    {
        bulletManager = GameObject.FindObjectOfType<BulletManager>();
    }
    private void FixedUpdate()
    {
        if (Time.frameCount % framedelay == 0 )
        {
            bulletManager.GetBullet(spawnLoc.position);
        }
    }
}
