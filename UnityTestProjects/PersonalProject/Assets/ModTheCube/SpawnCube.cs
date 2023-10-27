using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCube : MonoBehaviour
{
    public GameObject cube;
    private float t =0;
    private int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(cube);
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        if (count < 10)
        {
            if (t > 3)
            {
                Instantiate(cube);
                count++;
                t = 0;
            }
        }

    }
}
