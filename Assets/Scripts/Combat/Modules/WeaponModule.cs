using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Collections;

[System.Serializable]
public class WeaponModule {

    public string name;
    public Sprite icon;
    public int cost;
    public Dictionary<string, float> paramModifier;

    public WeaponModule()
    {
        paramModifier = new Dictionary<string, float>();
        cost = 5;
    }
    public WeaponModule(Dictionary<string, float> paramMultipliers)
    {
        this.paramModifier = paramMultipliers;
        cost = 25;
    }

}

public class MultipleProjectiles : WeaponModule
{

   public MultipleProjectiles(int num = 3, float cone = 60, float damagePunishmentMultiplier=0.7f)
    {
        paramModifier["Number of Projectiles"] = num;
        paramModifier["Cone"] = cone;
        paramModifier["Damage"] = damagePunishmentMultiplier;
        cost = 10;
        icon = (Sprite)Resources.Load("Sprites/Drops/16", typeof(Sprite));
    }
}

public class MultipleBarrels : WeaponModule
{
    public MultipleBarrels(int num = 2, float width = 2f, float damagePunishmentMultiplier = 0.7f)
    {
        paramModifier["Number of Barrels"] = num;
        paramModifier["Width"] = width;
        paramModifier["Damage"] = damagePunishmentMultiplier;
        cost = 10;
        icon = (Sprite)Resources.Load("Sprites/Drops/18", typeof(Sprite));
    }
}


public class FasterShooting : WeaponModule
{

    public FasterShooting(float fireRateMultiplier=2, float damagePunishmentMultiplier = 0.7f)
    {
        paramModifier["Fire Rate"] = fireRateMultiplier;
        paramModifier["Damage"] = damagePunishmentMultiplier;
        cost = 7;
        icon = (Sprite)Resources.Load("Sprites/Drops/5", typeof(Sprite));
    }
}

public class SlowerProjectiles : WeaponModule
{
    public SlowerProjectiles(float speedMultiplier = 0.4f, float damageMultiplier = 1.3f)
    {
        paramModifier["Bullet Speed"] = speedMultiplier;
        paramModifier["Damage"] = damageMultiplier;
        cost = 4;
        icon = (Sprite)Resources.Load("Sprites/Drops/7", typeof(Sprite));
    }
}

public class NovaProjectiles : MultipleProjectiles
{
    public NovaProjectiles(int num = 12, float cone = 360, float damagePunishmentMultiplier = 0.2f):base(num, cone, damagePunishmentMultiplier)
    {

        icon = (Sprite)Resources.Load("Sprites/Drops/11", typeof(Sprite));
        cost = 25;
    }
}

public class FasterProjectiles : WeaponModule
{
    public FasterProjectiles(float speedMultiplier=2, float damagePunishmentMultiplier = 0.65f)
    {
        paramModifier["Bullet Speed"] = speedMultiplier;
        paramModifier["Damage"] = damagePunishmentMultiplier;
        cost = 7;
        icon = (Sprite)Resources.Load("Sprites/Drops/8", typeof(Sprite));
    }
}

public class LargerProjectiles: WeaponModule
{
    public LargerProjectiles(float scaleMultiplier = 1.5f, float speedMultipler = 0.65f, float damageMultiplier = 1.25f)
    {
        paramModifier["Bullet Size"] = scaleMultiplier;
        paramModifier["Bullet Speed"] = speedMultipler;
        paramModifier["Damage"] = damageMultiplier;
        cost = 3;
        icon = (Sprite)Resources.Load("Sprites/Drops/3", typeof(Sprite));
    }
}

public class AbsolutePower : WeaponModule
{
    public AbsolutePower(float damageMultiplier = 2)
    {
        paramModifier["Damage"] = damageMultiplier;
        cost = 10;
        icon = (Sprite)Resources.Load("Sprites/Drops/6", typeof(Sprite));
    }
}

public class PiercingProjectiles : WeaponModule
{
    public PiercingProjectiles(int pierce = 1, float damagePunishmentMultiplier = 0.65f)
    {
        paramModifier["Bullet Pierce"] = pierce;
        paramModifier["Damage"] = damagePunishmentMultiplier;
        cost = 25;
        icon = (Sprite)Resources.Load("Sprites/Drops/20", typeof(Sprite));
    }
}
