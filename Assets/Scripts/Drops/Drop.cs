using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class Drop : MonoBehaviour {

    public WeaponModule module;
    public float fallingSpeed;
    public float rotationSpeed;

	// Use this for initialization
	protected virtual void Start () {
        
        GetComponent<BoxCollider2D>().isTrigger = true;
        GetComponent<BoxCollider2D>().size = GetComponent<SpriteRenderer>().sprite.bounds.size;
        fallingSpeed = 0.75f;
        rotationSpeed = 45f;
	}

    // Update is called once per frame
    protected virtual void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y - fallingSpeed * Time.deltaTime, 0);
        transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.eulerAngles.z + rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.GetComponent<Player>().inventory.weapon.addTemporaryModule(module);
            Destroy(this.gameObject);
        }
    }
}

