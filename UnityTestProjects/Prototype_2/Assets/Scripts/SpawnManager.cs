using System.Collections;
using System.Collections.Generic;
using UnityEditor.IMGUI.Controls;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefebs;
    public int animalIndex;
    private Vector3 animalLocation;
    private float loc;

    private float xBound = 20.0f;
    private float upBound = 28.0f;

    private float SpawnDelay = 3;
    private float SpawnInteval = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnAnimals", SpawnDelay, SpawnInteval);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnAnimals()
    {
        animalIndex = Random.Range(0, animalPrefebs.Length);
        loc = Random.Range(-xBound, xBound + 1.0f);
        //Debug.Log("³öÉúÎ»ÖÃ£º" + loc);
        animalLocation = new Vector3(loc, 0, upBound);
        Instantiate(animalPrefebs[animalIndex], animalLocation, animalPrefebs[animalIndex].transform.rotation);
    }
}
