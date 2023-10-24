using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float moveSpeed = 30;
    private float xMove;
    private float zMove;
    private float xLimit = 20;
    private float zLimit = 19;

    public GameObject newFood;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        Move();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(newFood, transform.position, newFood.transform.rotation);

        }

    }


    private void Move()
    {
        if (transform.position.x < -xLimit)
        {
            transform.position = new Vector3(-xLimit, transform.position.y, transform.position.z);
        }
        else if (transform.position.x > xLimit)
        {
            transform.position = new Vector3(xLimit, transform.position.y, transform.position.z);
        }
        else
        {
            xMove = Input.GetAxis("Horizontal");
            transform.Translate(Vector3.right * Time.deltaTime * xMove * moveSpeed);
        }

        if (transform.position.z < 1)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 1);
        }
        else if (transform.position.z > zLimit)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zLimit);
        }
        else
        {
            zMove = Input.GetAxis("Vertical");
            transform.Translate(Vector3.forward * Time.deltaTime * zMove * moveSpeed);
        }
    }
}
