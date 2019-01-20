using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleBarrelsDrop : Drop {

    protected override void Start()
    {
        GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load("Sprites/Drops/18", typeof(Sprite));
        module = new MultipleBarrels();
        base.Start();
    }
}
