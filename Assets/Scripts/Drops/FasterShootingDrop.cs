using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FasterShootingDrop : Drop {

    protected override void Start()
    {
        GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load("Sprites/Drops/5", typeof(Sprite));
        module = new FasterShooting();
        base.Start();
    }
}
