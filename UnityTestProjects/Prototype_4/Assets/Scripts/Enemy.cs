using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameObject player;
    private Vector3 traceDirection;
    private Rigidbody enemyRb;

    public float enemySpeed;
    //private float shootForce = 20;
    private float yBound = 10;
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

        if (transform.position.y < -yBound || transform.position.y > 2 * yBound)
        {
            Destroy(gameObject);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
/*        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            Vector3 direction = transform.position - collision.transform.position;
            enemyRb.AddForce(direction * shootForce, ForceMode.Impulse);
        }*/
        
    }

}
