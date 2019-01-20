using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowerProjectilesDrop : Drop {

    protected override void Start()
    {
        GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load("Sprites/Drops/7", typeof(Sprite));
        module = new SlowerProjectiles();
        base.Start();
    }
}
