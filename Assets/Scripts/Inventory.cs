using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory{

    public Weapon weapon;
    public List<WeaponModule> modules;
    public int coal;
	
    public Inventory()
    {
        modules = new List<WeaponModule>(10);
    }

    public void purchase(WeaponModule purchasedModule)
    {
        if (coal >= purchasedModule.cost)
        {
            coal -= purchasedModule.cost;
            Debug.Log("Purchased " + purchasedModule);
            weapon.insertIntoEquippedModules(purchasedModule);
        }
    }  

//    //purchase...
//    public void purchase(WeaponModule purchasedModule)
//    {
//        coal -= purchasedModule.cost;
//        insertIntoInventory(purchasedModule);
//    }
//
//    public void insertIntoInventory(WeaponModule moduleToInsert, int insertionIndex = -1)
//    {
//        if(insertionIndex == -1)
//        {
//            modules.Add(moduleToInsert);
//        } else
//        {
//            modules[insertionIndex] = moduleToInsert;
//        }
//    }
//
//    public void equipModule(WeaponModule purchasedModule, int indexInventory, int indexWeapon)
//    {
//        WeaponModule temp = weapon.equippedModules[indexWeapon];
//        weapon.equippedModules[indexWeapon] = modules[indexInventory];
//        modules[indexInventory] = temp;
//    }
//

}
