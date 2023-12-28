using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    /*
     每隔10m生成一组随机障碍
     */

    [SerializeField] GameObject normalStep;
    private float cameraHeight;
    private float startHeight = 0;
    private float xBound = 5;

    // Start is called before the first frame update
    void Start()
    {
        // 生成初始step
        cameraHeight = Camera.main.transform.position.y;
        float startStep_y = -10;
        for (int i = 0; i < 10; i++)
        {
            startStep_y += Random.Range(4f, 8f);
            Instantiate(normalStep, new Vector3(Random.Range(-xBound, xBound), startStep_y, 0), normalStep.transform.rotation);
            if (startStep_y > startHeight)
            {
                break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        cameraHeight = Camera.main.transform.position.y;
        if (startHeight - cameraHeight < 8)
        {
            for (int i = 0; i < 5; i++)
            {
                startHeight += Random.Range(4f, 8f);
                GenerateRandomStep(normalStep, startHeight);
            }
        }
    }

    private void GenerateRandomStep(GameObject step, float loc_y)
    {
        float random_x = Random.Range(-xBound, xBound);
        Vector3 loc = new Vector3(random_x, loc_y, 0);

        // generate random step length
        float scale_x = Random.Range(1f, 5f);
        step.transform.localScale = new Vector3(scale_x, step.transform.localScale.y, step.transform.localScale.z);

        Instantiate(step, loc, step.transform.rotation);
    }
}
