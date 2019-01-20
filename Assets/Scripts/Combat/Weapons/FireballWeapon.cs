using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballWeapon : ProjectileWeapon {

	// Use this for initialization
	public override void Start (GameObject shooter) {
        bulletPrefab = (GameObject)Resources.Load("Prefabs/Bullets/Fireball");
        base.Start(shooter);
        direction = new Vector3(0, 0, 0);
        //addBaseModule(new MultipleBarrels(num: 2, width: 3));
        capacity = 4;

        //addModule(new NovaProjectiles());
        //addModule(new FasterShooting());
        //addModule(new SlowerProjectiles());
        //addModule(new LargerProjectiles());
        //addModule(new FasterProjectiles(speedMultiplier: 2.0f));
        //addModule(new PiercingProjectiles());
    }
	
	// Update is called once per frame
	public override void Update () {

        base.Update();
	}
}
