using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable] public class DictGameObjectFloat : SerializableDictionary<GameObject, float> { }

public class Enemy : MonoBehaviour, IDamageable<DamageInfo> {

    public float health;
    public float speed;
    public float chanceToDrop;

    [SerializeField]
    public DictGameObjectFloat drops = new DictGameObjectFloat();
    

    [HideInInspector]
    public bool isBeaten;

    protected EnemyWeapon weapon;


	// Use this for initialization
	public virtual void Start () {

        health = 25f;

        tag = "Enemy";

        chanceToDrop = 0.25f;

        //weapon = new SnowflakeWeapon();

        foreach (GameObject drop in Resources.LoadAll("Prefabs/Drops/"))
        {
            if (drop.name.Equals("CoalDrop"))
            {
                drops.Add(drop, 5);
            }
            else
            {
                drops.Add(drop, 1);
            }
            
        }

        weapon.Start(this.gameObject);
	}
	
	// Update is called once per frame
	public void Update () {
        //transform.position = transform.position + new Vector3(Mathf.Sin(Time.time/2)/12f, Mathf.Sin(Time.time*4.5f) / 15, 0.0f);
        //transform.position = transform.position + new Vector3(Triangle(-0.2f,0.2f,2,10,Time.time/2), Mathf.Sin(Time.time * 4) / 30, 0.0f);
        //transform.position = transform.position + new Vector3(Tri(-0.2f, 0.2f, 2, Time.time) / 4, Mathf.Sin(Time.time * 4) / 30, 0.0f);
        weapon.Update();
        



    }

    float Tri(float min, float max, float p, float t)
    {

        return (4 / p) * (t - (p / 2) * Mathf.Floor((2 * t / p) + (1 / 2)))*Mathf.Pow(-1, Mathf.Floor((2 * t / p) + (1 / 2)));
    }

    float Triangle(float minLevel, float maxLevel, float period, float phase, float t)
    {
        float pos = Mathf.Repeat(t - phase, period) / period;

        if (pos < .5f)
        {
            return Mathf.Lerp(minLevel, maxLevel, pos * 2f);
        }
        else
        {
            return Mathf.Lerp(maxLevel, minLevel, (pos - .5f) * 2f);
        }
    }

    public void onDamageTaken(DamageInfo damageInfo)
    {
        health -= damageInfo.damage;
        if (health <= 0)
        {
            if (UnityEngine.Random.Range(0f, 1f) >= 1f - chanceToDrop)
            {
                Instantiate(((Dictionary<GameObject, float>)drops).RandomElementByWeight(e => e.Value).Key, transform.position, transform.rotation);
            }

            Destroy(this.gameObject);
        }
    }

    private void OnDestroy()
    {
        Debug.Log("Enemy destroyed");
        
        isBeaten = true;
    }
}



