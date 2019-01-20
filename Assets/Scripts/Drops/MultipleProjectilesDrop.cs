using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleProjectilesDrop : Drop {

    protected override void Start()
    {
        GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load("Sprites/Drops/16", typeof(Sprite));
        module = new MultipleProjectiles();
        base.Start();
    }
}
