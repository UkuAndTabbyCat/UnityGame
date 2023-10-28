using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{

    private PlayerController playerControl;
    public float speed = 20;
    // Start is called before the first frame update
    void Start()
    {
        playerControl = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerControl.isHit == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        if (transform.CompareTag("Obstacle") && transform.position.x < -10)
        {
            Destroy(gameObject);
        }

    }
}
