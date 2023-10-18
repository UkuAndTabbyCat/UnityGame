using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Camera Offset
    private Vector3 camOffSet = new Vector3(0, 8, -9);
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = player.transform.position + camOffSet;
    }

    private void LateUpdate()
    {
        transform.position = player.transform.position + camOffSet;
    }
}
