using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float moveSpeed = 30;
    private float move;
    private float limit = 20;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -limit)
        {
            transform.position = new Vector3(-limit, transform.position.y, transform.position.z);
        }
        else if (transform.position.x > limit)
        {
            transform.position = new Vector3(limit, transform.position.y, transform.position.z);
        }
        else
        {
            move = Input.GetAxis("Horizontal");
            transform.Translate(Vector3.right * Time.deltaTime * move * moveSpeed);
        }

    }
}
