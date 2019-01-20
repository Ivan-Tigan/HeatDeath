using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable<DamageInfo> {

    public Move movementFunction;

    public float speed;
    private Weapon weapon;

	// Use this for initialization
	void Start () {

        weapon = GetComponent<Weapon>();
        weapon.direction = transform.up*(-1);

	}
	
	// Update is called once per frame
	void Update () {
        movementFunction.move(transform);
        //transform.position = transform.position + new Vector3(Mathf.Sin(Time.time/2)/12f, Mathf.Sin(Time.time*4.5f) / 15, 0.0f);
        //transform.position = transform.position + new Vector3(Triangle(-0.2f,0.2f,2,10,Time.time/2), Mathf.Sin(Time.time * 4) / 30, 0.0f);
        //transform.position = transform.position + new Vector3(Tri(-0.2f, 0.2f, 2, Time.time) / 4, Mathf.Sin(Time.time * 4) / 30, 0.0f);

        if (Time.time > weapon.nextFire)
        {
            weapon.nextFire = Time.time + weapon.fireRate;
            weapon.shoot(this.gameObject);
        }

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
        Destroy(this.gameObject);
    }

    private void OnDestroy()
    {
        Debug.Log("Enemy destroyed");
        //spawn points/buff???
    }
}
