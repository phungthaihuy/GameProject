using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHeadCheck : MonoBehaviour
{
    [SerializeField] private AudioSource jumpOnEnemyHead;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player_Check>())
        {
            jumpOnEnemyHead.Play();
            rb.velocity = new Vector2(rb.velocity.x, 2f);
            rb.AddForce(Vector2.up * 200f);
        }
    }
}
