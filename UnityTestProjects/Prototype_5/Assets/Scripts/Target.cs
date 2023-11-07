using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class Target : MonoBehaviour
{
    private float xBound = 4;
    private float ySpawnPos = -2;
    private float minForce = 9;
    private float maxForce = 15;
    private float torque = 10;

    public int targetScore;

    private Rigidbody targetRb;
    private GameManager gameManager;
    public ParticleSystem explosionParticle;
    // Start is called before the first frame update
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        transform.position = SpawnRandomPos();
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    Vector3 SpawnRandomPos()
    {
        return new Vector3(Random.Range(-xBound, xBound + 1), ySpawnPos);
    }

    float RandomTorque()
    {
        return Random.Range(-torque, torque);
    }

    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minForce, maxForce);
    }

    private void OnMouseDown()
    {
        if (gameManager.isGameALive)
        {
            Destroy(gameObject);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            gameManager.UpdateScore(targetScore);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if (!gameObject.CompareTag("Bad"))
        {
            gameManager.GameOver();
            gameManager.isGameALive = false;
        }
    }
}
