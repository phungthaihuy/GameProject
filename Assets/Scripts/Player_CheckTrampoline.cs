using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_CheckTrampoline : MonoBehaviour
{
    [SerializeField] private AudioSource jumpOnTrampoline;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trampoline"))
        {
            jumpOnTrampoline.Play();
            rb.velocity = new Vector2(rb.velocity.x, 20f);

        }
    }
}
