using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForwardAndDestroy : MonoBehaviour
{

    public float speed = 40.0f;
    private float upBound = 30.0f;
    private float downBound = -6.0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);

        if (transform.position.z > upBound)
        {
            Destroy(gameObject);
        }
        else if (transform.position.z < downBound)
        {
            Debug.Log("Game Over!!! You Lose A " + gameObject.name);
            Destroy(gameObject);
        }


    }
}
