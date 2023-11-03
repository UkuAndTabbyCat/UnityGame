using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketBehavious : MonoBehaviour
{
    private Transform target;
    private float speed = 15.0f;
    private bool homing;

    private float rocketStrength = 15;
    private float aliveTimer = 8;

    // Update is called once per frame
    void Update()
    {
        if (homing && target != null)
        {
            Vector3 moveDirection = (target.transform.position - transform.position).normalized;
            transform.position += moveDirection * Time.deltaTime * speed;
            transform.LookAt(target);
        }
        if (!target)
        {
            Destroy(gameObject);
        }
    }

    public void Fire(Transform homingTarget)
    {
        target = homingTarget;
        homing = true;
        Destroy(gameObject, aliveTimer);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (target != null)
        {
            if (collision.gameObject.CompareTag(target.tag))
            {
                Rigidbody targetRb = collision.gameObject.GetComponent<Rigidbody>();
                Vector3 away = -collision.contacts[0].normal;
                targetRb.AddForce(away * rocketStrength, ForceMode.Impulse);
                Destroy(gameObject);
            }
        }
    }
}
