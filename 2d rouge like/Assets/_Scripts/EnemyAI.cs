using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using System;

public class EnemyAI : MonoBehaviour
{
    public Transform target;

    public float speed = 200f;
    public float nextWaypointDistance = 2f;
    public float timeForNextShot = 1.5f;
    float shotTime = 0f;

    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;

    Seeker seeker;
    Rigidbody2D rb;
    Shooting shooting;

    private void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        shooting = GetComponent<Shooting>();

        target = GameObject.Find("Player").transform;

        InvokeRepeating("UpdatePath", 0.1f, 0.5f);

    }

    void UpdatePath()
    {
        if (Vector2.Distance(rb.position, target.position) < 5)
        {
            if (seeker.IsDone())
            {
                seeker.StartPath(rb.position, target.position, OnPathComplete);
            }
        }
    }

    public void Spawning()
    {

    }

    void OnPathComplete(Path p)
    {
        if(!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    private void FixedUpdate()
    {
        if (path == null)
            return;       

        if (Vector2.Distance(rb.position, target.position) < 8)
        {
            if (currentWaypoint >= (path.vectorPath.Count - 1))
            {
                reachedEndOfPath = true;
                return;
            }
            else
            {
                reachedEndOfPath = false;
            }

            Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
            Vector2 force = direction * speed * Time.deltaTime;

            rb.AddForce(force);

            float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

            if (distance < nextWaypointDistance)
            {
                currentWaypoint++;
            }
        }
    }

    private void Update()
    {
        shotTime += Time.deltaTime;

        if (Vector2.Distance(rb.position, target.position) < 7)
        {
            var dir = target.position - transform.position;
            var angle = (Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg) - 90;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            
                if (shotTime >= timeForNextShot)
                {            
                    shotTime = 0f;
                    if (Vector2.Distance(rb.position, target.position) < 5)
                    {
                        shooting.Shoot(false);
                    }
                }
        }
    }
}

