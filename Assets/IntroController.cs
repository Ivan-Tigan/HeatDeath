using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroController : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponentInChildren<Button>().onClick.AddListener(onPlayGame);
	}
	public void onPlayGame()
    {
        SceneManager.LoadScene("Level1");
    }
	// Update is called once per frame
	void Update () {
		
	}
}
