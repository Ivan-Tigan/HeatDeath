using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Boundary
{
    public float xMin, xMax, yMin, yMax;
}
public class Player : MonoBehaviour, IDamageable<DamageInfo> {

    public int points;
    public float speed;

    public Boundary boundary;

    private Rigidbody2D rb;
    private Weapon weapon;

    

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        weapon = GetComponent<Weapon>();
        weapon.direction = transform.up;
	}
	
	// Update is called once per frame
	void Update () {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        rb.velocity = new Vector2(h, v) * speed;

        rb.position = new Vector2(Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax), Mathf.Clamp(rb.position.y, boundary.yMin, boundary.yMax));

        if (Input.GetButton("Fire1") && Time.time > weapon.nextFire)
        {
            weapon.nextFire = Time.time + weapon.fireRate;
            weapon.shoot(this.gameObject);
        }

    }

    public void onDamageTaken(DamageInfo damageInfo)
    {
        Destroy(this.gameObject);
    }

    private void OnDestroy()
    {
        Debug.Log("You died. Game Over.");
    }
}
