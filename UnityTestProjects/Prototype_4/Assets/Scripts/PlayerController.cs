using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private Rigidbody enemy;
    private GameObject focalPoint;
    private GameObject powerUpTag;
    //private GameObject shootUpTag;


    public float speed;
    private float verticalInput;
    public bool hasPowerUp;
    //public bool hasShootUp;
    public bool hasSmashUp;

    public float strength;
    public float BLingStrength;
    private Vector3 bouncyDirection;

    private float timeCount = 0;
    //public GameObject bullet;

    // reference
    public PowerUpType currentPowerUp = PowerUpType.None;
    public GameObject rocketPrefab;
    private GameObject tmpRocket;
    private Coroutine powerUpCountDown;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("FocalPoint");
        powerUpTag = GameObject.Find("PowerUpTag");
        powerUpTag.SetActive(hasPowerUp);
        //shootUpTag = GameObject.Find("ShootUpTag");
        //shootUpTag.SetActive(hasShootUp);
    }

    // Update is called once per frame
    void Update()
    {
        verticalInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * verticalInput * speed);

        // 如果有shootUp，每秒发射一次弹幕
        // 二次重写,if 改为switch开关，搭配枚举
        switch (currentPowerUp)
        {
            case PowerUpType.Rockets:
                timeCount += Time.deltaTime;
                if (timeCount > 1)
                {
                    LaunchRockets();
                    timeCount = 0;
                }
                break;

            case PowerUpType.Smash:
                if (Input.GetKeyDown(KeyCode.Space) && !hasSmashUp)
                {
                    hasSmashUp = true;
                    StartCoroutine(SmashBoom());
                }
                break;
        }
    }

    // shoooooot
    /*    private void ShootEnemy()
        {
            // 查找当前场景敌人
            int currentEnemyNum = GameObject.FindGameObjectsWithTag("Enemy").Length;
            for (int i = 0; i < currentEnemyNum; i++)
            {
                Instantiate(bullet, transform.position, bullet.transform.rotation);
            }
        }*/

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            hasPowerUp = true;
            currentPowerUp = other.GetComponent<PowerUp>().powerUpType;
            Destroy(other.gameObject);
            powerUpTag.SetActive(hasPowerUp);

            // 计时器重新计数
            if (powerUpCountDown != null)
            {
                StopCoroutine(powerUpCountDown);
            }
            powerUpCountDown = StartCoroutine(PowerUpTime());
        }

        // First try
        /*        if (other.CompareTag("ShootUp"))
                {
                    hasShootUp = true;
                    Destroy(other.gameObject);
                    shootUpTag.SetActive(hasShootUp);
                    StartCoroutine(ShootUpTime());
                }*/
    }

    IEnumerator PowerUpTime()
    {
        yield return new WaitForSeconds(8);
        hasPowerUp = false;
        powerUpTag.SetActive(hasPowerUp);
        currentPowerUp = PowerUpType.None;
    }


    // First try
    /*IEnumerator ShootUpTime()
    {
        yield return new WaitForSeconds(8);
        hasShootUp = false;
        shootUpTag.SetActive(hasShootUp);
    }*/

    IEnumerator SmashBoom()
    {
        // Up
        while (transform.position.y < 20)
        {
            playerRb.AddForce(Vector3.up * 20, ForceMode.Impulse);
            yield return null;
        }

        // Down
        while (transform.position.y > 20)
        {
            playerRb.AddForce(Vector3.down * 20, ForceMode.Impulse);
            yield return null;
        }

        //if (!hasSmashUp)
        //{
        //    playerRb.AddExplosionForce(50, transform.position, 20);
        //}

        //yield return null;

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && currentPowerUp == PowerUpType.PushBack)
        {
            bouncyDirection = collision.transform.position - transform.position;
            enemy = collision.gameObject.GetComponent<Rigidbody>();
            enemy.AddForce(bouncyDirection * strength, ForceMode.Impulse);
            Debug.Log("Player collided with " + collision.gameObject.name + "with powerup set to " + currentPowerUp.ToString());
        }

        if (collision.gameObject.name == "BLingBLing(Clone)")
        {
            bouncyDirection = transform.position - collision.transform.position;
            playerRb.AddForce(bouncyDirection * BLingStrength, ForceMode.Impulse);
        }

        if (collision.gameObject.CompareTag("Ground"))
        {
            hasSmashUp = false;
        }
    }

    void LaunchRockets()
    {
        foreach (var enemy in FindObjectsByType<Enemy>(FindObjectsSortMode.None))
        {
            tmpRocket = Instantiate(rocketPrefab, transform.position + Vector3.up, Quaternion.identity);
            tmpRocket.GetComponent<RocketBehavious>().Fire(enemy.transform);
        }
    }

}
