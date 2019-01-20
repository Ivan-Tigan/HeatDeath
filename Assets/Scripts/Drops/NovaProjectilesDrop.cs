using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NovaProjectilesDrop : Drop {

    protected override void Start()
    {
        GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load("Sprites/Drops/11", typeof(Sprite));
        module = new NovaProjectiles();
        base.Start();
    }
}
