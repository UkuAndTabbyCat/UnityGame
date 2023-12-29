using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public PlayerData Instance;

    public int Life { get; private set; }

    private void Awake()
    {
        Instance = this;
        Life = 3;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
