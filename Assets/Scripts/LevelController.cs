using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour {

    public String nextScene;
    public int waitForSeconds;
    public GameObject[] waves;



    private int currentWaveIndex;
    private GameObject cWave;

	// Use this for initialization
	void Start () {
        waitForSeconds = 6;
        GameObject.Find("TextMeshPro Text").GetComponent<TMPro.TextMeshProUGUI>().text = "";
        cWave = Instantiate(waves[currentWaveIndex]);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Jump"))
        {
            onLevelBeaten();
        }

        if (cWave != null)
        {
            EnemyFormation cEnFormation = cWave.GetComponent<EnemyFormation>();
            if (cEnFormation.allUnitsBeaten())
            {
                Debug.Log("Wave Beaten");
                cEnFormation.onWaveBeaten();
                Debug.Log(currentWaveIndex);
                if (currentWaveIndex == waves.Length - 1)
                {
                    onLevelBeaten();
                }
                else
                {
                    currentWaveIndex++;
                    spawnWave();
                }

            }
        }

	}

    private void spawnWave()
    {
        cWave = Instantiate(waves[currentWaveIndex]);
    }

    private void onLevelBeaten()
    {
        GameObject.Find("TextMeshPro Text").GetComponent<TMPro.TextMeshProUGUI>().text = "Level Completed";
        
        StartCoroutine(ProcessNextLeveling());
       
    }

    IEnumerator ProcessNextLeveling() {
        yield return new WaitForSeconds(waitForSeconds);
        GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<Player>().inventory.weapon.removeAllTemporaryModules();
        GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<Player>().health = 100 ;
        if (nextScene.Equals("End"))
        {
            Destroy(GameObject.Find("Canvas_UI"));
        }
        SceneManager.LoadScene(nextScene);
        Destroy(this.gameObject);
    }
}
