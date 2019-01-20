using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeechController : MonoBehaviour {

    [TextArea]
    public string[] lines;
    private int currentIndex = 0;
	// Use this for initialization
	void Start () {
        GetComponentInChildren<Button>().onClick.AddListener(onNext);
        GetComponent<Text>().text = lines[currentIndex];
    }
	
    public void onNext()
    {
        if (currentIndex < lines.Length - 1)
        {
            currentIndex++;
            GetComponent<Text>().text = lines[currentIndex];
        }
    }

	// Update is called once per frame
	void Update () {
		
	}
}
