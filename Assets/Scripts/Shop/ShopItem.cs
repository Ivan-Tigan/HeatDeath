using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour {

    public WeaponModule item;
    public Button buttonBuy;
    public Text textName, textCost;
	// Use this for initialization
	void Start () {
        buttonBuy = this.GetComponent<Button>();
        buttonBuy.onClick.AddListener(onBuy);

        
    }

    public void load(WeaponModule item)
    {
        Debug.Log("Loading item " + item.GetType().Name);
        this.item = item;

        textName = transform.Find("Panel").Find("Text_Name").GetComponent<Text>();
        textCost = transform.Find("Panel").Find("Text_Price").GetComponent<Text>();

        string name = item.GetType().Name;
        for (int i = 1; i < name.Length; i++)
        {
            if (name[i].Equals(name[i].ToString().ToUpper()))
            {
                name.Insert(i, " ");
            }
        }

        textName.text = name;
        textCost.text = item.cost.ToString();

        GetComponent<Image>().sprite = item.icon;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void onBuy()
    {
        GameController.player.inventory.purchase(item);
    }
}
