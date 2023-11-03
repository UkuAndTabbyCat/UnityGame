using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefeb;
    public GameObject[] powerUpPrefeb;

    private float bound = 9;
    public int waveNum;
    // Start is called before the first frame update
    void Start()
    {
        //Invoke("SpawnEnemy", 3);
        //Debug.Log("Start");
    }

    // Update is called once per frame
    void Update()
    {

        int enemyNum = GameObject.FindObjectsByType<Enemy>(FindObjectsSortMode.None).Length;
        if (enemyNum == 0)
        {
            waveNum++;
            SpawnEnemy(waveNum);
            int powerUpIndex = Random.Range(0, powerUpPrefeb.Length);
            Instantiate(powerUpPrefeb[powerUpIndex], SpawnRandomPos(), powerUpPrefeb[powerUpIndex].transform.rotation);
        }
    }

    void SpawnEnemy(int enemiesToSpawn)
    {

        for (int i = 0; i < enemiesToSpawn; i++)
        {
            int enemyIndex = Random.Range(0, enemyPrefeb.Length);
            Instantiate(enemyPrefeb[enemyIndex], SpawnRandomPos(), enemyPrefeb[enemyIndex].transform.rotation);
        }
    }

    private Vector3 SpawnRandomPos()
    {
        float xBound = Random.Range(-bound, bound);
        float zBound = Random.Range(-bound, bound);
        Vector3 enemyPosition = new Vector3(xBound, 0.5f, zBound);
        return enemyPosition;
    }
}
