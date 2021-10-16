using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Create a bullet pool for enemies
//Version 0.1
//-function at start to create bullets
//-function to get bullets from queue (destory)
//-function to remove bullets from queue (spawn)
//-fuction to add more bullets if there arent enoungh

[System.Serializable]
public class BulletManager : MonoBehaviour
{
    public Queue<GameObject> enemyBulletPool;
    public Queue<GameObject> playerBulletPool;
    [SerializeField] private int enemyAmountOfBullets;
    [SerializeField] private int playerAmountOfBullets;
    private BulletFactory factory;

    // Start is called before the first frame update
    void Start()
    {
        enemyBulletPool = new Queue<GameObject>();
        playerBulletPool = new Queue<GameObject>();
        factory = GetComponent<BulletFactory>();
        BuildBulletPool();
    }

    //creating game object bullets but deactivating them and adding them to queue
    private void BuildBulletPool()
    {
        for (int i = 0; i < enemyAmountOfBullets; i++)
        {
            AddingBulletToPool();
        }
    }

    //removing from queue setting bullets to active and sending then to spawn location
    public GameObject GetBullet(Vector2 pos, BulletType type = BulletType.ENEMY)
    {
        GameObject temp_bullet = null;
        switch (type)
        {
            case BulletType.ENEMY:
                //check to see if bullets need to be added
                if (enemyBulletPool.Count < 1)
                {
                    AddingBulletToPool(BulletType.ENEMY);
                }
                temp_bullet = enemyBulletPool.Dequeue();
                temp_bullet.transform.position = pos;
                temp_bullet.SetActive(true);
                break;
            case BulletType.PLAYER:
                //check to see if bullets need to be added
                if (playerBulletPool.Count < 1)
                {
                    AddingBulletToPool(BulletType.PLAYER);

                }
                temp_bullet = playerBulletPool.Dequeue();
                temp_bullet.transform.position = pos;
                temp_bullet.SetActive(true);
                break;
            default:
                break;
        }
       return temp_bullet;
    }

    //deactivating bullets and adding them back to queue
    public void destoryBullet(GameObject bullet, BulletType type = BulletType.ENEMY)
    {
        switch (type)
        {
            case BulletType.ENEMY:
                bullet.SetActive(false);
                enemyBulletPool.Enqueue(bullet);
                break;
            case BulletType.PLAYER:
                bullet.SetActive(false);
                playerBulletPool.Enqueue(bullet);
                break;
            default:
                break;
        }
       
    }

    //added one more bullet to pool if not enough bullets are in the pool
    private void AddingBulletToPool(BulletType type = BulletType.ENEMY)
    {
        var temp_bullet = factory.createBullet(type);
        switch (type)
        {
            case BulletType.ENEMY:
                enemyBulletPool.Enqueue(temp_bullet);
                ++enemyAmountOfBullets;
                break;
            case BulletType.PLAYER:
                playerBulletPool.Enqueue(temp_bullet);
                ++playerAmountOfBullets;
                break;
            default:
                break;
        }
    }
}
