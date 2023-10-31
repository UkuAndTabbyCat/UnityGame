using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private PlayerController playerControl;

    public GameObject[] spawn;
    private int spawnIndex;
    private Vector3 startLoc;
    // Start is called before the first frame update
    void Start()
    {
        playerControl = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnObstacle", 6, 3);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void SpawnObstacle()
    {
        if (playerControl.isHit == false)
        {
            spawnIndex = Random.Range(0, spawn.Length);
            startLoc = new Vector3(30, spawn[spawnIndex].transform.position.y, spawn[spawnIndex].transform.position.z);
            Instantiate(spawn[spawnIndex], startLoc, spawn[spawnIndex].transform.rotation);
        }

    }
}
