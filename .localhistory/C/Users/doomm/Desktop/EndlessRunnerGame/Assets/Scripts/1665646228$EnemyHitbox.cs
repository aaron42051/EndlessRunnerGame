using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitbox : MonoBehaviour {

    public int damage;

    [SerializeField] Lightning lightning;

    private GameObject player;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision);
        if (collision.tag == "Player")
        {
            player.GetComponent<PlayerController>().TakeHit();
        }

        if (collision.tag == "Attack")
        {
            lightning.OnHit();
            Destroy(gameObject);
            Debug.Log("Hit enemy");
        }
    }
}
