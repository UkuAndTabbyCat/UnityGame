using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private Rigidbody enemy;
    private GameObject focalPoint;
    private GameObject powerUpTag;
    private GameObject shootUpTag;


    public float speed;
    private float verticalInput;
    public bool hasPowerUp;
    public bool hasShootUp;
    public float strength;
    public float BLingStrength;
    private Vector3 bouncyDirection;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("FocalPoint");
        powerUpTag = GameObject.Find("PowerUpTag");
        powerUpTag.SetActive(hasPowerUp);
        shootUpTag = GameObject.Find("ShootUpTag");
        shootUpTag.SetActive(hasShootUp);
    }

    // Update is called once per frame
    void Update()
    {
        verticalInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * verticalInput * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            hasPowerUp = true;
            Destroy(other.gameObject);
            powerUpTag.SetActive(hasPowerUp);
            StartCoroutine(PowerUpTime());
        }

        if (other.CompareTag("ShootUp"))
        {
            hasShootUp = true;
            Destroy(other.gameObject);
            shootUpTag.SetActive(hasShootUp);
            StartCoroutine(PowerUpTime());

        }
    }

    IEnumerator PowerUpTime()
    {
        yield return new WaitForSeconds(8);
        hasPowerUp = false;
        powerUpTag.SetActive(hasPowerUp);
        hasShootUp = false;
        shootUpTag.SetActive(hasShootUp);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (hasPowerUp && collision.gameObject.CompareTag("Enemy"))
        {
            bouncyDirection = collision.transform.position - transform.position;
            enemy = collision.gameObject.GetComponent<Rigidbody>();
            enemy.AddForce(bouncyDirection * strength, ForceMode.Impulse);
        }

        if (collision.gameObject.CompareTag("BLingBLing"))
        {
            bouncyDirection = transform.position - collision.transform.position;
            playerRb.AddForce(bouncyDirection * BLingStrength, ForceMode.Impulse);
        }

    }
}
