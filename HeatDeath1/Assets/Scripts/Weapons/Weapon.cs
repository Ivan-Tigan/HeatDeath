using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    public Vector2 direction;
    public GameObject bullet;
    public float fireRate;

    public float nextFire;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
       
        
    }

    public void shoot(GameObject shooter)
    {

        GameObject bul=Instantiate(bullet, transform.position, transform.rotation) ;
        bul.GetComponent<Bullet>().direction = direction;
        bul.GetComponent<Bullet>().shooter = this.gameObject;

    }

   
}
