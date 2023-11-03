using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ShootEnemy : MonoBehaviour
{
    // ×·×ÙµÐÈË£¬Åö×²ºóÏú»Ù
    private GameObject enemy;
    private Rigidbody bulletRb;
    public float speed = 10;
    // Start is called before the first frame update
    void Start()
    {
        bulletRb = GetComponent<Rigidbody>();
        enemy = GameObject.FindGameObjectWithTag("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy != null)
        {
            Vector3 direction = (enemy.transform.position - transform.position).normalized;
            transform.Translate(direction * Time.deltaTime * speed);
        }
        else
        {
            Destroy(gameObject);
        }

    }

}
