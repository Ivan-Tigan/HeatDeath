using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenguinEnemy : Enemy
{
    public override void Start()
    {
        weapon = new SnowflakeWeapon();
        base.Start();
    }
}
