using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour {

    public float speed;
    public float lifeTime;
    public DamageInfo damageInfo;

    [HideInInspector]
    public GameObject shooter;
    [HideInInspector]
    public Vector2 direction;

    private Rigidbody2D rb;
    private float currentLifeTime;
    
	// Use this for initialization
	void Start () {
        rb=GetComponent<Rigidbody2D>();
        currentLifeTime = Time.time;
        lifeTime += Time.time;
	}

    
	
	// Update is called once per frame
	void Update () {
        rb.velocity = direction * speed;
       
        currentLifeTime+=Time.deltaTime;
        if(currentLifeTime>lifeTime)
        {
            Destroy(this.gameObject);
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (shooter != collision.gameObject) {
            MonoBehaviour[] list = collision.gameObject.GetComponents<MonoBehaviour>();
            foreach (MonoBehaviour mb in list)
            {
                if (mb is IDamageable<DamageInfo>)
                {
                    IDamageable<DamageInfo> breakable = (IDamageable<DamageInfo>)mb;
                    breakable.onDamageTaken(damageInfo);
                }
            }
        }

    }
}
