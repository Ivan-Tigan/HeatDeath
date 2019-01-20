using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiercingProjectilesDrop : Drop {

    protected override void Start()
    {
        GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load("Sprites/Drops/20", typeof(Sprite));
        module = new PiercingProjectiles();
        base.Start();
    }
}
