using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer sr;
    private float dirX;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }
    [SerializeField] private GameObject[] waypoints;
    private int waypointIndex = 0;
    [SerializeField] private float speed = 2f;
    void Update()
    {
        dirX = Input.GetAxis("Horizontal");
        if (Vector2.Distance(waypoints[waypointIndex].transform.position, transform.position) < .1f)
        {
            waypointIndex++;
            if (waypointIndex >= waypoints.Length)
            {
                waypointIndex = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, waypoints[waypointIndex].transform.position,Time.deltaTime * speed);
        if (waypointIndex == 0)
        {
            sr.flipX = false;
        }
        else if (waypointIndex == 1)
        {
            sr.flipX = true;
        }
    }
}
