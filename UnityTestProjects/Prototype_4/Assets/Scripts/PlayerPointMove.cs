using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPointMove : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(Vector3.zero);
        transform.position = transform.parent.position - new Vector3(0, 0.8f, 0);
    }
}
