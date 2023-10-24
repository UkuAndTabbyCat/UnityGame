using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    private float t = 0.0f;
    private float spamTime = 1;

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;

        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (t > spamTime)
            {
                Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
                t = 0.0f;

            }

        }

        if (t > 500)
        {
            t = 2.0f;
        }

    }
}
