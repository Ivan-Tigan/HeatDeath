using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbsolutePowerDrop : Drop {

    protected override void Start()
    {
        GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load("Sprites/Drops/6", typeof(Sprite));
        module = new AbsolutePower();
        base.Start();
    }
}
