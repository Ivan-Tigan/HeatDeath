using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FasterProjectilesDrop : Drop
{
    protected override void Start()
    {
        GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load("Sprites/Drops/8", typeof(Sprite));
        module = new FasterProjectiles();
        base.Start();
    }
}


