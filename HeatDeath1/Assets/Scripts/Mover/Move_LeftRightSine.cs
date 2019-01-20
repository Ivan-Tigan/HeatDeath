using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_LeftRightSine : Move {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override Transform move(Transform t)
    {

        t.position = t.position + new Vector3(Mathf.Sin(Time.time / 2) / 12f, Mathf.Sin(Time.time * 4.5f) / 15, 0.0f);

        return (t);
    }
}
