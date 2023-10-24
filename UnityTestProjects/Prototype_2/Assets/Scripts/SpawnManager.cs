using System.Collections;
using System.Collections.Generic;
using UnityEditor.IMGUI.Controls;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefebs;
    private int animalIndex;
    private Vector3 animalLocation;
    private float loc;
    private int leftOrRight;

    // ���³��ֲ���
    //private float xBound = 20.0f;
    //private float upBound = 28.0f;

    // ���ҳ��ֲ���
    private float leftBound = -25;
    private float rightBound = 25;
    private float topBound = 18;
    private float downBound = 1;


    private float SpawnDelay = 3;
    private float SpawnInteval = 2;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnAnimals", SpawnDelay, SpawnInteval);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnAnimals()
    {
        animalIndex = Random.Range(0, animalPrefebs.Length);
        //loc = Random.Range(-xBound, xBound + 1.0f);
        ////Debug.Log("����λ�ã�" + loc);
        //animalLocation = new Vector3(loc, 0, upBound);
        //Instantiate(animalPrefebs[animalIndex], animalLocation, animalPrefebs[animalIndex].transform.rotation);

        // �趨����λ��������
        loc = Random.Range(downBound, topBound);
        leftOrRight = Random.Range(0, 2);
        if (leftOrRight == 0)
        {
            animalLocation = new Vector3(leftBound, 0, loc);
            // �趨��ת���������y-90��ʹ����ԽǶ�
            animalPrefebs[animalIndex].transform.localEulerAngles = new Vector3(0, 90, 0);
            
        }
        else if (leftOrRight == 1)
        {
            animalLocation = new Vector3(rightBound, 0, loc);
            // �趨��ת�������Ҳ�y-270��ʹ��ȫ����ת�Ƕ�
            animalPrefebs[animalIndex].transform.rotation = Quaternion.Euler(new Vector3(0, 270, 0));
        }

        Instantiate(animalPrefebs[animalIndex], animalLocation, animalPrefebs[animalIndex].transform.rotation);
        
    }
}
