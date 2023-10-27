using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackGround : MonoBehaviour
{
    private Vector3 startBGLoc;
    private float repeatX;
    // Start is called before the first frame update
    void Start()
    {
        startBGLoc = transform.position;
        repeatX = transform.GetComponent<BoxCollider>().size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < startBGLoc.x - repeatX)
        {
            transform.position = startBGLoc;
        }
    }
}
