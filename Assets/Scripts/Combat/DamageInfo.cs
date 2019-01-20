using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class DamageInfo
{
    public float damage;

    public DamageInfo(float damage = 5)
    {
        this.damage = damage;
    }
}
