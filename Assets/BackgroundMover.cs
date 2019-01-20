using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMover : MonoBehaviour {

    public float speed;


	// Use this for initialization
	void Start () {
        speed = 1f;
	}
	
	// Update is called once per frame
	void Update () {
        float newY = transform.position.y - (speed * Time.deltaTime);
        if (newY <= -20)
        {
            newY = 40;
        }
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
	}
}
