using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] ballPrefabs;

    private float spawnLimitXLeft = -22;
    private float spawnLimitXRight = 7;
    private float spawnPosY = 30;

    private float startDelay = 1.0f;
    private float spawnInterval = 4.0f;
    private float t = 0.0f;
    private float randomT;

    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating("SpawnRandomBall", startDelay, spawnInterval);
        randomT = Random.Range(3, 6);
    }

    // Spawn random ball at random x position at top of play area


    private void Update()
    {
        t += Time.deltaTime;
        if (t > randomT)
        {
            //Debug.Log("当前t值：" + t);
            SpawnRandomBall();
            t = 0.0f;
            randomT = Random.Range(3, 6);
        }
    }
    void SpawnRandomBall()
    {
        // Generate random ball index and random spawn position
        Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);

        int loc = Random.Range(0, ballPrefabs.Length);

        // instantiate ball at random spawn location
        Instantiate(ballPrefabs[loc], spawnPos, ballPrefabs[loc].transform.rotation);
    }

}
