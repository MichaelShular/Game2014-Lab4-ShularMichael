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
    public Queue<GameObject> bulletPool;
    [SerializeField] private int amountOfBullets;
    private BulletFactory factory;

    // Start is called before the first frame update
    void Start()
    {
        bulletPool = new Queue<GameObject>();
        factory = GetComponent<BulletFactory>();
        BuildBulletPool();
    }

    //creating game object bullets but deactivating them and adding them to queue
    private void BuildBulletPool()
    {
        for (int i = 0; i < amountOfBullets; i++)
        {
            AddingBulletToPool();
        }
    }

    //removing from queue setting bullets to active and sending then to spawn location
    public GameObject GetBullet(Vector2 pos)
    {
        //check to see if bullets need to be added
        if (bulletPool.Count < 1)
        {
            AddingBulletToPool();
            ++amountOfBullets;
        }
        var temp_bullet = bulletPool.Dequeue();
        temp_bullet.transform.position = pos;
        temp_bullet.SetActive(true);
        return temp_bullet;
    }

    //deactivating bullets and adding them back to queue
    public void destoryBullet(GameObject bullet)
    {
        bullet.SetActive(false);
        bulletPool.Enqueue(bullet);
    }

    //added one more bullet to pool if not enough bullets are in the pool
    private void AddingBulletToPool()
    {
        var temp_bullet = factory.createBullet();
        bulletPool.Enqueue(temp_bullet);
    }
}
