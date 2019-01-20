using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyDrop : Drop {
    protected override void Start()
    {
        GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load("Sprites/Drops/Coal", typeof(Sprite));
        base.Start();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Player>().inventory.coal+= new System.Random().Next(5, 10);
            Destroy(this.gameObject);
        }
    }


}
