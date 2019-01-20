using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainUI : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(this.gameObject);
	}

    private void DontDestroyOnLoad()
    {
        throw new NotImplementedException();
    }

    // Update is called once per frame
    void Update () {
        GameObject.Find("Slider").GetComponent<Slider>().value = GameController.player.health;
        GameObject.Find("Text").GetComponent<Text>().text = "Coal: " + GameController.player.inventory.coal;
        if (SceneManager.GetActiveScene().name.Equals("End"))
        {
            Destroy(this.gameObject);
        }
    }
}
