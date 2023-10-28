using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private PlayerController playerControl;

    public GameObject spawn;
    private Vector3 startLoc = new Vector3(30, 1.5f, 0);
    // Start is called before the first frame update
    void Start()
    {
        playerControl = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnObstacle", 2, 3);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void SpawnObstacle()
    {
        if (playerControl.isHit == false)
        {
            Instantiate(spawn, startLoc, spawn.transform.rotation);
        }

    }
}
