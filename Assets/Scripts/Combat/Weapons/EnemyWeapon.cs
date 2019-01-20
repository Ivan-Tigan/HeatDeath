using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : ProjectileWeapon {

    // Use this for initialization
    public override void Start(GameObject shooter)
    {
        bulletPrefab = (GameObject)Resources.Load("Prefabs/Bullets/Snowflake");
        base.Start(shooter);
        spawnOffset = new Vector3(0, -1, 0);
        direction = new Vector3(0, 0, 180);
        fireRate = 0.5f;
        bullet.speed = 3f;

    }



    // Update is called once per frame
    public override void Update()
    {
        if (nextFire <= Time.time)
        {
            shoot();
            nextFire = Time.time + 1 / fireRate;
        }
    }
}


public class SnowflakeWeapon:EnemyWeapon
{
    public override void Start(GameObject shooter)
    {
        base.Start(shooter);

        bulletPrefab = (GameObject)Resources.Load("Prefabs/Bullets/Snowflake");
    }
}

public class SnowballWeapon : EnemyWeapon
{
    public override void Start(GameObject shooter)
    {
        base.Start(shooter);
        fireRate = 1.5f;
        bulletPrefab = (GameObject)Resources.Load("Prefabs/Bullets/Snowball");
    }
}