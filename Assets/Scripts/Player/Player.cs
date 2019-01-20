using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Boundary
{
    public float xMin, xMax, yMin, yMax;
}
public class Player : MonoBehaviour, IDamageable<DamageInfo> {

    public float health;
    public int points;
    public float speed;

    public Boundary boundary;

    private Rigidbody2D rb;
    public Inventory inventory;
    

    // Use this for initialization
    void Start () {
        DontDestroyOnLoad(this.gameObject);
        GameController.player = this;

        health = 100f;

        tag = "Player";

        rb = GetComponent<Rigidbody2D>();
        
        inventory = new Inventory();
        equipWeapon(new FireballWeapon());
	}
	
	// Update is called once per frame
	void Update () {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        rb.velocity = new Vector2(h, v) * speed;

        rb.position = new Vector2(Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax), Mathf.Clamp(rb.position.y, boundary.yMin, boundary.yMax));

        inventory.weapon.Update();

    }

    public void equipWeapon(Weapon weapon)
    {
        inventory.weapon = weapon;
        weapon.Start(this.gameObject);
    }

    public void onDamageTaken(DamageInfo damageInfo)
    {
        health -= damageInfo.damage;
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnDestroy()
    {
        Debug.Log("You died. Game Over.");
    }
}
