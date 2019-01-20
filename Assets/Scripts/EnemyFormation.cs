using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MovementCommand
{
    public Vector3 movement;
    public float speed;
    public float duration;

    [HideInInspector]
    public float timer;
}

[System.Serializable]
public class FormationUnit
{
    public GameObject unit;
    public Vector3 spawnLocation;
    public MovementCommand[] movementCommands;

    [HideInInspector]
    public int currentCommand;
}

public class EnemyFormation : MonoBehaviour {

    public FormationUnit[] formation;
    public MovementCommand[] globalCommands;

    

    private int currentGlobalCommand;

	// Use this for initialization
	void Start () {
        spawnFormation();
	}

    private void spawnFormation()
    {
        foreach(FormationUnit fu in formation)
        {
            fu.unit = Instantiate(fu.unit, fu.spawnLocation, Quaternion.Euler(0, 0, 0), this.transform);
        }
    }

    // Update is called once per frame
    void Update ()
    {
        handleGlobalMovement();
        handleUnitMovement();

        
        

    }

    public void onWaveBeaten()
    {
        Debug.Log("Wave Beaten");
        //implement wave beaten logic
        Destroy(this.gameObject);
    }

    public bool allUnitsBeaten()
    {
        foreach(FormationUnit fu in formation)
        {
            if (fu.unit != null && !fu.unit.GetComponent<Enemy>().isBeaten)
            {
                return false;
            }
        }
        return true;
    }

    private void handleUnitMovement()
    {
        for (int i = 0; i < formation.Length; i++)
        {
            FormationUnit f = formation[i];

            if (f.unit != null)
            {

                f.movementCommands[f.currentCommand].timer += Time.deltaTime;

                if (f.movementCommands[f.currentCommand].timer <= f.movementCommands[f.currentCommand].duration)
                {
                    f.unit.transform.position += f.movementCommands[f.currentCommand].movement * Time.deltaTime * f.movementCommands[f.currentCommand].speed;
                    f.unit.GetComponent<SpriteRenderer>().flipX = (f.movementCommands[f.currentCommand].movement.x > 0f);
                }
                else
                {
                    f.movementCommands[f.currentCommand].timer = 0;
                    f.currentCommand = (f.currentCommand + 1) % f.movementCommands.Length;
                }
            }
        }
    }

    private void handleGlobalMovement()
    {
        globalCommands[currentGlobalCommand].timer += Time.deltaTime;

        if (globalCommands[currentGlobalCommand].timer <= globalCommands[currentGlobalCommand].duration)
        {
            transform.position += globalCommands[currentGlobalCommand].movement * Time.deltaTime * globalCommands[currentGlobalCommand].speed;
        }
        else
        {
            globalCommands[currentGlobalCommand].timer = 0;
            currentGlobalCommand = (currentGlobalCommand + 1) % globalCommands.Length;
        }
    }
}
