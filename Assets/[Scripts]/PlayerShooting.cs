using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] public Transform bulletSpawn;
    private BulletManager bulletManager;
    [SerializeField] private float framedelay;

    private void Start()
    {

        bulletManager = GameObject.FindObjectOfType<BulletManager>();
    }
    private void FixedUpdate()
    {
        playerShooting();
    }
    private void playerShooting()
    {
        if ((Time.frameCount % framedelay == 0) && (Input.GetAxisRaw("Jump") > 0))
        {
            bulletManager.GetBullet(bulletSpawn.position, BulletType.PLAYER);
        }
    }
}
