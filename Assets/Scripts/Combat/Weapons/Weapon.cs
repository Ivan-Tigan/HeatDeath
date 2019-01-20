using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


[System.Serializable]
public class Weapon {

    public List<WeaponModule> baseModules;
    public List<WeaponModule> equippedModules;
    public List<WeaponModule> temporaryModules;
    public List<WeaponModule> modules { get { return baseModules.Concat(equippedModules).ToList().Concat(temporaryModules).ToList(); } }

    public int capacity;

    public GameObject shooter;

	// Use this for initialization
	public virtual void Start (GameObject shooter) {
        this.shooter = shooter;
        baseModules = new List<WeaponModule>();
        equippedModules = new List<WeaponModule>();
        temporaryModules = new List<WeaponModule>();
        capacity = 3;
    }
	
    public virtual void setup() { }
    public virtual void applyModules() { }
	public virtual void Update () {	}


    public void insertIntoEquippedModules(WeaponModule moduleToInsert, int insertionIndex = -1)
    {
        if (insertionIndex == -1)
        {
            equippedModules.Add(moduleToInsert);
        }
        else
        {
            equippedModules[insertionIndex] = moduleToInsert;
        }
        setup();
        applyModules();
        
    }


    #region Temporary Modules Methods

    public void addTemporaryModule(WeaponModule mod)
    {
        temporaryModules.Add(mod);
        setup();
        applyModules();
    }

    public void removeTemporaryModule(WeaponModule mod)
    {
        temporaryModules.Remove(mod);
        setup();
        applyModules();
    }

    public void removeTemporaryModule(int i)
    {
        temporaryModules.RemoveAt(i);
        setup();
        applyModules();
    }

    public void removeAllTemporaryModules()
    {
        temporaryModules.Clear();
        setup();
        applyModules();
    }

    #endregion

    #region Equipped Modules Methods

    public void equipModule(WeaponModule mod)
    {
        if (equippedModules.Count < capacity)
        {
            equippedModules.Add(mod);
            setup();
            applyModules();
        }
    }

    public void unequipModule(WeaponModule mod)
    {
        equippedModules.Remove(mod);
        setup();
        applyModules();
    }

    public void unequipModule(int i)
    {
        equippedModules.RemoveAt(i);
        setup();
        applyModules();
    }

#endregion

#region Base Modules Methods

    public void addBaseModule(WeaponModule mod)
    {
        baseModules.Add(mod);
        setup();
        applyModules();
    }

    public void removeBaseModule(int i)
    {
        baseModules.RemoveAt(i);
        setup();
        applyModules();
    }

    public void removeBaseModule(WeaponModule mod)
    {
        baseModules.Remove(mod);
        setup();
        applyModules();
    }
    #endregion

}
