using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitbox : MonoBehaviour {

    public int damage;

    private GameObject player;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            player.GetComponent<PlayerController>().TakeHit();
        }

        if (collision.tag == "Attack")
        {
            Destroy(gameObject);
        }
    }
}
