using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LargerProjectilesDrop : Drop {

    protected override void Start()
    {
        GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load("Sprites/Drops/3", typeof(Sprite));
        module = new LargerProjectiles();
        base.Start();
    }
}
