using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowmanEnemy : Enemy
{
    public override void Start()
    { 
        weapon = new SnowballWeapon();
        base.Start();
    }
}
