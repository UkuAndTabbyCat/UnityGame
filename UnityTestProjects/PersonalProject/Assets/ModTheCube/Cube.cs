using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;
    private Material material;
    private float rotSpeed;
    private float rotSpeed2;

    void Start()
    {
        rotSpeed = Random.Range(5.0f, 40.0f);
        rotSpeed2 = Random.Range(20.0f, 60.0f);

        transform.position = new Vector3(Random.Range(2.0f, 10.0f), 0, 0);
        transform.localScale = Vector3.one * Random.Range(1.0f, 2.0f);

        material = Renderer.material;

        //material.color = new Color(0.5f, 1.0f, 0.3f, 0.1f);
        material.color = Random.ColorHSV();
    }

    void Update()
    {
        transform.Rotate(Vector3.one, rotSpeed * Time.deltaTime);
        transform.RotateAround(Vector3.zero, Vector3.up, rotSpeed2 * Time.deltaTime);
    }
}
