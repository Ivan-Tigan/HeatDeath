using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Diagonal : Move {

    public Vector2 offset;
    public Vector2 offsetMults;
    public Vector2 movementVector;

	// Use this for initialization
	void Start () {
        offset = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override Transform move(Transform t)
    {
        t.position = new Vector2(offset.x+(t.position.x+Time.deltaTime*movementVector.x), offset.y+(t.position.y+Time.deltaTime*movementVector.y)%9);
        return t;
    }
}
