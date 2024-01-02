using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{

    public int Life { get; private set; }

    private void Awake()
    {
        if (!StartPlayerData.Instance)
        {
            Life = 0;
            return;
        }
        Life = StartPlayerData.Instance.PlayerLife;
    }

}
