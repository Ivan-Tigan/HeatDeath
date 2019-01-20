using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[System.Serializable]
public class ProjectileWeapon : Weapon {

    public float fireRate;
    public int numProj;
    public float cone;
    public int numBarr;
    public float width;
    //public ArrayList spawnDirs;
    //public ArrayList spawnPositions;
    public GameObject bulletPrefab;
    public Vector3 spawnOffset;
    public Vector3 direction;

    protected float nextFire;
    protected Bullet bullet;


    // Use this for initialization
    public override void Start(GameObject shooter) {

        base.Start(shooter);

        setup();
        //addBaseModule(new PiercingProjectiles());
        

    }

    public override void setup()
    {
        fireRate = 2;

        bullet = bulletPrefab.GetComponent<Bullet>();
        bullet.speed = 10;
        bullet.lifeTime = 2;
        bullet.damageInfo.damage = 10;
        bullet.shooterTag = shooter.tag;
        bullet.pierce = 0;

        spawnOffset = new Vector3(0, 1, 0);

        numProj = 1;
        cone = 0f;

        numBarr = 1;
        width = 0f;
    }

    // Update is called once per frame
    public override void Update() {

        if (Input.GetButton("Fire1") && nextFire <= Time.time)
        {
            shoot();
            nextFire = Time.time + 1 / fireRate;
        }
    }

    protected void shoot()
    {
        for (int i = 0; i < numBarr; i++)
        {
            for (int j = 0; j < numProj; j++)
            {
                GameObject bulInst = GameObject.Instantiate(bulletPrefab, new Vector3(shooter.transform.position.x + spawnOffset.x + (float)spawnPositions()[i], shooter.transform.position.y + spawnOffset.y, 0), Quaternion.Euler(direction.x, direction.y, direction.z)*(Quaternion)spawnDirections()[j]);
                //bulInst.transform.rotation = Quaternion.Euler(direction.x, direction.y, direction.z);
            }
        }
    }

    public ArrayList spawnDirections()
    {
        ArrayList dirs = new ArrayList();

        Quaternion start = Quaternion.Euler(0, 0, -cone / 2);
        Quaternion each = Quaternion.Euler(0, 0, cone / (numProj + 1));

        for (int i = 0; i < numProj; i++)
        {
            dirs.Add(start * powerQuaternion(each, i));
        }


        return dirs;
    }

    private Quaternion powerQuaternion(Quaternion q, int pow)
    {
        Quaternion result = new Quaternion();
        result = q;
        for (int i = 0; i < pow; i++)
        {
            result *= q;
        }

        return result;
    }
    public ArrayList spawnPositions()
    {
        ArrayList positions = new ArrayList();

        float start = -width / 2;
        float each = width / (numBarr + 1);
        for (int i = 1; i <= numBarr; i++)
        {
            positions.Add(start + each * i);
        }


        return positions;
    }

    public override void applyModules()
    {
        foreach (WeaponModule mod in modules)
        {
            foreach (string s in mod.paramModifier.Keys)
            {


                Debug.Log(s + " in apply has value " + mod.paramModifier[s]);
                switch (s)
                {
                    case "Fire Rate":
                        fireRate *= mod.paramModifier[s];
                        break;
                    case "Damage":
                        bulletPrefab.GetComponent<Bullet>().damageInfo.damage *= mod.paramModifier[s];
                        break;
                    case "Bullet Size":
                        bulletPrefab.transform.localScale = Vector3.one * mod.paramModifier[s];
                        break;
                    case "Bullet Pierce":
                        bulletPrefab.GetComponent<Bullet>().pierce += (int)mod.paramModifier[s];
                        break;
                    case "Bullet Speed":
                        bulletPrefab.GetComponent<Bullet>().speed *= mod.paramModifier[s];
                        break;
                    case "Number of Projectiles":
                        numProj += (int)mod.paramModifier[s];
                        break;
                    case "Cone":
                        cone += mod.paramModifier[s];
                        break;
                    case "Number of Barrels":
                        numBarr += (int)mod.paramModifier[s];
                        break;
                    case "Width":
                        width += mod.paramModifier[s];
                        break;
                    default:
                        break;
                }
            }

            
        }
    }


}
