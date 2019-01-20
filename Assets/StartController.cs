using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartController : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<Button>().onClick.AddListener(onStartGame);
	}
	
    public void onStartGame()
    {
        Debug.Log("Click");
        SceneManager.LoadScene("Intro");
    }

	// Update is called once per frame
	void Update () {
		
	}
}
