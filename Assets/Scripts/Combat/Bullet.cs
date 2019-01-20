using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour {

    public float speed;
    public float lifeTime;
    public DamageInfo damageInfo;
    public int pierce=0;
    public Vector2 direction;

    [HideInInspector]
    public string shooterTag;

    private Rigidbody2D rb;
    private float currentLifeTime;
    private int pierced;


    float temp; 
    // Use this for initialization
    void Start () {


        rb=GetComponent<Rigidbody2D>();
        currentLifeTime = Time.time;
        lifeTime += Time.time;
        pierced = 0;
        

    }

    
	
	// Update is called once per frame
	void Update () {
        rb.velocity = transform.up * speed;
       
        currentLifeTime+=Time.deltaTime;
        if(currentLifeTime>lifeTime)
        {
            Destroy(this.gameObject);
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (shooterTag != collision.gameObject.tag )  {
            MonoBehaviour[] list = collision.gameObject.GetComponents<MonoBehaviour>();
            foreach (MonoBehaviour mb in list)
            {
                if (mb is IDamageable<DamageInfo> )
                {
                    IDamageable<DamageInfo> dmgbl = (IDamageable<DamageInfo>)mb;
                    dmgbl.onDamageTaken(damageInfo);
                    Debug.Log("Pierce: " + pierced + " out of " + pierce);
                    if (pierced>=pierce)
                    {
                        Destroy(this.gameObject);
                    }
                    else
                    {
                        pierced++;
                    }
                }
            }
        }

    }
}
