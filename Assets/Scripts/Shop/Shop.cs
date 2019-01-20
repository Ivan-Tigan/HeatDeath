using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Shop : MonoBehaviour {

    public string nextLevel;

    private Transform panelItems;
    private Button buttonNextLevel;

	// Use this for initialization
	void Start () {

        buttonNextLevel = transform.Find("Button_NextLevel").GetComponent<Button>();
        buttonNextLevel.onClick.AddListener(onNextLevelClick);

        panelItems = transform.Find("Panel_Items");
        List<WeaponModule> shopItems = new List<WeaponModule>();

        shopItems.Add(new AbsolutePower());
        shopItems.Add(new FasterProjectiles());
        shopItems.Add(new FasterShooting());
        shopItems.Add(new LargerProjectiles());
        shopItems.Add(new MultipleBarrels());
        shopItems.Add(new MultipleProjectiles());
        shopItems.Add(new NovaProjectiles());
        shopItems.Add(new PiercingProjectiles());
        shopItems.Add(new SlowerProjectiles());

        foreach (WeaponModule wm in shopItems){
            if (SceneManager.GetActiveScene().name.Equals("Shop4"))
            {
                wm.cost = 0;
            }
            ((GameObject)Instantiate(Resources.Load("Prefabs/Shop/Prefab_ShopItem"), panelItems)).GetComponent<ShopItem>().load(wm);

        }
	}
	
    void onNextLevelClick()
    {
        SceneManager.LoadScene(nextLevel);
    }

	// Update is called once per frame
	void Update () {
		
	}
}
