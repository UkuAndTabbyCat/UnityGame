using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameObject player;
    private Vector3 traceDirection;
    private Rigidbody enemyRb;

    public float enemySpeed;
    private float yBound = -10;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        enemyRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        traceDirection = (player.transform.position - transform.position).normalized;
        enemyRb.AddForce(traceDirection * enemySpeed);

        if (transform.position.y < yBound)
        {
            Destroy(gameObject);
        }

    }
}
